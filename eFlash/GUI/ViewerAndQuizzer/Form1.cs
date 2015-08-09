using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace eFlash.GUI.ViewerAndQuizzer
{
    public partial class Form1 : Form
    {
        public String test = "wewerwe";
        public int correct = 0;
        public int wrong = 0;
        public int choice = 0;
        public int deck_id = 0;


        main prevWin;

        public Form1(main newPrevWin, int did)
        {
            InitializeComponent();
            //radioButton1.Click();
            deck_id = did;
            radioButton1.Checked = true;
      

            prevWin = newPrevWin;   //to return to main menu after done quizzing
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void close()
        {
            prevWin.Show();
            this.close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
               new eFlash.GUI.ViewerAndQuizzer.HonestQuiz(deck_id,Constant.QuizInOrder).Show();
            else if (radioButton3.Checked)
               new eFlash.GUI.ViewerAndQuizzer.HonestQuiz(deck_id, Constant.QuizRerversedOrder).Show();
            else if (radioButton4.Checked)
               new eFlash.GUI.ViewerAndQuizzer.HonestQuiz(deck_id, Constant.QuizRandomOrder).Show();

            //this.Close();     //DANIEL COMMENTED THIS OUT - CAN'T CLOSE UNTIL DONE QUIZZING OR RETURNS TO MAIN MENU
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed()
        {
            prevWin.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                new eFlash.GUI.ViewerAndQuizzer.FillinTheBlank(deck_id, Constant.QuizInOrder).Show();
            else if (radioButton3.Checked)
                new eFlash.GUI.ViewerAndQuizzer.FillinTheBlank(deck_id, Constant.QuizRerversedOrder).Show();
            else if (radioButton4.Checked)
                new eFlash.GUI.ViewerAndQuizzer.FillinTheBlank(deck_id, Constant.QuizRandomOrder).Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
			MC mcWindow = null;
            if (radioButton1.Checked)
                mcWindow = new eFlash.GUI.ViewerAndQuizzer.MC(deck_id, Constant.QuizInOrder);
            else if (radioButton3.Checked)
				mcWindow = new eFlash.GUI.ViewerAndQuizzer.MC(deck_id, Constant.QuizRerversedOrder);
            else if (radioButton4.Checked)
				mcWindow = new eFlash.GUI.ViewerAndQuizzer.MC(deck_id, Constant.QuizRandomOrder);

			if (mcWindow.loaded)
			{
				mcWindow.Show();
			}
			else
			{
				mcWindow.Dispose();
			}
        }

    }
}