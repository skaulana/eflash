using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using eFlash.dbAccess;
using eFlash.Data;



namespace eFlash.GUI.ViewerAndQuizzer
{
    public partial class Viewer : Form
    {
        public static bool emptyDeckError = false;
        int cardIndex;
        int totalCards;
        int curSide;
        int numSides;
        int did; //Pass From Outside
        int cid;
        List<Card> cardList;
        List<eObject> objectList;
        Card curCard;

        main prevWin;



        public Viewer(main newPrevWindow, int newDeck)
        {
            InitializeComponent();
            

            prevWin = newPrevWindow;    //for return to main screen

            //// insert some eobject into DB for testing////
            

           //////////////        unit    test case ///////////////////
            /*
           eObject testObject1 = new eObject(1, 1, Constant.textFile, 0, 100, 0, 100, "1.rtf");
           eObject testObject2 = new eObject(2, 2, Constant.textFile, 0, 80, 0, 80, "2.rtf");
            
           eObject testObject3 = new eObject(3, 1, Constant.textFile, 10, 50, 10, 50, "3.rtf");
           eObject testObject4 = new eObject(4, 2, Constant.textFile, 50, 70, 50, 70, "4.rtf");

           eObject testObject5 = new eObject(5, 2, Constant.textFile, 10, 50, 10, 50, "5.rtf");
           eObject testObject6 = new eObject(6, 2, Constant.textFile, 50, 80, 50, 80, "6.rtf");


           eObject testObject7 = new eObject(7, 2, Constant.textFile, 10, 50, 10, 50, "7.rtf");
           eObject testObject8 = new eObject(8, 2, Constant.textFile, 50, 70, 50, 70, "8.rtf");
            
           eObject testObject9 = new eObject(13, 1, Constant.textFile, 0, 30, 0, 30, "5.txt");
           eObject testObject10 = new eObject(13, 2, Constant.textFile, 40, 70, 40, 80, "5.txt");

           eObject testObject11 = new eObject(14, 1, Constant.textFile, 10, 50, 10, 50, "6.txt");
           eObject testObject12 = new eObject(14, 2, Constant.textFile, 50, 70, 50, 70, "6.txt");

           eObject testObject13 = new eObject(15, 1, Constant.textFile, 10, 50, 10, 50, "7.txt");
           eObject testObject14= new eObject(15, 1, Constant.textFile, 50, 80, 50, 80, "7.txt");
            
           eObject testObject15 = new eObject(16, 1, Constant.textFile, 10, 50, 10, 50, "8.txt");
           eObject testObject16= new eObject(16, 1, Constant.textFile, 50, 70, 50, 70, "8.txt");
            
            testObject1.loadData();
            testObject2.loadData();
            testObject3.loadData();
            testObject4.loadData();
            testObject5.loadData();
            testObject6.loadData();
            testObject7.loadData();
            testObject8.loadData();
            
            testObject9.loadData();
            testObject10.loadData();
            testObject11.loadData();
            testObject12.loadData();
            testObject13.loadData();
            testObject14.loadData();
            testObject15.loadData();
            testObject16.loadData();
           
            testObject1.save();
            testObject2.save(); 
            testObject3.save(); 
            testObject4.save();
            testObject5.save();
            testObject6.save();
            testObject7.save();
            testObject8.save();
            
            testObject9.save();
            testObject10.save(); 
            testObject11.save(); 
            testObject12.save();
            testObject13.save();
            testObject14.save();
            testObject15.save();
            testObject16.save();
            */
            
            did = newDeck;

            cardIndex = 0;

            curSide = 0;
            cardList = selectLocalDB.getCards(did);
            //set card parameters
            totalCards = cardList.Count;

            if (totalCards == 0)
            {
                MessageBox.Show("This Deck Has No Cards");
                emptyDeckError = true;
                return;
            }

        
            curCard = cardList[cardIndex];
            //get objects for curSide
            cid = curCard.cardID;
            objectList = selectLocalDB.getViewerObjects(cid);
            numSides = getNumSides(objectList);
  

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Previous_Click(object sender, EventArgs e)
        {
            if (cardIndex > 0)
            {
                clearCard();
                cardIndex--;
                curSide = 0;
                curCard = cardList[cardIndex];
                cid = curCard.cardID;
                objectList = selectLocalDB.getViewerObjects(cid);
                
                numSides = getNumSides(objectList);
                createCard(objectList);
                side.Text = "CardIndex: " + cardIndex + " Side: " + curSide;
                curSide++;
            }
            else
            {
                clearCard();
                curSide = 0;
                curCard = cardList[cardIndex];
                cid = curCard.cardID;
                objectList = selectLocalDB.getViewerObjects(cid);

                numSides = getNumSides(objectList);
                createCard(objectList);
                side.Text = "CardIndex: " + cardIndex + " Side: " + curSide;
                MessageBox.Show("This is the  Beginning ");
                curSide++;
            }
        }

        private void Flip_Click(object sender, EventArgs e)
        {
            if (curSide <= numSides)
            {
                clearCard();
                createCard(objectList);
                side.Text = "CardIndex: " + cardIndex + " Side: " + curSide;
                curSide++;
                
            }
            else if (cardIndex < (totalCards-1))
            {
                clearCard();
                cardIndex++;
                curSide = 0;
                curCard = cardList[cardIndex];
                cid = curCard.cardID;
                objectList = selectLocalDB.getViewerObjects(cid);
                numSides = getNumSides(objectList);
                
                createCard(objectList);
                side.Text = "CardIndex: " + cardIndex + " Side: " + curSide;
                curSide++;
            }
            else MessageBox.Show(" This is the end ");
        }





        private void Next_Click(object sender, EventArgs e)
        {
            if (cardIndex < (totalCards-1))
            {
                clearCard();
                cardIndex++;
                curSide = 0;
                curCard = cardList[cardIndex];
                cid = curCard.cardID;
                objectList = selectLocalDB.getViewerObjects(cid);
                numSides = getNumSides(objectList);
                createCard(objectList);
                side.Text = "CardIndex: " + cardIndex + " Side: " + curSide;
                curSide++;
            }
            else MessageBox.Show(" This is the end");
        }

        
        public void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            prevWin.Show();
            this.Close();


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


        private void createCard(List<eObject> objectList)
        {
            foreach (eObject obj in objectList)
            {
                if (obj.side == curSide)
                {
                   Displayer.display(obj,this.panel1);
                }
            }
        }

        private void clearCard()
        {


            foreach (Control control in panel1.Controls) {

                if (control.GetType() == typeof(PlayButton))
                {
                    ((PlayButton) control).player.Close(((PlayButton)control).alias );
                }
            
            }

            panel1.Controls.Clear();

        }

      

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, EventArgs e)
        {
            prevWin.Show();
        }

        private void LastCard_Click(object sender, EventArgs e)
        {
            clearCard();
            cardIndex = 0;
            curSide = 0;
            curCard = cardList[cardIndex];
            cid = curCard.cardID;
            objectList = selectLocalDB.getViewerObjects(cid);

            numSides = getNumSides(objectList);
            createCard(objectList);
            side.Text = "CardIndex: " + cardIndex + " Side: " + curSide;
            curSide++;
        }

        private void FirstCard_Click(object sender, EventArgs e)
        {
            clearCard();
            cardIndex = totalCards-1;
            curSide = 0;
            curCard = cardList[cardIndex];
            cid = curCard.cardID;
            objectList = selectLocalDB.getViewerObjects(cid);

            numSides = getNumSides(objectList);
            createCard(objectList);
            side.Text = "CardIndex: " + cardIndex + " Side: " + curSide;
            curSide++;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Navigation: \n First Card: Go to the first card in the deck. \n Last Card: Go to the last card in the deck. \n Next Card: Go to the next card in the deck.  \n Previous Card: Go to the previous card in deck. \n Flip Card: Go to the next side in the current card.  \n If it is the last side, Flip Card will go to the next card in the deck." , "Viewer Help", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }




    }
}
