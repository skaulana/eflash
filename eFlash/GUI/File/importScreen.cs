using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eFlash.FileImporter;

namespace eFlash.GUI.File
{
    

    public partial class importscreen : Form
    {
        private int deck_id = 0;
        Form previousForm;

        public importscreen(Form previousScreen)
        {
            InitializeComponent();
            previousForm = previousScreen;
        }

        public importscreen(Form previousScreen, int did)
        {
            InitializeComponent();
            previousForm = previousScreen;
            deck_id = did;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            MessageBox.Show("This importer wizard excepts files that have a delimited format of" +
                " words and their definitions, and picture/sound titles and their filepaths." +
                "These words are assumed to be written in this format: {term}{definition1}{definition2}" +
                "or {picture title}{picture filepath}, with all of them being separated by delimiters such as ','" +
                 " '.'.");
            linkLabel1.LinkVisited = true;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
           
           
           openFileDialog1.InitialDirectory = "c:\\";
          
           openFileDialog1.Filter = "txt files (*.txt)|*.txt";
           openFileDialog1.FilterIndex = 1;
           openFileDialog1.RestoreDirectory = true;

           openFileDialog1.ShowDialog();
           
           this.txtBox_Browse.Text = openFileDialog1.FileName;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBox_Browse.Text == "")
                {
                    MessageBox.Show("Fill in the required field.");
                    return;
                }
                    importscreen2 imp_screen2 = new importscreen2(previousForm, this, txtBox_Browse.Text,
                                                                  comboBox_noItems.Text,
                                                                  comboBox_delimiter.Text, deck_id);

                    imp_screen2.Show();
                    this.Visible = false;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Visible = false;
        }

        private void importscreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm.Show();
            this.Visible = false;
        }
       

    }
}