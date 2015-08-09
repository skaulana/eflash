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
    public partial class FillinTheBlank : Form
    {

        string s;
        string t;
        string[] word = new string[50];
        string[] def = new string[50];
        int correct = 0, incorrect = 0;
        int current_index = 0;

        string wrongList = " ";
        bool isplaying = false;

        String[] choice = new string[4];
        String correctAnswer = null;

        int totalCards;
        int deck_id = 6; //Pass From Outside  
        // for testing did =5 for image tester did=6 for texttester

        List<Card> cardList;
        List<string> answer;
        List<string> question;

        string output,output2 = null;
        String quizType = null;
        Player quizPlayer = new Player();

        
        public FillinTheBlank(int did, string order)
        {
            List<List<string>> result;
            InitializeComponent();
            deck_id = did;
            cardList = selectLocalDB.getCards(deck_id);

            //set card parameters
            totalCards = cardList.Count;
            quizType = Quiz.getType(cardList);

            answer = Quiz.getAnswer(cardList);
            question = Quiz.getQuestion(cardList);


            if (order == Constant.QuizRandomOrder)
            {   result = Quiz.shuffle(answer, question);
                answer = result[0];
                question = result[1];
            }
            else if (order == Constant.QuizRerversedOrder)
            { 
                answer.Reverse(0,answer.Count);
                question.Reverse(0,question.Count);
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

        private void Next_Click(object sender, EventArgs e)
        {
            this.next();
            
        }



        private void next()
        {
            RichTextBox temp = new RichTextBox();

            if (current_index == totalCards)
            {
                if (wrongList.Length == 1)
                    MessageBox.Show("PERFECT");
                else
                    MessageBox.Show(" Quiz End!! correct = " + correct + "\nWords Incorrect:" + wrongList);
                quizPlayer.Close();
                this.Close();
            }
            else
            {
                if (current_index > 0)
                {
                    temp.LoadFile(Constant.ePath + answer[current_index-1], RichTextBoxStreamType.RichText);
                    correctAnswer = temp.Text;


                    if (wordEqual(textBox1.Text, correctAnswer))
                    {
                        correct++;
                        //MessageBox.Show(word[index] + "==" + textBox1.Text);
                    }
                }

                textBox1.Text = "";
                if (quizType == Constant.imageDeck)
                {
                    pictureBox1.Visible = true;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap MyImage = new Bitmap(Constant.ePath + question[current_index]);
                    pictureBox1.Image = (Image)MyImage;
                    label1.Text = "Q " + (current_index + 1).ToString() + ": What is name of the picture?";

                }
                else if (quizType == Constant.soundDeck)
                {
                    button1.Visible = true;
                    button1.Text = "Play";
                    quizPlayer.Close();
                    isplaying = false;
                    quizPlayer.Open(Constant.ePath + question[current_index]);
                    label1.Text = "Q " + (current_index + 1).ToString() + ": What is the name of this Song?";
                }
                else
                {
                    label1.Visible = false;
                    richTextBox1.Visible = true;
                    richTextBox1.Text =  makeRTBtext(question[current_index]);
                    richTextBox1.Text = "Q " + (current_index + 1).ToString() + " What word means :  \n"  + richTextBox1.Text;
                    //label1.Text=" What is the definition?";

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



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void FillinTheBlank_Load(object sender, EventArgs e)
        {

        }




        private Boolean wordEqual(String input, String answer)
        {
            //MessageBox.Show(answer + " " + input);
            string str1, str2;
            str1 = input.Replace(" ", "");
            str2 = answer.Replace(" ", "");
            int result = string.Compare(str1, str2, true);
           // MessageBox.Show(result+ "  " + str1  + "   " +str2 );
            if (result == 0)
            {
                return true;
            }
            else
            {
                wrongList += "\n" + answer;
                return false;
            }
         }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public void FillinTheBlank_FormClosed(object sender, FormClosedEventArgs e)
        {
            quizPlayer.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (isplaying)
            {
                quizPlayer.Close();
                button1.Text = "Stop";
                isplaying = false;
            }
            else
            {
                quizPlayer.Open(Constant.ePath + answer[current_index - 1]);
                quizPlayer.Play(true);
                isplaying = true;
                button1.Text = "Play";
            }

        }

    }
}