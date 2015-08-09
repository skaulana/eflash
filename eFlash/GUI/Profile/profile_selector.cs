using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFlash.GUI.Profile
{
    public partial class profile_selector : Form
    {
        private bool noloop;

        public profile_selector()
        {
            InitializeComponent();
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            int uid = -1;
            
            try //check user DB for authentication using comboBox_name && textBox_pw
            {
                uid = eFlash.dbAccess.selectLocalDB.getAuthdUserID(comboBox_name.Text, textBox_pw.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (uid != -1)
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete user profile: " + comboBox_name.Text, "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try //attempt to delete user comboBox_name && textBox_pw
                    {
                        eFlash.dbAccess.deleteLocalDB.deleteUser(uid);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error has occurred: " + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("To delete this profile, please enter the password.",
                           "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //repopulate profile list
            List<string> users = eFlash.Profile.ProfileManager.getUsers();
            int numusers = 0;
            comboBox_name.Items.Clear();
            foreach (string user in users)
                numusers++;
            if (numusers != 0)
            {
                comboBox_name.Text = users[0];
                comboBox_name.Items.AddRange(users.ToArray());
                comboBox_name_SelectedIndexChanged(sender, e);
            }
            else
                comboBox_name.Text = ""; ;
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            noloop = false;
            if (comboBox_name.Text == "")
            {
                MessageBox.Show("Please enter your desired profile name and click \'Create User\'");
                noloop = true;  //this changed to prevent loop of warnings
            }
            else
            {
                try //attempt to create user comboBox_name && textBox_pw
                {
                    eFlash.dbAccess.insertLocalDB.insertToUser(comboBox_name.Text.ToLower(), textBox_pw.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occurred: " + ex.Message,
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //repopulate profile list
                List<string> users = eFlash.Profile.ProfileManager.getUsers();
                int numusers = 0;
                comboBox_name.Items.Clear();
                foreach (string user in users)
                    numusers++;
                if (numusers != 0)
                    comboBox_name.Items.AddRange(users.ToArray());
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            int uid = -1;

            try //check user DB for authentication using comboBox_name && textBox_pw
            {
                uid = eFlash.dbAccess.selectLocalDB.getAuthdUserID(comboBox_name.Text.ToLower(), textBox_pw.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (uid != -1)
            {
                eFlash.Profile.ProfileManager.setCurrentUser(uid, comboBox_name.Text.ToLower());

                try //attempt to save login settings
                {
                    eFlash.dbAccess.updateLocalDB.updateLoginSettings(checkBox_savepw.Checked, checkBox_autolog.Checked);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occurred: " + ex.Message,
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                new eFlash.GUI.main(this).Show();
                this.Hide();
            }
            else
            {
                if (comboBox_name.Items.Contains(comboBox_name.Text))
                    MessageBox.Show("Invalid login/password; either try again or create a new profile",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    button_create_Click(sender, e);
                    //this is ugly, but basically it prevents an infinite loop of warnings
                    if(!noloop)
                        button_login_Click(sender, e);
                }
            }
        }

        private void comboBox_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            string settings = "";
            textBox_pw.Text = "";
            checkBox_savepw.Checked = false;
            checkBox_autolog.Checked = false;

            try //check user DB for settings of newly selected comboBox_name
            {
                if(comboBox_name.Text != "")
                    settings = eFlash.dbAccess.selectLocalDB.getSettings(comboBox_name.Text.ToLower());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (settings == "save_pw" || settings == "auto-log")
            {
                string pw = "";
                checkBox_savepw.Checked = true;

                try //gets user pw
                {
                    pw = eFlash.dbAccess.selectLocalDB.getPW(comboBox_name.Text.ToLower());
                    textBox_pw.Text = pw;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has occurred: " + ex.Message,
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (settings == "auto-log")
                {
                    checkBox_autolog.Checked = true;
                    button_login_Click(sender, e);
                }
            }


        }

        private void profile_selector_Activated(object sender, EventArgs e)
        {
            //populate profile list
            List<string> users = eFlash.Profile.ProfileManager.getUsers();
            int numusers=0;
            comboBox_name.Items.Clear();
            foreach(string user in users)
                numusers++;
            if (numusers != 0)
            {
                comboBox_name.Text = users[0];
                comboBox_name.Items.AddRange(users.ToArray());
                comboBox_name_SelectedIndexChanged(sender, e);
            }
            else
                comboBox_name.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void profile_selector_Load(object sender, EventArgs e)
        {

        }

        private void label_profile_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}