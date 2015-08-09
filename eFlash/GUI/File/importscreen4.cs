using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using eFlash.FileImporter;
using eFlash.dbAccess;
using eFlash.Profile;
using eFlash.Data;

namespace eFlash.GUI.File
{
    public partial class importscreen4 : Form
    {
        private string filename = "";
        private string num_of_items = "";
        private char[] array_delimiter = new char[1];
    
        private ArrayList values;
        private ArrayList card_Format_for_values;
        private ArrayList Description_of_values;

        Form FirstForm; 
        Form previousForm;

        public importscreen4( Form orig_form, Form previousScreen, string fn, string num_items, char[] array_delim,
                             ArrayList vals, ArrayList card_Format, 
                              ArrayList desc_of_values)              
        {

            InitializeComponent();
            filename = fn;
            FirstForm = orig_form;
            previousForm = previousScreen;
            num_of_items = num_items;
            array_delimiter = array_delim;
    
            values = vals;
            card_Format_for_values = card_Format;
            Description_of_values = desc_of_values;
            
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            try
            {
                //"INSERT INTO Decks (cat,subcat,title,type,uid,nuid) VALUES (?cat,?subcat,?title,?type,?uid,?nuid)";
                //create deck Array of strings in the order of cat, subcat, title, uid, nuid
                if ((comboBox2.Text == "") || (txtbox_Category.Text == "") || (txtbox_title.Text == ""))
                {
                    MessageBox.Show("Please fill in the required fields.");
                    return;
                }
                string[] values1 = new string[6];
                int uid = ProfileManager.getCurrentUserID();
                
                int num = Convert.ToInt32(num_of_items);
                values1[0] = txtbox_Category.Text;
                values1[1] = txtbox_subcat.Text;
                values1[2] = txtbox_title.Text;
                values1[3] = comboBox2.Text;
                values1[4] = uid.ToString();
                values1[5] = null; //nuid
                int deck_id = insertLocalDB.insertToDecks(values1);
                
                if (deck_id != -1)
                {
                    Import imp = new Import(filename, num_of_items, array_delimiter,
                                            values, card_Format_for_values, Description_of_values,
                                            deck_id);
                    imp.ImportFile();
                    this.FirstForm.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Error inserting deck");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Visible = false;
        }

        private void importscreen4_FormClosed(object sender, FormClosedEventArgs e)
        {
            FirstForm.Show();
            this.Visible = false;
        }

        
        
    }
}