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
    public partial class UploadBrowser : Form
    {

        eFlash.Network.Browser brwApp;
        Form mainScreen;
        Form welcome;

        public UploadBrowser(int uid, int nuid, Form welcome, Form mainScreen)
        {
            this.mainScreen = mainScreen;
            this.welcome = welcome;
            brwApp = new eFlash.Network.Browser(uid, nuid);
            InitializeComponent();
        }

        private void browser_Load(object sender, EventArgs e)
        {
           fillLocal();
           fillRemote();
        }

        private void fillLocal()
        {
            try
            {
                localTree.Nodes.Clear();
                localTree.Nodes.Add(brwApp.getLocalDeckTree());
                localTree.ExpandAll();
              }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + " has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillRemote()
        {
            try
            {
                remoteTree.Nodes.Clear();
                remoteTree.Nodes.Add(brwApp.getUserRemoteDeckTree());
                remoteTree.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + " has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
  


        private void UploadDeck_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = localTree.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode != localTree.TopNode)
            {
                brwApp.upload(Convert.ToInt32(selectedNode.Name));

                fillRemote();
            }
            else
            {
                MessageBox.Show("Please choose a valid deck to upload.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void BackToNetwork_Click(object sender, EventArgs e)
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

        private void RemoveLocalDeck_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = localTree.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode != localTree.TopNode)
            {
                if (MessageBox.Show("Are you sure you want to remove " + selectedNode.Text + "?",
                    "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == DialogResult.OK)
                    brwApp.delLocal(Convert.ToInt32(selectedNode.Name));

                fillLocal();
            }

        }

        private void RemoveRemoteDeck_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = remoteTree.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode != remoteTree.TopNode)
            {
                if (MessageBox.Show("Are you sure you want to remove " + selectedNode.Text + "?",
                   "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                   == DialogResult.OK)
                    brwApp.delRemote(Convert.ToInt32(selectedNode.Name));

                fillRemote();
            }
        }

        private void UploadBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(welcome != null)
                welcome.Visible = true;
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            Bitmap preview;
            eFlash.Data.Deck deck;
            TreeNode selectedNode = localTree.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode != localTree.TopNode)
            {
                deck = brwApp.getDeck(Convert.ToInt32(selectedNode.Name));

                label5.Text = "Category: " + deck.category;
                label4.Text = "Title: " + deck.title;

                if (deck.subcategory != null)
                {
                    label6.Text = "Sub-Category: " + deck.subcategory;
                }
                else
                {
                    label6.Text = "Sub-Category: " + "none";
                }

                preview = deck.loadPreview();

                pictureBox1.Image = preview;

            }
            else
            {
                MessageBox.Show("Please choose a valid deck to preview.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
           
            pictureBox1.Image = null;
            browser_Load(sender, e);
        }


      
      
    }
}