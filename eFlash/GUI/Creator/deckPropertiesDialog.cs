using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using eFlash.Data;

namespace eFlash.GUI.Creator
{
	public partial class DeckPropertiesDialog : Form
	{
		private eFlash.Data.Deck deck;
		public bool saved;

		public DeckPropertiesDialog() : this(null, true) { }

		public DeckPropertiesDialog(eFlash.Data.Deck newDeck, bool changeType)
		{
			InitializeComponent();

			deck = newDeck;

			txtTitle.Text = deck.title;
			txtCategory.Text = deck.category;
			txtSubcategory.Text = deck.subcategory;

			grpType.Enabled = changeType;

			switch (deck.type)
			{
				case Constant.textDeck:
					rdText.Checked = true;
					break;
				case Constant.imageDeck:
					rdImage.Checked = true;
					break;
				case Constant.soundDeck:
					rdAudio.Checked = true;
					break;
				case Constant.noQuizDeck:
					rdNoQuiz.Checked = true;
					break;
			}

			saved = false;
		}

		#region Button click handlers

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (validate())
			{
				if (deck != null)
				{
					if (rdText.Checked)
					{
						deck.type = Constant.textDeck;
					}
					else if (rdImage.Checked)
					{
						deck.type = Constant.imageDeck;
					}
					else if (rdAudio.Checked)
					{
						deck.type = Constant.soundDeck;
					}
					else if (rdNoQuiz.Checked)
					{
						deck.type = Constant.noQuizDeck;
					}

					deck.title = txtTitle.Text;
					deck.category = txtCategory.Text;
					deck.subcategory = txtSubcategory.Text;

					saved = true;
				}

				this.Visible = false;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			saved = false;
			this.Visible = false;
		}

		#endregion

		private bool validate()
		{
			if (txtTitle.Text.Equals(""))
			{
				MessageBox.Show("Please enter a title.");
				txtTitle.Focus();
				return false;
			}
			else if (txtCategory.Text.Equals(""))
			{
				MessageBox.Show("Please enter a category.");
				txtCategory.Focus();
				return false;
			}

			if (!rdText.Checked && !rdImage.Checked && !rdAudio.Checked && !rdNoQuiz.Checked)
			{
				MessageBox.Show("Please select a deck quiz type");
				return false;
			}

			return true;
		}
	}
}

