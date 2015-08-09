using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eFlash.FileImporter;
using System.Collections;
using System.IO;

namespace eFlash.GUI.File
{
    public partial class importscreen2 : Form
    {

        private int deck_id = 0;
        private string filename = "";
        private string num_of_items = " ";
        private string delimiter = "";
        private char[] array_delimiter = new char[1];

        private ArrayList values;
        private ArrayList Description_of_values;
        private ArrayList card_Format_for_values;

        Form FirstForm; 
        Form previousForm; 
        
        public importscreen2(Form orig_form, Form previousScreen, string fn, string num_items, string delim, int did)
        {
            previousForm = previousScreen;
            FirstForm = orig_form;
            filename = fn;
            num_of_items = num_items;

            delimiter = delim;
            deck_id = did;
            InitializeComponent();
            updateDataGrid(fn, delim);
        }

        private void updateDataGrid(string fn, string delimiter)
        {
            try
            {
                StreamReader sr = new StreamReader(fn);
                string first_line = sr.ReadLine();
                
                array_delimiter[0] = delimiter[0];
                string[] array_first_line = first_line.Split(array_delimiter);

                
                dataGridView1.Rows.Add(array_first_line.Length);

                for (int i = 0; i < array_first_line.Length; i++)
                {

                    dataGridView1[0, i].Value = array_first_line[i];

                }

        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                int j = side_number.Items.Count;
                values = new ArrayList(); 
                Description_of_values = new ArrayList();
                card_Format_for_values = new ArrayList();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string val = (string) dataGridView1[0, i].Value;
                    string desc_of_val = (string)dataGridView1[1, i].Value;
                    string card_val = (string)dataGridView1[2, i].Value;
                    if ((val == null) || (desc_of_val == null) || (card_val == null))
                    {
                        MessageBox.Show("Please fill in all the fields in this grid.");
                        return;
                    }
                    values.Add(val); 
                    Description_of_values.Add(desc_of_val);
                    card_Format_for_values.Add(card_val);

                }
                if (deck_id == 0)
                {
                    importscreen4 imp = new importscreen4(FirstForm, this, filename, num_of_items, array_delimiter,
                                                          values, card_Format_for_values,
                                                          Description_of_values);
                    imp.Show();
                    this.Visible = false;
                }
                else
                {
                    importscreen5 imp = new importscreen5(FirstForm, this, filename, num_of_items, array_delimiter,
                                                          values, card_Format_for_values,
                                                          Description_of_values, deck_id);
                    imp.Show();
                    this.Visible = false;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("The importer wizard would like to know if you are importing" +
                " sound files, picture files, or just simple textual definitions.  Therefore " +
                "it is required that you tell us which term exactly is the picture/sound/word title" +
                " and which term is the data or soundfile");
            linkLabel1.LinkVisited = true;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Visible = false;
        }

        private void importscreen2_FormClosed(object sender, FormClosedEventArgs e)
        {
            FirstForm.Show();
            this.Visible = false;
        }


       
        
        
        
    }
}