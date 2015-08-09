using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace eFlash.GUI.Creator
{
	public partial class AlignmentSelector : UserControl
	{
		private static Color COLOR_DOWN = Color.FromKnownColor(KnownColor.ControlLightLight);
		private static Color COLOR_UP = Color.FromKnownColor(KnownColor.Control);

		private HorizontalAlignment _currentAlignment;

		private LayoutEditor creator;

		public delegate void creatorEventHandler();
		public creatorEventHandler alignmentChangedHandler;

		public AlignmentSelector()
		{
			InitializeComponent();

			_currentAlignment = HorizontalAlignment.Left;

			updateButtons();

			alignmentChangedHandler = null;
		}

		public void setCreator(LayoutEditor newCreator)
		{
			creator = newCreator;
		}
		
		private void updateButtons()
		{
			btnLeft.BackColor = COLOR_UP;
			btnCenter.BackColor = COLOR_UP;
			btnRight.BackColor = COLOR_UP;

			switch (alignment)
			{
				case HorizontalAlignment.Left:
					btnLeft.BackColor = COLOR_DOWN;
					break;
				case HorizontalAlignment.Center:
					btnCenter.BackColor = COLOR_DOWN;
					break;
				case HorizontalAlignment.Right:
					btnRight.BackColor = COLOR_DOWN;
					break;
				default:
					throw new Exception("AlignmentSelector's internal state is corrupted");
			}
		}

		#region Button click handlers

		private void btnLeft_Click(object sender, EventArgs e)
		{
			_currentAlignment = HorizontalAlignment.Left;
			updateButtons();
			alignmentChangedHandler();
		}

		private void btnCenter_Click(object sender, EventArgs e)
		{
			_currentAlignment = HorizontalAlignment.Center;
			updateButtons();
			alignmentChangedHandler();
		}

		private void btnRight_Click(object sender, EventArgs e)
		{
			_currentAlignment = HorizontalAlignment.Right;
			updateButtons();
			alignmentChangedHandler();
		}

		#endregion

		#region Accessors

		public HorizontalAlignment alignment
		{
			get
			{
				return _currentAlignment;
			}
			
			set
			{
				_currentAlignment = value;

				updateButtons();
			}
		}

		#endregion
	}
}
