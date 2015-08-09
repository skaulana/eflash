using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Graph = Microsoft.Office.Interop.Graph;
using System.Runtime.InteropServices;
using eFlash.dbAccess;
using eFlash.Data;

namespace eFlash.GUI.File
{
    public partial class exportScreen : Form
    {
        const int PPTFONTMULTIPLIER = 2;

        int cardIndex;
        int totalCards;
        int curSide;
        int cardNum;
        int numSides;
        int did; //Pass From Outside
        int cid;
        List<Card> cardList;
        List<eObject> objectList;
        //Card curCard;
        int defaultFontSize = 24;
        string defaultFont = "Arial";
        eFlash.File.Powerpoint ppt;

        public exportScreen(int deckid)
        {
            InitializeComponent();

            did = deckid;

            cardIndex = 0;

            curSide = 0;
            cardNum = 0;
            cardList = selectLocalDB.getCards(did);

            //set card parameters
            totalCards = cardList.Count;

            //set save dialog defaults
            saveFileDialog1.InitialDirectory = Constant.ePath;
            saveFileDialog1.DefaultExt = "ppt";
            saveFileDialog1.Filter = "PowerPoint Presentations (*.ppt)|*.ppt|All files (*.*)|*.*";
            //saveFileDialog1.InitialDirectory = "C:\\Program Files\\eFlash\\Data\\Media\\";
            saveFileDialog1.Title = "Export PowerPoint to...";

            if (DialogResult.Cancel != saveFileDialog1.ShowDialog())
            {
                ppt = new eFlash.File.Powerpoint();
                ShowPresentation();
                GC.Collect();
            }

            this.Close();
        }

        #region Iterators

        private void ShowPresentation()
        {
            cardNum = 1;

            foreach (Card curCard in cardList)
            {
                //get objects for curSide
                cid = curCard.cardID;
                objectList = selectLocalDB.getViewerObjects(cid);
                numSides = getNumSides(objectList);

                for (curSide = 0; curSide <= numSides; curSide++)
                {
                    ppt.AddSlide();
                    ppt.AddText("Card: " + Convert.ToString(cardNum), defaultFont, defaultFontSize, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse, 0, Constant.cardHeight, 100, 50);
                    ppt.AddPic(Constant.ePath + "Side" + Convert.ToString(curSide + 1) + ".png", MsoTriState.msoFalse, MsoTriState.msoTrue, Constant.cardWidth, Constant.cardHeight, 120, 80);
                    //ppt.AddPic("C:\\Program Files\\eFlash\\Data\\Media\\Side" + Convert.ToString(curSide+1) + ".png", MsoTriState.msoFalse, MsoTriState.msoTrue, Constant.cardWidth, Constant.cardHeight, 120, 80);

                    foreach (eObject obj in objectList)
                    {
                        if (obj.side == curSide)
                        {
                            switch (obj.type)
                            {
                                case Constant.textFile:
                                    drawText(obj);
                                    break;
                                case Constant.imageFile:
                                    drawImage(obj);
                                    break;
                                case Constant.soundFile:
                                    drawSound(obj);
                                    break;
                                default:
                                    throw new ArgumentException("Invalid CreatorObject type: " + obj.type);
                            }
                        }
                    }
                }

                cardNum++;
            }

            ppt.FinishPres();

            //Close the presentation without saving changes and quit PowerPoint.
            ppt.SaveAs(saveFileDialog1.FileName);

            MessageBox.Show("Deck exported to " + saveFileDialog1.FileName + " successfully.",
                "Successfully Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int getNumSides(List<eObject> objectList)
        {
            numSides = 0;
            foreach (eObject obj in objectList)
            {
                if (obj.side > numSides)
                {
                    numSides = obj.side;
                }
            }
            return numSides;
        }

        #endregion

        #region Builders

        public void drawText(eObject obj)
        {

            int Left = obj.x1 * Constant.cardWidth / 100;
            int Top = obj.y1 * Constant.cardHeight / 100;
            int Width = (obj.x2 - obj.x1) * Constant.cardWidth / 100;
            int Height = (obj.y2 - obj.y1) * Constant.cardHeight / 100;

            RichTextBox txtText = new RichTextBox();
            try
            {
                txtText.LoadFile(Constant.ePath + obj.data, RichTextBoxStreamType.RichText);
                //txtText.LoadFile("C:\\Program Files\\eFlash\\Data\\Media\\" + obj.data, RichTextBoxStreamType.RichText);
            }
            catch (Exception e)
            {
                MessageBox.Show("file not found");
            }

            MsoTriState isItalic = MsoTriState.msoFalse;
            MsoTriState isBold = MsoTriState.msoFalse;
            MsoTriState isUnderlined = MsoTriState.msoFalse;
            if (txtText.Font.Italic)
                isItalic = MsoTriState.msoTrue;
            if (txtText.Font.Bold)
                isBold = MsoTriState.msoTrue;
            if (txtText.Font.Underline)
                isUnderlined = MsoTriState.msoTrue;
            //byte r = txtText.ForeColor.R;
            //byte g = txtText.ForeColor.G;
            //byte b = txtText.ForeColor.B;
            //int col = 256 * 256 * r + 256 * g + b;

            ppt.AddText(txtText.Text, txtText.Font.Style.ToString(), txtText.Font.Size * PPTFONTMULTIPLIER, isBold, isItalic, isUnderlined, Left, Top, Width, Height);
        }


        public void drawImage(eObject obj)
        {
            int Left = obj.x1 * Constant.cardWidth / 100;
            int Top = obj.y1 * Constant.cardHeight / 100;
            int Width = (obj.x2 - obj.x1) * Constant.cardWidth / 100;
            int Height = (obj.y2 - obj.y1) * Constant.cardHeight / 100;

            ppt.AddPic(Constant.ePath + obj.data, MsoTriState.msoFalse, MsoTriState.msoTrue, Left, Top, Width, Height);
            //ppt.AddPic("C:\\Program Files\\eFlash\\Data\\Media\\" + obj.data, MsoTriState.msoFalse, MsoTriState.msoTrue, Left, Top, Width, Height);
        }

        public void drawSound(eObject obj)
        {

            int Left = obj.x1 * Constant.cardWidth / 100;
            int Top = obj.y1 * Constant.cardHeight / 100;
            int Width = (obj.x2 - obj.x1) * Constant.cardWidth / 100;
            int Height = (obj.y2 - obj.y1) * Constant.cardHeight / 100;

            ppt.AddSound(Constant.ePath + obj.data, Left, Top, Width, Height);
            //ppt.AddSound("C:\\Program Files\\eFlash\\Data\\Media\\" + obj.data, Left, Top, Width, Height);
        }
        #endregion
    }
}