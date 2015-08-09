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
    public partial class DownloadBrowser : Form
    {

        eFlash.Network.Browser brwApp;
        Form mainScreen;
        Form welcome;

        public DownloadBrowser(int uid, int nuid, Form welcome, Form mainScreen)
        {
            this.mainScreen = mainScreen;
            this.welcome = welcome;
            brwApp = new eFlash.Network.Browser(uid, nuid);
            InitializeComponent();
        }

        private void browser_Load(object sender, EventArgs e)
        {        
           fillRemote();
        }

     

        private void fillRemote()
        {
            try
            {
                remoteTree.Nodes.Clear();
                remoteTree.Nodes.Add(brwApp.getRemoteDeckTree());
                remoteTree.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + " has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadDeck_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = remoteTree.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode != remoteTree.TopNode)
            {
                brwApp.download(Convert.ToInt32(selectedNode.Name));
            }
            else
            {
                MessageBox.Show("Please choose a valid deck to download.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            welcome = null;
            mainScreen.Visible = true;
            this.Close();
        }

        private void BackToNetwork_Click(object sender, EventArgs e)
        {
            welcome.Visible = true;
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";

            pictureBox1.Image = null;
            browser_Load(sender, e);
        }

        private void DownloadBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (welcome != null)
                welcome.Visible = true;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (SearchOption.SelectedItem == null)
                return;

            try
            {
                remoteTree.Nodes.Clear();
                remoteTree.Nodes.Add(brwApp.search(SearchBox.Text, SearchOption.SelectedItem.ToString()));
                remoteTree.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + " has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==  '\r')
                Search_Click(sender, e);
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            Bitmap preview;
            netDeck ndeck;
            TreeNode selectedNode = remoteTree.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode != remoteTree.TopNode)
            {
                ndeck = brwApp.downloadPreview(Convert.ToInt32(selectedNode.Name));

                label5.Text = "Category: " + ndeck.category;
                label4.Text = "Title: " + ndeck.title;

                if (ndeck.subcategory != null)
                {
                    label6.Text = "Sub-Category: " + ndeck.subcategory;
                }
                else
                {
                    label6.Text = "Sub-Category: " + "none";
                }
                label3.Text = "Rank: " + ndeck.rat;

                preview = ndeck.preview;

                pictureBox1.Image = preview;
            }
            else
            {
                MessageBox.Show("Please choose a valid deck to preview.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

     

       
      
      
    }
}