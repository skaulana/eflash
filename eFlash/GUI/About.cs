using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using eFlash.Utilities;

namespace eFlash.GUI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string f = AppHelper.GetPresentWorkingDirectory() + "\\License.rtf";

            if (System.IO.File.Exists(f))
            {
                Process.Start(f);
            }
            else
            {
                MessageBox.Show("Your license file could not be found.\n\nThis may indicate that you have obtained an unofficial or corrupt version of eFlash.\nContact your software distributor for more information, or reinstall eFlash.",
                    "License Missing", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}