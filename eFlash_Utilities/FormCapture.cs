using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace eFlash.Utilities
{
    public class FormCapture
    {      

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
            IntPtr hdcDest, // handle to destination DC
            int nXDest,  // x-coord of destination upper-left corner
            int nYDest,  // y-coord of destination upper-left corner
            int nWidth,  // width of destination rectangle
            int nHeight, // height of destination rectangle
            IntPtr hdcSrc,  // handle to source DC
            int nXSrc,   // x-coordinate of source upper-left corner
            int nYSrc,   // y-coordinate of source upper-left corner
            System.Int32 dwRop  // raster operation code
            );

        public static void capture(Form form)
        {
            Graphics g1 = form.CreateGraphics();
            Image MyImage = new Bitmap(form.ClientRectangle.Width, form.ClientRectangle.Height, g1);
            Graphics g2 = Graphics.FromImage(MyImage);
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, form.ClientRectangle.Width, form.ClientRectangle.Height, dc1, 0, 0, 13369376);
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);
            MyImage.Save(@"c:\Captured.jpg", ImageFormat.Jpeg);
            MessageBox.Show("Finished Saving Image");
        }
    }
}