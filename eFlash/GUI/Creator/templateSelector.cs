using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using eFlash.GUI.Templates;

namespace eFlash.GUI.Creator
{
	public partial class TemplateSelector : UserControl
	{
		private const int OBJ_WIDTH = 60;
		private const int OBJ_HEIGHT = 40;

		private LayoutEditor creator;

		public string quizType;

		private List<Template> templates;
		private List<Button> buttons;

		private TemplateSelector() : this(null, Constant.textDeck) { }

		public TemplateSelector(LayoutEditor newCreator, string newQuizType)
		{
			templates = new List<Template>();
			buttons = new List<Button>();

			creator = newCreator;
			quizType = newQuizType;

			InitializeComponent();
			
			Button curButton;
			Bitmap bg;
			foreach (Template curTemplate in Template.templates[quizType])
			{
				templates.Add(curTemplate);
				
				curButton = new Button();

				bg = makeImage(curTemplate);

				curButton.Size = bg.Size;
				curButton.BackgroundImageLayout = ImageLayout.Stretch;
				curButton.BackgroundImage = bg;
				curButton.Margin = new Padding(0, 0, 0, 0);
				curButton.Text = "";
				curButton.FlatStyle = FlatStyle.Standard;
				curButton.Click += new EventHandler(curButton_Click);
				toolTip.SetToolTip(curButton, "Click to apply this template to the current flashcard");

				buttons.Add(curButton);
				panelTemplates.Controls.Add(curButton);
			}

			RichTextBox legend = new RichTextBox();
			legend.BorderStyle = BorderStyle.None;
			legend.ReadOnly = true;
			legend.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset2 Wingdings;}{\\f1\\fswiss\\fprq2\\fcharset0 Arial;}{\\f2\\fswiss\\fcharset0 Arial;}}\n{\\colortbl ;\\red0\\green120\\blue0;\\red0\\green0\\blue0;\\red255\\green0\\blue0;}\n{\\*\\generator Msftedit 5.41.15.1507;}\\viewkind4\\uc1\\pard\\cf1\\f0\\fs24 n\\cf0\\f1\\fs16  \\cf2 Answer\\cf0\\par\n\\cf3\\f0\\fs24 n\\cf0\\f1\\fs16  \\cf2 Question\\cf0\\f2\\fs20\\par\n}";
			panelTemplates.Controls.Add(legend);

			if (creator.deck.cardList.Count == 0)
			{
				buttons[0].PerformClick();
			}
		}

		private Bitmap makeImage(Template template)
		{
			Bitmap bmp;

			Panel panel = new Panel();
			Panel panel0 = new Panel();
			Panel panel1 = new Panel();
			Label label0 = new Label();
			Label label1 = new Label();

			panel.Size = new Size(OBJ_WIDTH, OBJ_HEIGHT);
			panel.BorderStyle = BorderStyle.None;
			panel.BackColor = Color.Black;
			panel.Margin = new Padding(0, 0, 0, 0);
			panel.Location = new Point(0, 0);

			panel0.Size = new Size(OBJ_WIDTH, OBJ_HEIGHT);
			panel0.BorderStyle = BorderStyle.None;
			panel0.BackColor = Color.White;
			panel0.Margin = new Padding(0, 0, 0, 0);
			panel0.Location = new Point(0, 0);

			panel1.Size = new Size(OBJ_WIDTH, OBJ_HEIGHT);
			panel1.BorderStyle = BorderStyle.None;
			panel1.BackColor = Color.White;
			panel1.Margin = new Padding(0, 0, 0, 0);
			panel1.Location = new Point(0, 0);

			label0.Margin = new Padding(0, 0, 0, 0);
			label0.Padding = new Padding(0, 0, 0, 0);
			label0.Location = new Point(1, 1);
			label0.Size = new Size(10, 10);
			label0.BackColor = Color.White;
			label0.Font = new Font(FontFamily.GenericSansSerif, 6);
			label0.Text = "1";

			label1.Margin = new Padding(0, 0, 0, 0);
			label1.Padding = new Padding(0, 0, 0, 0);
			label1.Location = new Point(1, 1);
			label1.Size = new Size(10, 10);
			label1.BackColor = Color.White;
			label1.Font = new Font(FontFamily.GenericSansSerif, 6);
			label1.Text = "2";

			Panel curBmpObj;
			bool hasSide2 = false;

			foreach (TemplateObject curObj in template.objects)
			{
				curBmpObj = new Panel();
				if (curObj.quizType == Constant.answerPrefix)
				{
					curBmpObj.BackColor = Color.Green;
				}
				else if (curObj.quizType == Constant.questionPrefix)
				{
					curBmpObj.BackColor = Color.Red;
				}
				else
				{
					curBmpObj.BackColor = Color.Gray;
				}
				curBmpObj.BorderStyle = BorderStyle.FixedSingle;
				curBmpObj.Location = new Point(Convert.ToInt32(curObj.x1 / 100.0 * OBJ_WIDTH), Convert.ToInt32(curObj.y1 / 100.0 * OBJ_HEIGHT));
				curBmpObj.Size = new Size(Convert.ToInt32((curObj.x2 - curObj.x1) / 100.0 * OBJ_WIDTH), Convert.ToInt32((curObj.y2 - curObj.y1) / 100.0 * OBJ_HEIGHT));

				if (curObj.side == 0)
				{
					panel0.Controls.Add(curBmpObj);
				}
				else if (curObj.side == 1)
				{
					panel1.Controls.Add(curBmpObj);
					hasSide2 = true;
				}
			}

			panel0.Controls.Add(label0);
			panel1.Controls.Add(label1);

			if (hasSide2)
			{
				panel.Height = (OBJ_HEIGHT * 2) + 1;
				panel1.Location = new Point(0, OBJ_HEIGHT + 1);
				panel.Controls.Add(panel1);
			}

			panel.Controls.Add(panel0);

			bmp = new Bitmap(panel.Width, panel.Height);
			panel.DrawToBitmap(bmp, new Rectangle(0, 0, panel.Width, panel.Height));

			return bmp;
		}

		private void realignWithPanel()
		{
			panelTemplates.Location = new Point(0, 0);
			this.Size = panelTemplates.Size;
		}

		#region Event handlers

		void curButton_Click(object sender, EventArgs e)
		{
			if (creator.changed || creator.promptAtTemplateChange)
			{
				if (MessageBox.Show("Changing the template will overwrite all existing flashcard content. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					return;
				}
			}

			int i;

			// Find index of event sender
			for (i = 0; i < templates.Count; i++)
			{
				if (buttons[i] == sender)
				{
					break;
				}
			}
			
			for (int j = 0; j < buttons.Count; j++)
			{
				if (j == i)
				{
					buttons[j].FlatStyle = FlatStyle.Popup;
				}
				else
				{
					buttons[j].FlatStyle = FlatStyle.Standard;
				}
			}

			Template selectedTemplate = templates[i];

			creator.loadTemplate(selectedTemplate);
		}

		private void TemplateSelector_SizeChanged(object sender, EventArgs e)
		{
			realignWithPanel();
		}

		private void panelTemplates_ControlAdded(object sender, ControlEventArgs e)
		{
			realignWithPanel();
		}

		private void panelTemplates_ControlRemoved(object sender, ControlEventArgs e)
		{
			realignWithPanel();
		}

		#endregion
	}
}
