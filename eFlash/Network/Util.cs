using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using eFlash.Data;
using eFlash.File;
using eFlash.dbAccess;
using System.Collections;
using System.Windows.Forms;
using System.Xml;

namespace eFlash.Network
{
    class Util
    {
       
        public static int parseBLOB(byte[] blob, int uid)
        {
           
            int size = 0;
            int curDid = -1;
            int curCid = -1;                
            byte[] data = null;            
            Deck deck = null;
            eObject curObj = null;
            Card curCard = null;
            MemoryStream stream = new MemoryStream(blob);
            XmlTextReader reader = new XmlTextReader(stream);

            
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:

                            if (reader.Name == "Deck")
                            {
                                deck = new Deck(reader.GetAttribute("cat"), reader.GetAttribute("subcat"),
                                    reader.GetAttribute("title"), reader.GetAttribute("type"),Convert.ToInt32(reader.GetAttribute("nuid")), uid);                      
                           
                                try
                                {
                                    //Insert to Decks table in local database 
                                    curDid = deck.saveToDB();
                                }
                                catch
                                {
                                    throw new Exception("Error Writting Deck!!!");
                                }
                            }
                            else if (reader.Name == "Card")
                            {
                                curCard = new Card(reader.GetAttribute("tag"), uid);
                                
                             
                                try
                                {
                                     //Insert to Cards table in local database
                                    curCid = curCard.saveToDB(curDid);
                                }
                                catch
                                {                                   
                                    throw new Exception("Error Writting Card!!!");
                                }

                            }
                            else if (reader.Name == "Object")
                            {
                                //First create the array of bytes for the blob
                                size = Convert.ToInt32(reader.GetAttribute("size"));
                                data = new byte[size];

                                curObj = new eObject( curCid, 
                                                                         Convert.ToInt32(reader.GetAttribute("side")),
                                                                         reader.GetAttribute("type"),
                                                                         Convert.ToInt32(reader.GetAttribute("x1")),
                                                                         Convert.ToInt32(reader.GetAttribute("x2")),
                                                                         Convert.ToInt32(reader.GetAttribute("y1")),
                                                                         Convert.ToInt32(reader.GetAttribute("y2"))                                                                         
                                                                         );
								
								try
								{
									string qType = reader.GetAttribute("quizType");
									if (qType == Constant.nonePrefix || qType == Constant.answerPrefix || qType == Constant.questionPrefix)
									{
										curObj.quizType = qType;
									}
								}
								catch {}

                                 try
                                {
                                    reader.ReadElementContentAsBase64(data, 0, size);
                                    curObj.efile = new eFile(data);

                                    //save to file and update DB
                                    curObj.save();                                   
                                 }
                                catch
                                 {
                                    throw new Exception("Error Saving Object !!!");
                                 }                               
                               
                            }
                            
                            break;                           
                    }       

                }
                return curDid;
            }
   
           
        


        public static byte[] buildNetBLOB(Deck deck, int uploaderID)
        {
            Card curCard;
            eObject curObj;
            IEnumerator objEnum;
            IEnumerator cardEnum;
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, System.Text.Encoding.UTF8);

            //Use automatic indentation for readability.
            writer.Formatting = Formatting.Indented;

            //Write the root element
            writer.WriteStartElement("eFlash-Network");

            //Start an element
            writer.WriteStartElement("Deck");
            
            //Add attribute to Deck
            writer.WriteAttributeString("cat", deck.category);
            writer.WriteAttributeString("subcat", deck.subcategory);
            writer.WriteAttributeString("title", deck.title);
            writer.WriteAttributeString("type", deck.type);
            writer.WriteAttributeString("nuid", Convert.ToString(uploaderID));

            cardEnum = deck.cardList.GetEnumerator();
            while (cardEnum.MoveNext())
            {
                //Load the cards belonging to this deck
                 curCard = (Card)cardEnum.Current;
                 writer.WriteStartElement("Card");
                 writer.WriteAttributeString("tag",curCard.tag);

                objEnum = curCard.eObjectList.GetEnumerator();
                while (objEnum.MoveNext())
                {
                    curObj = (eObject)objEnum.Current;

                    writer.WriteStartElement("Object");
                    writer.WriteAttributeString("size", Convert.ToString(curObj.efile.size));
                    writer.WriteAttributeString("side", Convert.ToString(curObj.side));
                    writer.WriteAttributeString("type", Convert.ToString(curObj.type));
					writer.WriteAttributeString("quizType", Convert.ToString(curObj.quizType));
                    writer.WriteAttributeString("x1", Convert.ToString(curObj.x1));
                    writer.WriteAttributeString("x2", Convert.ToString(curObj.x2));
                    writer.WriteAttributeString("y1", Convert.ToString(curObj.y1));
                    writer.WriteAttributeString("y2", Convert.ToString(curObj.y2));                    
                    
                    writer.WriteBase64(curObj.efile.rawData, 0, curObj.efile.size);
                    
                    // end the Object element
                    writer.WriteEndElement();
                }
                // end the Card element
                writer.WriteEndElement();
            }
            // end the Deck element
            writer.WriteEndElement();       
           
            // end the root element
            writer.WriteFullEndElement();
            //writer.WriteEndDocument();

            //Close the writer and stream
            writer.Close();
            stream.Close();           

            return stream.ToArray();
        }

        public static void showBytes(byte[] data)
        {
          /*  StringBuilder tmp = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                tmp.Append(Convert.ToChar(data[i]));
            MessageBox.Show(tmp.ToString());          
           */
            FileStream fs = new FileStream(Constant.ePath + "\\text.xml", FileMode.Create);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        public static Bitmap binTobmp(byte[] data)
        {
            if (data == null)
                return null;

            MemoryStream ms = new MemoryStream(data);

            return new Bitmap(ms);
        }

        public static byte[] bmpTobin(Bitmap bmp)
        {
            if (bmp == null)
                return null;

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }

    }
}
