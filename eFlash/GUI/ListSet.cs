using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace eFlash.GUI
{
    public partial class ListSet : UserControl
    {
        public enum ViewMode { Cat = 0, Alpha = 1, Time = 2 };

        private static Color COLOR_DOWN = Color.FromKnownColor(KnownColor.ControlLightLight);
		private static Color COLOR_UP = Color.FromKnownColor(KnownColor.Control);

		private ViewMode currentViewMode;

        private Form NestledIn;

        public ListSet()
        {
            InitializeComponent();

            currentViewMode = ViewMode.Cat;

            updateButtons();
        }

        public ListSet(Form newMain)
		{
			InitializeComponent();

			currentViewMode = ViewMode.Cat;

			updateButtons();

            NestledIn = newMain;
		}

        public void SetMain(Form newMain)
        {
            NestledIn = newMain;
        }

		private void updateButtons()
		{
			button_cat.BackColor = COLOR_UP;
            button_alpha.BackColor = COLOR_UP;
            button_time.BackColor = COLOR_UP;

			switch (vmode)
			{
				case ViewMode.Cat:
                    button_cat.BackColor = COLOR_DOWN;
					break;
				case ViewMode.Alpha:
                    button_alpha.BackColor = COLOR_DOWN;
					break;
				case ViewMode.Time:
                    button_time.BackColor = COLOR_DOWN;
					break;
				default:
					throw new Exception("ViewMode's internal state is corrupted");
			}
		}

		#region Button click handlers

		private void button_cat_Click(object sender, EventArgs e)
		{
			currentViewMode = ViewMode.Cat;
			updateButtons();
            ((main)NestledIn).fillTree();
		}

        private void button_alpha_Click(object sender, EventArgs e)
		{
            currentViewMode = ViewMode.Alpha;
			updateButtons();
            ((main)NestledIn).fillTree();
		}

        private void button_time_Click(object sender, EventArgs e)
		{
            currentViewMode = ViewMode.Time;
			updateButtons();
            ((main)NestledIn).fillTree();
		}

		#endregion

		#region Accessors

		public ViewMode vmode
		{
			get
			{
				return currentViewMode;
			}
			
			set
			{
				currentViewMode = value;

				updateButtons();
			}
		}

		#endregion
    }
}
