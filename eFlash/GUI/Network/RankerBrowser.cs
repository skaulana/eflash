using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using eFlash.Data;

namespace eFlash.GUI.Network
{
    public partial class RankerBrowser : Form
    {

        eFlash.Network.Browser brwApp;
        Form mainScreen;
        Form welcome;
        int rank = 0;

        public RankerBrowser(int uid, int nuid, Form welcome, Form mainScreen)
        {
            this.mainScreen = mainScreen;
            this.welcome = welcome;
            brwApp = new eFlash.Network.Browser(uid, nuid);
            InitializeComponent();
        }

        private void browser_Load(object sender, EventArgs e)
        {
           fillLocal();
        }

        private void RankerBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (welcome != null)
                welcome.Visible = true;
        }

        private void fillLocal()
        {
            try
            {
                localTree.Nodes.Clear();
                localTree.Nodes.Add(brwApp.getLocalUnrankedDeckTree());
                localTree.ExpandAll();
              }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + " has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label2.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";

            browser_Load(sender, e);
        }

    
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            rank = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            rank = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            rank = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            rank = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            rank = 5;
        }


        private void BackToNetwork_Click_1(object sender, EventArgs e)
        {
            welcome.Visible = true;
            this.Close();
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            welcome = null;
            mainScreen.Visible = true;
            this.Close();
        }

        private void rankRemote_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = localTree.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode != localTree.TopNode)
            {
                if (rank != 0)
                {
                    brwApp.uploadRank(Convert.ToInt32(selectedNode.Name), rank);
                }
                else
                {
                    MessageBox.Show("Please choose a rank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                fillLocal();
            }
            else 
            {
                MessageBox.Show("Please choose a valid unranked deck.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            Bitmap preview;
            TreeNode selectedNode = localTree.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode != localTree.TopNode)
            {
                netDeck ndeck = brwApp.downloadRankerPreview(Convert.ToInt32(selectedNode.Name));
                label2.Text = ndeck.category;
                label7.Text = ndeck.title;
                if (ndeck.subcategory != null)
                {
                    label8.Text = ndeck.subcategory;
                }
                else
                {
                    label8.Text = "none";
                }
                label9.Text = "" + ndeck.rat;

                preview = ndeck.preview;

                pictureBox1.Image = preview;
            }
            else
            {
                MessageBox.Show("Please choose a valid unranked deck.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
          
    }
}