using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using eFlash.dbAccess;
using eFlash.Data;

namespace eFlash.GUI.ViewerAndQuizzer
{
    public partial class MC : Form
    {
        int current_index = 0;
        int correct = 0;

        string wrongList = " ";
        int correctposition;
        bool isplaying = false;

        String[] choice = new string[4];
        String correctAnswer = null;

        int totalCards;
        int deck_id ; //Pass From Outside  
        // for testing did =5 for image tester did=6 for texttester

        List<Card> cardList;
        int num = 0;
        List<string> answer;
        List<string> question;
        string output ,output2= null;
        String quizType = null;
        Player quizPlayer = new Player();

		public bool loaded;

        public MC(int did,string order)
        {
            List<List<string>> result;
            InitializeComponent();
            deck_id = did;
            cardList = selectLocalDB.getCards(deck_id);

        //set card parameters
        totalCards = cardList.Count;

        if (totalCards < 4)
        {
            MessageBox.Show(" Can't do MC Quiz because there are less than 4 cards in this Deck");
            loaded = false;
			return;
        }
		else
		{
			loaded = true;
		}


        //set card parameters
        totalCards = cardList.Count;
        quizType = Quiz.getType(cardList);

        answer = Quiz.getAnswer(cardList);
        question = Quiz.getQuestion(cardList);


        if (order == Constant.QuizRandomOrder)
        {
            result = Quiz.shuffle(answer, question);
            answer = result[0];
            question = result[1];
        }
        else if (order == Constant.QuizRerversedOrder)
        {
            answer.Reverse(0, answer.Count);
            question.Reverse(0, question.Count);
        }
            /*
        foreach (string str in answer)
            output = output + " " + str;
        MessageBox.Show(output);


        foreach (string str in question)
            output2 = output2 + " " + str;
        MessageBox.Show(output2);
        */
        this.next();
        }




        int[] generateRandom4(int number)
        {  int [] array = new int[4];
           int temp = 0;
            Random rand = new Random();
            array [0]=rand.Next(number);
            temp = rand.Next(number);

            while(temp == array[0])
               temp = rand.Next(number);
            array[1]=temp;

            while (temp == array[0]||temp==array[1])
                temp = rand.Next(number);
            array[2] = temp;


            while (temp == array[0] || temp == array[1]||temp==array[2])
                temp = rand.Next(number);
            array[3] = temp;

        return array;
        }




        private void next()
        {
            RichTextBox temp = new RichTextBox();
            TextBox temp2 = new TextBox();
            
            int [] indexRand=generateRandom4(totalCards); 
            Boolean done=false;
            Random rand=new Random();

            if (current_index == totalCards )
            {
                if (wrongList.Length == 1)
                    MessageBox.Show("PERFECT  ^_^ all  " + totalCards +" questions correct");
                else
                MessageBox.Show("End!  you got "+ correct.ToString() +"\n\nwords incorrect: " +  wrongList);
                quizPlayer.Close();
                this.Close();
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    choice[i] = answer[indexRand[i]];
                    if (indexRand[i] == current_index)
                    {
                        correctposition = i;
                        temp.LoadFile(Constant.ePath + choice[correctposition], RichTextBoxStreamType.RichText);
                        //temp.ToString
                        correctAnswer = temp.Text;
                       // MessageBox.Show(temp.Text);
                        done = true;
                    }
                }

                if (!done)
                {
               
                    correctposition = rand.Next(100) % 4;
                    //MessageBox.Show("here "+correctposition.ToString());
                    choice[correctposition] = answer[current_index];


                    temp.LoadFile(Constant.ePath + choice[correctposition], RichTextBoxStreamType.RichText);
                    correctAnswer = temp.Text;
                    //MessageBox.Show(temp.Text);


                }
                //////// now the answer is in the correction position and 3 random choice is made//////


                richTextBox1.Text = makeRTBtext(choice[0]);
                richTextBox2.Text = makeRTBtext(choice[1]);
                richTextBox3.Text = makeRTBtext(choice[2]);
                richTextBox4.Text = makeRTBtext(choice[3]);

                ////////////////////// answers is displayed/////////////////////


                if (quizType == Constant.imageDeck)
                {   pictureBox1.Visible=true;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap MyImage = new Bitmap(Constant.ePath + question[current_index]);
                    pictureBox1.Image = (Image)MyImage;
                    label1.Text="Q "+ (current_index+1).ToString() +": What is name of the picture?";
                    
                }
                else if (quizType == Constant.soundDeck)
                {    
                    button5.Visible=true;
                    quizPlayer.Close();
                    isplaying = false;
                    quizPlayer.Open(Constant.ePath + question[current_index]);
                    label1.Text= "Q "+(current_index+1).ToString() + ": What is the name of this Song?";
                }
                else
                {   label1.Visible = false;
                    richTextBox5.Visible=true;
                    richTextBox5.Text=makeRTBtext(question[current_index]);
                    richTextBox5.Text = "Q " + (current_index + 1).ToString() + " What is the definition of :" + richTextBox5.Text; 
                    //label1.Text=" What is the definitiin?";

                }

                current_index++;
           }
        }

        public string makeRTBtext(string filename)
        {
            RichTextBox temp = new RichTextBox();
            temp.LoadFile(Constant.ePath + filename, RichTextBoxStreamType.RichText);
            return temp.Text;

        }


        public string RandomWord() {
            
            Random random = new Random();
            num = random.Next(0, totalCards);
             return answer[num];
            //return null;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(correctposition.ToString());
            if (correctposition == 0)
                correct++;
            else wrongList += "\n" + correctAnswer;
            next();
        }

        private void button2_Click(object sender, EventArgs e)
        {
              if (correctposition == 1)
                  correct++;
              else wrongList += "\n" +  correctAnswer;
                next();
        }


        private void button3_Click(object sender, EventArgs e)
        {
           if (correctposition == 2)
                correct++;
            else wrongList += "\n" + correctAnswer;
            //pictureBox1.ImageLocation = "C:/flip.bmp";
            next();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (correctposition == 3)
                correct++;
            else wrongList += "\n" + correctAnswer;
              next();
        }

        private void MC_Load(object sender, EventArgs e)
        {

        }

        public void MC_FormClosed(object sender, FormClosedEventArgs e)
        {
            quizPlayer.Close();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (isplaying)
            {
                quizPlayer.Close();
                button5.Text = "Stop";
                isplaying = false;
            }
            else
            {
                quizPlayer.Open(Constant.ePath + answer[current_index-1]);
                quizPlayer.Play(true);
                isplaying = true;
                button5.Text = "Play";
            }

        }



    }
}