using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eFlash.Network;
using eFlash.dbAccess;
using eFlash.Profile;

namespace eFlash.GUI.Network
{
    public partial class welcome : Form
    {
        int uid;
        int nuid;
        Form mainScreen;
        Form profileScreen;

        public welcome(Form mainScreen, Form profileScreen)
        {
            //Assume uid must be > -1 and valid
            uid = ProfileManager.getCurrentUserID();
            nuid = ProfileManager.getCurrentNetID();
            this.profileScreen = profileScreen;
            this.mainScreen = mainScreen;
            InitializeComponent();
        }

        private void Download_Click(object sender, EventArgs e)
        {            
            new eFlash.GUI.Network.DownloadBrowser(uid, nuid, this, mainScreen).Show();
            this.Visible = false;
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            new eFlash.GUI.Network.UploadBrowser(uid, nuid, this, mainScreen).Show();
            this.Visible = false;
        }

        private void Rank_Click(object sender, EventArgs e)
        {
            new eFlash.GUI.Network.RankerBrowser(uid, nuid, this, mainScreen).Show();
            this.Visible = false;
        }

        private void welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            mainScreen.Visible = true;
        }

        private void switchProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            profileScreen.Visible = true;
         }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainScreen.Close();          
        }

        private void signOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void downloadDecksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new eFlash.GUI.Network.DownloadBrowser(uid, nuid, this, mainScreen).Show();
            this.Visible = false;
        }

        private void uploadDecksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new eFlash.GUI.Network.UploadBrowser(uid, nuid, this, mainScreen).Show();
            this.Visible = false;
        }

        private void rankDecksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new eFlash.GUI.Network.RankerBrowser(uid, nuid, this, mainScreen).Show();
            this.Visible = false;
        }

     




    }
}