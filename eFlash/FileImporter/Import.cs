using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using eFlash.dbAccess;
using eFlash.Data;
using System.Windows.Forms;

namespace eFlash.FileImporter
{
    class Import
    {      
        //Global variables

        private string[] side_and_topic_values;
        private string filename = "";
        private string num_of_items = "";
        private char[] array_delimiter = new char[1];
        private int deck_id = 0;
        private ArrayList values;
        private ArrayList card_Format_for_values;
        private ArrayList Description_of_values;
        //

        public Import(string fn, string num_items, char[] array_delim,
                             ArrayList vals, ArrayList card_Format,
                              ArrayList desc_of_values, int did)
        {
            filename = fn;
            num_of_items = num_items;
            array_delimiter = array_delim;
            deck_id = did;
            values = vals;
            card_Format_for_values = card_Format;
            Description_of_values = desc_of_values;
        }
        


          
        public void ImportFile()
        {
            try
            {
                side_and_topic_values = new string[values.Count];
                StreamReader sr = new StreamReader(filename);
                ArrayList array_of_side_indices = card_Format_for_values;
                int index_of_topictag = 200;

                for (int i = 0; i < array_of_side_indices.Count; i++)
                {
                    string format_object = (string)array_of_side_indices[i];
                    if (format_object.Equals("Topic Tag"))
                    {
                        index_of_topictag = i;
                    }
                }


                string line = sr.ReadLine();
                int cid;
                
                //values for cards database
                string[] cardsValues = new string[2];
                do
                {
                    string[] linearray = line.Split(array_delimiter);
                    //convert linearray to an arrayList 
                    ArrayList linearray_List = new ArrayList();
                    for (int i = 0; i < linearray.Length; i++)
                    {
                        linearray_List.Add(linearray[i]);
                    }
                    //
                    for (int j = 0; j < linearray.Length; j++)
                    {
                        if (index_of_topictag == j)
                        {
                            side_and_topic_values[side_and_topic_values.Length - 1] = linearray[j];
                            cardsValues[0] = side_and_topic_values[side_and_topic_values.Length - 1];                           
                            
                        }
                        else
                        {
                            int side_number = Convert.ToInt32(array_of_side_indices[j]);
                            side_and_topic_values[side_number] = linearray[j];
                        }
                    }

                   
                    cardsValues[1] = "" + Profile.ProfileManager.getCurrentUserID();
                    
                    cid = insertLocalDB.insertToCards(cardsValues);
                    if (cid == -1)
                    {
                        MessageBox.Show("Trouble inserting card");
                        return;
                    }
                    else
                    {
                        //insert into CDRelation database
                       
                        insertLocalDB.insertToCDRelations(deck_id, cid);


                        int x1 = 30;
                        int x2 = 70;
                        int y1 = 30;
                        int y2 = 70;

                        int length = side_and_topic_values.Length;
                        if (index_of_topictag != 200)
                        {
                            length = side_and_topic_values.Length - 1;
                        }
                    
                        for (int i = 0; i < length ; i++)
                        {


                            int side = i;
                             string type =  "";
                            string card_value = (string)side_and_topic_values[i];
                            int desc_of_values_index = linearray_List.IndexOf(card_value);
                            string desc_of_value = (string) Description_of_values[desc_of_values_index];
                            char char_desc_of_value = desc_of_value[0];
                          
                            if (char_desc_of_value == 'V')
                            {

                                type = Constant.textFile;
                                 insertTextFile(card_value, cid, side, type, x1, x2, y1, y2);


                            }
                            else if (char_desc_of_value == 'P')
                            {
                                
                                if (desc_of_value == "Picture Filepath")
                                {
                                    type = Constant.imageFile;
                                    insertPictureOrSoundFile(card_value, cid, side,
                                                            type, x1, x2, y1, y2);


                                }
                                    //desc_of_value = "Picture Title"
                                else
                                {
                                    type = Constant.textFile;
                                    insertTextFile(card_value, cid, side, type,
                                                    x1, x2, y1, y2);
                                    
                                }
                            }
                                // (char_desc_of_value == 'S')
                            else
                            {

                                if (desc_of_value == "Sound Filepath")
                                {
                                    type = Constant.soundFile;
                                    insertPictureOrSoundFile(card_value, cid, side, type,
                                                            x1, x2, y1, y2);

                                }
                                    //desc_of_value = "Sound Title"
                                else
                                {
                                    type = Constant.textFile;
                                    insertTextFile(card_value, cid, side, type,
                                                    x1, x2, y1, y2);
                                }
                            }

                            
                          
                        }
                        line = sr.ReadLine();
                    }

                } while ((line != null) && (line != ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static byte[] ConvertStringToByteArray(string stringToConvert)
        {

            return (new UnicodeEncoding()).GetBytes(stringToConvert);

        }

        private static void insertTextFile(string str, int cid, int side, string type, 
                                            int x1, int x2, int y1, int y2)
        {
            try
            {
                
                
                byte[] data = ConvertStringToByteArray(str);
                //For saving the eObject into FileSystem and DB,
                eObject curObj = new eObject(cid, side, type, x1, x2, y1, y2);
                curObj.efile = new eFile(data); //data is stream.toArry();
                curObj.save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertPictureOrSoundFile(string card_value, int cid, int side, string type, 
                                            int x1, int x2, int y1, int y2)
        {
            try
            {
                char[] param = new char[1];
                param[0] = '\\';
                string[] card_value_array = card_value.Split(param);
                string filename = card_value_array[card_value_array.Length - 1];
                byte[] _rawData;
                FileStream file;
                file = new FileStream(card_value, FileMode.Open, FileAccess.Read);
                _rawData = new byte[(int)file.Length];
                file.Read(_rawData, 0, (int)file.Length);
                file.Close();
                eObject curObj = new eObject(cid, side, type, x1, x2, y1, y2);
                curObj.efile = new eFile(_rawData);
                

                curObj.save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
