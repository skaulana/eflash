//  Capture Module		Capture Utilities
//  Copyright ?003-2004 Excellence Foundation		Don@xfnd.org
//
//  This product is free software. You can redistribute it and/or modify it under the
//  terms of the Public Source Distribution License Agreement (PSDLA) as published by
//  Excellence Foundation.
//
//  This product is distributed in the hope it will be instructional and useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
//  FITNESS FOR A PARTICULAR PURPOSE. See the PSDLA for more details. You should have
//  received a copy of the PSDLA with this product. If not, browse
//  http://www.xfnd.org/licenses/PSDLA.doc.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace eFlash.Utilities
{
	/// <summary>
	/// The Capture class illustrates capturing bitmap images for the desktop and
	/// controls on the desktop. It uses window handle and context methods from 
	/// the dlls USER32 and GDI32.
	/// </summary>
	public class	Capture
	{
		private static int	m_HDelay = 5;				// ms delay time for control to disappear from screen
		
		/// <summary>
		/// Number of milliseconds to wait for control to disappear from screen
		/// when invisibility is requested. This is used when the specified
		/// capture area is under a control.
		/// </summary>
		public static int	HideDelay					// user acessible member
		{
			get{return m_HDelay;}
			set
			{
				if (value < 0)		m_HDelay = 0;		// delay minimally for other waiting theads to execute
				if (value > 1000)	m_HDelay = 1000;	// delay no more than 1 sec
				else				m_HDelay = value;	// delay the specified number of milliseconds
			}
		}

		public static Size	GetDesktopSize()
		{
			int		width = USER32.GetSystemMetrics(USER32.SM_CXSCREEN);	// width of desktop
			int		height = USER32.GetSystemMetrics(USER32.SM_CYSCREEN);	// height of desktop
			return new Size(width,height);
		}

		/// <summary>
		/// Captures the desktop to a bitmap image
		/// </summary>
		/// <returns>bitmap image of the desktop</returns>
		public static Bitmap	Desktop()
		{
			int		width = USER32.GetSystemMetrics(USER32.SM_CXSCREEN);	// width of desktop
			int		height = USER32.GetSystemMetrics(USER32.SM_CYSCREEN);	// height of desktop
			IntPtr	desktopHWND = USER32.GetDesktopWindow();				// window handle for desktop
			return	Window(desktopHWND,0,0,width,height);					// return bitmap for desktop
		}												// end method Desktop

		/// <summary>
		/// Captures the desktop work area to a bitmap image
		/// </summary>
		/// <returns>bitmap image of desktop work area</returns>
		public static Bitmap	DesktopWA(Control ctl)
		{
			Rectangle	wa = Screen.GetWorkingArea(ctl);				// working area of screen
			IntPtr	desktopHWND = USER32.GetDesktopWindow();			// window handle for desktop
			return	Window(desktopHWND,wa.X,wa.Y,wa.Width,wa.Height);	// return bitmap for desktop
		}												// end method DesktopWA

		/// <summary>
		/// Captures the control to a bitmap image. The entire control is
		/// captured including both the client and non-client areas.
		/// </summary>
		/// <param name="ctl">Control to capture</param>
		/// <returns>bitmap image of the control</returns>
		public static Bitmap	Control(System.Windows.Forms.Control ctl)
		{
			return Control(ctl,false,false);			// capture entire control
		}												// end method Control

		/// <summary>
		/// Captures the specified area of the control or whats underneath
		/// the control. If the argument flag client is true, only the client
		/// area of the control is captured, otherwise the entire control is 
		/// captured. If the argument flag under is true, the capture area under
		/// the control is captured, otherwise the specified area on the control
		/// is captured.
		/// </summary>
		/// <param name="ctl">Control to capture</param>
		/// <param name="client">If true capture only client area else entire control.</param>
		/// <param name="under">If true capture specified area underneath the control else whats on the control.</param>
		/// <returns>bitmap image of the control or whats underneath the control</returns>
		public static Bitmap	Control(System.Windows.Forms.Control ctl,bool client,bool under)
		{
			Bitmap		bmp;							// capture bitmap
			Rectangle	ctlR;							// capture area rectangle in control coordinates
			Rectangle	scrR;							// capture area rectangle in screen coordinates
			
			//	get capture rectangle in control
			//	coordinates and in screen coordinates
			if (client)									// if capturing client area
			{
				ctlR = ctl.ClientRectangle;				//   get rectangle in control coordinates
				scrR = ctl.RectangleToScreen(ctlR);		//   get rectangle in screen coordinates
			}
			else										// if capturing entire control
			{
				scrR = ctl.Bounds;						//   get rectangle in parent coordinates
				if (ctl.Parent != null)								//   if parent exists
					scrR = ctl.Parent.RectangleToScreen(scrR);		//     map to screen coordinates
				ctlR = ctl.RectangleToClient(scrR);					//   get rectangle in control coordinates
			}

			//	capture an area under the control
			if (under)									// if capture area is under control
			{
				bool	prvV = ctl.Visible;				//   save control visibility
				if (prvV)								//   if control visible
				{
					ctl.Visible = false;				//     make control invisible
					Thread.Sleep(m_HDelay);				//     allow time for control to become invisible
														//     prior to image capture
				}

				//	Capture the bitmap using desktop window handle and screen coordinates
				//	for the capture area. Note, the control window handle can NOT be used
				//  for capturing an area under the control.
				IntPtr	desktopHWND = USER32.GetDesktopWindow();	// get window handle for desktop
				bmp = Window(desktopHWND,scrR);						// get bitmap for capture area under control
				if (ctl.Visible != prvV)				//   if control visibility was changed
					ctl.Visible = prvV;					//     restore previous visibility
			}

			//	capture an area on the control
			else										// if capture area not under control
			{
				//	Capture the bitmap using control window handle and control coordinates
				//	for capture area.
				bmp = Window(ctl.Handle,ctlR);			//   get bitmap using control window handle
			}
			return bmp;									// return requested bitmap
		}												// end method Control

		/// <summary>
		/// Captures the specified window or part thereof to a bitmap image.
		/// </summary>
		/// <param name="handle">window handle</param>
		/// <param name="r">capture rectangle</param>
		/// <returns>bitmap image of the window</returns>
		public static Bitmap	Window(IntPtr handle,Rectangle r)
		{
			return Window(handle,r.X,r.Y,r.Width,r.Height);
		}

		/// <summary>
		/// Captures the window or part thereof to a bitmap image.
		/// </summary>
		/// <param name="wndHWND">window handle</param>
		/// <param name="x">x location in window</param>
		/// <param name="y">y location in window</param>
		/// <param name="width">width of capture area</param>
		/// <param name="height">height of capture area</param>
		/// <returns>window bitmap</returns>
		public static Bitmap	Window(IntPtr wndHWND, int x, int y, int width, int height)
		{
			IntPtr	wndHDC = USER32.GetDC(wndHWND);		// get context for window 

			//	create compatibile capture context and bitmap
			IntPtr	capHDC = GDI32.CreateCompatibleDC(wndHDC);	
			IntPtr	capBMP = GDI32.CreateCompatibleBitmap(wndHDC, width, height);

			//	make sure bitmap non-zero
			if (capBMP == IntPtr.Zero)					// if no compatible bitmap
			{
				USER32.ReleaseDC(wndHWND,wndHDC);		//   release window context
				GDI32.DeleteDC(capHDC);					//   delete capture context
				return null;							//   return null bitmap
			}

			//	select compatible bitmap in compatible context
			//	copy window context to compatible context
			//  select previous bitmap back into compatible context
			IntPtr	prvHDC = (IntPtr)GDI32.SelectObject(capHDC,capBMP); 
			GDI32.BitBlt(capHDC,0,0,width,height,wndHDC,x,y,GDI32.SRCCOPY); 
			GDI32.SelectObject(capHDC,prvHDC);
	
			//	create GDI+ bitmap for window
			Bitmap	bmp = System.Drawing.Image.FromHbitmap(capBMP); 
		
			//	release window and capture resources
			USER32.ReleaseDC(wndHWND,wndHDC);			// release window context
			GDI32.DeleteDC(capHDC);						// delete capture context
			GDI32.DeleteObject(capBMP);					// delete capture bitmap

			//	return bitmap image to user
			return bmp;									// return bitmap
		}

	}													// end class Capture
}														// end namespace Emxx
