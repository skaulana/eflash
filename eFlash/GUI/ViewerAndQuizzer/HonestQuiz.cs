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
    public partial class  HonestQuiz: Form
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
        int deck_id =6; //Pass From Outside  
        // for testing did =5 for image tester did=6 for texttester

        List<Card> cardList;
        List<string> answer;
        List<string> question;
        string output ,output2= null;
        String quizType = null;
        Player quizPlayer = new Player();



        public HonestQuiz(int did,string order)
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void next()
        {

            if (current_index == totalCards)
            {
                MessageBox.Show(" End correct = " + correct + " incorrect = " + incorrect);
                quizPlayer.Close();
                this.Close();
            }
            else {
                Answer_box.Visible = false;
                label4.Visible = false;

                if (quizType == Constant.imageDeck)
                {
                    pictureBox1.Visible = true;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap MyImage = new Bitmap(Constant.ePath + question[current_index]);
                    pictureBox1.Image = (Image)MyImage;
                    label3.Text = "Q " + (current_index + 1).ToString() + ": What is name of the picture?";

                }
                else if (quizType == Constant.soundDeck)
                {
                    button2.Visible = true;
                    quizPlayer.Close();
                    button2.Text = "Play";
                    isplaying=false;
                    quizPlayer.Open(Constant.ePath + question[current_index]);
                    label3.Text = "Q " + (current_index + 1).ToString() + ": What is the name of this Song?";
                }
                else
                {
                    label3.Visible = false;
                    quizPlayer.Close();
                    isplaying=false;
                    richTextBox1.Visible = true;
                    richTextBox1.Text = makeRTBtext(question[current_index]);
                    richTextBox1.Text = "Q " + (current_index + 1).ToString() + " What is the definition of :" + richTextBox1.Text;
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

        private void HonestQuiz_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isplaying)
            {
                quizPlayer.Close();
                button2.Text = "Stop";
                isplaying = false;
            }
            else
            {
                quizPlayer.Open(Constant.ePath + answer[current_index-1]);
                quizPlayer.Play(true);
                isplaying = true;
                button2.Text = "Play";
            }

        }


        public void HonestQuiz_FormClosed(object sender, FormClosedEventArgs e)
        {
            quizPlayer.Close();
        }


        private void correct_button_Click(object sender, EventArgs e)
        {
            correct++;
            this.next();
        }

        private void incorrect_button_Click(object sender, EventArgs e)
        {
            incorrect++;
            this.next();
        }

        private void answer_button_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            Answer_box.Visible = true;
            Answer_box.Text = makeRTBtext(answer[current_index-1]);


        }
    }
}