using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace eFlash.GUI.File
{
    public partial class importscreen3 : Form
    {
        private string filename = "";
        private string num_of_items = "";
        private string delimiter = "";
        private int deck_id = 0;
        private ArrayList values;
        private ArrayList card_Format_for_values;
        private ArrayList Description_of_values;
        private char[] array_delimiter = new char[1];


        public importscreen3(string fn, string num_items, string delim, 
                             int did, ArrayList Desc_of_values)
        {
            InitializeComponent();
            filename = fn;
            num_of_items = num_items;
            delimiter = delim;
            deck_id = did;
            Description_of_values = Desc_of_values;
           // updateDataGrid(fn, delim);

        }
        /*
        private void updateDataGrid(string fn, string delimiter)
        {
            try
            {
                StreamReader sr = new StreamReader(fn);
                string first_line = sr.ReadLine();
                
                array_delimiter[0] = Convert.ToChar(delimiter);
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

        private void btn_SaveDataGridValues_Click(object sender, EventArgs e)
        {
            try
            {
                 values = new ArrayList();
                 card_Format_for_values = new ArrayList();
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    values.Add(dataGridView1[0, i].Value);
                    card_Format_for_values.Add(dataGridView1[1, i].Value);
                }
                /*private string filename = "";
        private string num_of_items = "";
        private char[] array_delimiter = new char[1];
        private int deck_id = 0;
        private ArrayList values;
        private ArrayList card_Format_for_values;
        private ArrayList Description_of_values;
                 
                if (deck_id == 0)
                {
                    importscreen4 imp = new importscreen4(filename, num_of_items, array_delimiter,
                                                          values, card_Format_for_values,
                                                          Description_of_values);
                    imp.Show();
                }
                else
                {
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */
    }
}