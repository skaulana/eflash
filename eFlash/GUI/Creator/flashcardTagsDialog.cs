using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eFlash.GUI.Creator
{
	public partial class FlashcardTagsDialog : Form
	{
		LayoutEditor caller;

		public FlashcardTagsDialog(LayoutEditor newCaller)
		{
			InitializeComponent();

			caller = newCaller;

			lblInheritedTags.Text = caller.deck.category;
				
			if (!caller.deck.subcategory.Equals(""))
			{
				lblInheritedTags.Text += "," + caller.deck.subcategory;
			}

			txtTags.Text = caller.currentCard.tag;
		}

		#region Button click handlers

		private void btnOk_Click(object sender, EventArgs e)
		{
			caller.currentCard.tag = txtTags.Text;
			caller.changed = true;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion

		#region Accessors

		public string tags
		{
			get { return txtTags.Text; }
		}

		#endregion
	}
}