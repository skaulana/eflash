using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using eFlash.FileImporter;

namespace eFlash.GUI.File
{
    public partial class importscreen5 : Form
    {
        private string filename = "";
        private string num_of_items = "";
        private char[] array_delimiter = new char[1];
        private int deck_id;
        private ArrayList values;
        private ArrayList card_Format_for_values;
        private ArrayList Description_of_values;
        Form previousForm;
        Form FirstForm; 
        public importscreen5(Form orig_form, Form previousScreen, string fn, string num_items, char[] array_delim,
                             ArrayList vals, ArrayList card_Format,
                              ArrayList desc_of_values, int did)
        {
            InitializeComponent();
            FirstForm = orig_form;
            previousForm = previousScreen;
            filename = fn;
            num_of_items = num_items;
            array_delimiter = array_delim;
            deck_id = did;
            values = vals;
            card_Format_for_values = card_Format;
            Description_of_values = desc_of_values;
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            Import imp = new Import(filename, num_of_items, array_delimiter,
                                            values, card_Format_for_values, Description_of_values,
                                            deck_id);
            imp.ImportFile();
            this.FirstForm.Show();
            this.Visible = false;
            
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Visible = false;
        }
    }
}