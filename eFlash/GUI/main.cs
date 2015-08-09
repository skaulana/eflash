using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using eFlash.Data;
using eFlash.GUI.Templates;
using eFlash.dbAccess;
using eFlash.GUI.ViewerAndQuizzer;

namespace eFlash.GUI
{
    public partial class main : Form
    {
        Form profileScreen;
        eFlash.Network.Browser localBrowser;

        public main(Form profileWindow)
        {
            InitializeComponent();

            profileScreen = profileWindow;
            localBrowser = new eFlash.Network.Browser(eFlash.Profile.ProfileManager.getCurrentUserID());
            
            listSet.SetMain(this);

            this.label_welcome.Text = "Welcome, " + eFlash.Profile.ProfileManager.getCurrentUserName() + ".  What would you like to learn today?";

			// Initialize templates
			Templates.Template.initTemplates();
        }

        /// <summary>
        /// Every time main becomes active, refresh deck tree.
        /// </summary>
        private void main_VisibleChanged(object sender, EventArgs e)
        {
            button_edit.Enabled = false;
            button_view.Enabled = false;
            button_quiz.Enabled = false;
            button_del.Enabled = false;
            button_export.Enabled = false;

            manageToolStripMenuItem.Enabled = false;
            learnToolStripMenuItem.Enabled = false;

            //display tree list of decks on local
            fillTree();
            //make sure List Set user control is on top
            listSet.BringToFront();
        }

        /// <summary>
        /// Go back to profile-selection screen
        /// </summary>
        private void switchProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            profileScreen.Show();
        }

        /// <summary>
        /// Exit eFlash entirely.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Create new deck using creator.
        /// </summary>
        private void button_create_Click(object sender, EventArgs e)
        {
            new eFlash.GUI.Creator.LayoutEditor(this, null).Show();
            this.Hide();
        }

        /// <summary>
        /// Create new deck using creator.
        /// </summary>
        private void newDeckWithCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_create_Click(sender, e);
        }

        /// <summary>
        /// Import new deck from file with Import Wizard.
        /// </summary>
        private void button_import_Click(object sender, EventArgs e)
        {
            new eFlash.GUI.File.importscreen(this).Show();
            this.Hide();
        }

        /// <summary>
        /// Import new deck from file with Import Wizard.
        /// </summary>
        private void importDeckFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_import_Click(sender, e);
        }

        /// <summary>
        /// Edit selected deck using creator.
        /// </summary>
        private void button_edit_Click(object sender, EventArgs e)
		{
			//select deck
			TreeNode selectedNode = treeView_localdecks.SelectedNode;

			// Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode.Text != "Available Decks")
            {
                eFlash.Data.Deck deck = localBrowser.getDeck(Convert.ToInt32(selectedNode.Name));

                if (eFlash.Profile.ProfileManager.getCurrentUserID() == localBrowser.getDeckOwnerID(Convert.ToInt32(selectedNode.Name)))
                {
                    new eFlash.GUI.Creator.LayoutEditor(this, deck).Show();
                    this.Hide();
                }
                else
                {
					string deckOwner = dbAccess.selectLocalDB.getUserName(deck.uid);
                    if (MessageBox.Show("This deck belongs to " + deckOwner + ", so you cannot edit it directly. However, you may create your own copy and edit that one instead. Would you like to create a copy now?", "Deck belongs to another user", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						// Make deep copy of deck inside LayoutEditor
						new eFlash.GUI.Creator.LayoutEditor(this, deck, true).Show();
						this.Hide();
					}
                }
            }
        }

        /// <summary>
        /// Edit selected deck using creator.
        /// </summary>
        private void editDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_edit_Click(sender, e);
        }

        /// <summary>
        /// Delete selected deck from local database.
        /// </summary>
        private void button_del_Click(object sender, EventArgs e)
        {
            //remove deck
            TreeNode selectedNode = treeView_localdecks.SelectedNode;

            // Is the selected node a deck?
            if (selectedNode != null && selectedNode.LastNode == null && selectedNode.Text != "Available Decks")
            {
                if (eFlash.Profile.ProfileManager.getCurrentUserID() == localBrowser.getDeckOwnerID(Convert.ToInt32(selectedNode.Name)))
                {
                    if (MessageBox.Show("Are you sure you want to remove " + selectedNode.Text + "?",
                        "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                        == DialogResult.OK)
                    {
                        localBrowser.delLocal(Convert.ToInt32(selectedNode.Name));
                        //refresh tree list
                        fillTree();
                    }
                }
                else
                    MessageBox.Show("Because you didn't create deck " + selectedNode.Text + ",\nyou do not have delete permission.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete selected deck from local database.
        /// </summary>
        private void deleteDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_del_Click(sender, e);
        }

        /// <summary>
        /// View selected deck in viewer-mode.
        /// </summary>
        private void button_view_Click(object sender, EventArgs e)
        {
            //select deck
            TreeNode selectedNode = treeView_localdecks.SelectedNode;

            if (selectedNode != null && selectedNode.LastNode == null && selectedNode.Text != "Available Decks")
            {
                eFlash.Data.Deck deck = localBrowser.getDeck(Convert.ToInt32(selectedNode.Name));

                //open viewer, pass certain deck

                Form temp = new eFlash.GUI.ViewerAndQuizzer.Viewer(this, deck.id);
                temp.Show();
                if (ViewerAndQuizzer.Viewer.emptyDeckError)
                {
                    ViewerAndQuizzer.Viewer.emptyDeckError = false;
                    temp.Close();
                    return;
                }
              //  new eFlash.GUI.ViewerAndQuizzer.Viewer(this, deck).Show();
                this.Hide();
            }
        }

        /// <summary>
        /// View selected deck in viewer-mode.
        /// </summary>
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_view_Click(sender, e);
        }

        /// <summary>
        /// Run quizzing on selected deck.
        /// </summary>
        private void button_quiz_Click(object sender, EventArgs e)
        {
            //select deck
            TreeNode selectedNode = treeView_localdecks.SelectedNode;

            if (selectedNode != null && selectedNode.LastNode == null && selectedNode.Text != "Available Decks")
            {
                eFlash.Data.Deck deck = localBrowser.getDeck(Convert.ToInt32(selectedNode.Name));

				List<Card> cardList = selectLocalDB.getCards(deck.id);

				List<string> answer = Quiz.getAnswer(cardList);
				List<string> question = Quiz.getQuestion(cardList);

				if (question.Count == 0 || answer.Count == 0)
				{
					MessageBox.Show("This deck does not support quizzing.");
					return;
				}

               // if (!(deck.type == Constant.noQuizDeck))
                //{
                    new eFlash.GUI.ViewerAndQuizzer.Form1(this, deck.id).Show();
                    //          new eFlash.GUI.ViewerAndQuizzer.Form1(this, 5).Show();
                    this.Hide();
              //}
            }
        }

        /// <summary>
        /// Run quizzing on selected deck.
        /// </summary>
        private void quizOnDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_quiz_Click(sender, e);
        }

        /// <summary>
        /// Export deck to power-point slides in eFlash directory.
        /// </summary>
        private void button_export_Click(object sender, EventArgs e)
        {
            //select deck
            TreeNode selectedNode = treeView_localdecks.SelectedNode;

            if (selectedNode != null && selectedNode.LastNode == null && selectedNode.Text != "Available Decks")
            {
                eFlash.Data.Deck deck = localBrowser.getDeck(Convert.ToInt32(selectedNode.Name));

                //do ppt export here
                new GUI.File.exportScreen(deck.id).Hide();
            }
            
        }

        /// <summary>
        /// Export deck to power-point slides in eFlash directory.
        /// </summary>
        private void exportToPowerPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_export_Click(sender, e);
        }

        /// <summary>
        /// Go to eFlash Networking Screens.
        /// </summary>
        private void button_net_Click(object sender, EventArgs e)
        {
            if(eFlash.Profile.ProfileManager.getCurrentNetID() == -1)
                eFlash.Profile.ProfileManager.generateNewNUID();

            new eFlash.GUI.Network.welcome(this,profileScreen).Show();
            this.Hide();
        }

        /// <summary>
        /// Go to eFlash Networking Screens.
        /// </summary>
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_net_Click(sender, e);
        }

        /// <summary>
        /// Display Auto-generated help.
        /// </summary>
        private void mainMenuHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The main menu of eFlash allows you to access all of your flash card decks.\n\nThink of a deck as a stack of flash cards, much like in real life. A list of them is displayed in the white box that fills the left side of the screen. To perform actions on your decks, use the icons on the right hand side of the screen. You can hover your mouse over any of these icons to see a brief explanation about what it does.\n\nSome of the icons will only become available after you have selected a specific deck from the list of available decks. To do this, simply click the name of the deck in the list, then push the icon of the action you want to perform on the deck. If you are ever confused as to the function of a certain button or feature, you can always hover your mouse over it to see a tooltip explaining its use.",
                "Using the Main Menu", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            MessageBox.Show("Note that decks are intimately connected to your user profile. Though the main deck display will show all decks on your machine, regardless of who created them, only you may edit and delete decks you have created. If a deck does not belong to you it will be grayed out in the deck list, and you will be unable to delete it. You also cannot edit someone else's deck directly, but you may be prompted to create a copy (that you will become the owner of) to edit.",
                "Deck Ownership", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Display About Information.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new eFlash.GUI.About().Show();
        }

        /// <summary>
        /// Fills Deck Tree.
        /// </summary>
        public void fillTree()
        {
            try
            {
                treeView_localdecks.Nodes.Clear();
                treeView_localdecks.Nodes.Add(localBrowser.getLocalDeckTree(eFlash.Profile.ProfileManager.getCurrentUserID(), (int) listSet.vmode));
                treeView_localdecks.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + " has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //treeView_localdecks.Refresh();
            treeView_localdecks.Update();
        }

        /// <summary>
        /// On main window close, shuts down program.
        /// </summary>
		private void main_FormClosed(object sender, FormClosedEventArgs e)
		{
			profileScreen.Close();
		}

        private void treeView_localdecks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //select deck
            TreeNode selectedNode = treeView_localdecks.SelectedNode;

            if (selectedNode != null && selectedNode.LastNode == null && selectedNode.Text != "Available Decks")
            {
                button_edit.Enabled = true;
                button_view.Enabled = true;

                eFlash.Data.Deck deck = localBrowser.getDeck(Convert.ToInt32(selectedNode.Name));

                if (deck.type == "noQuiz")
                    button_quiz.Enabled = false;
                else
                    button_quiz.Enabled = true;

                if (selectedNode.ForeColor == Color.Gray)
                    button_del.Enabled = false;
                else
                    button_del.Enabled = true;

                button_export.Enabled = true;

                manageToolStripMenuItem.Enabled = true;
                learnToolStripMenuItem.Enabled = true;
            }
            else
            {
                button_edit.Enabled = false;
                button_view.Enabled = false;
                button_quiz.Enabled = false;
                button_del.Enabled = false;
                button_export.Enabled = false;

                manageToolStripMenuItem.Enabled = false;
                learnToolStripMenuItem.Enabled = false;
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void exportDeckToPowerPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_export_Click(sender, e);
        }
    }
}
