//  Dll Module		Interop Entry Points in various Dlls
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
using System.Runtime.InteropServices;

namespace eFlash.Utilities
{

	/// <summary>
	/// GDI32 dll access
	/// </summary>
	public class GDI32
	{
		public const int SRCCOPY = 13369376;

		[DllImport("gdi32.dll", EntryPoint="DeleteDC")]
		public static extern IntPtr DeleteDC(IntPtr hDc);

		[DllImport("gdi32.dll", EntryPoint="DeleteObject")]
		public static extern IntPtr DeleteObject(IntPtr hDc);

		[DllImport("gdi32.dll", EntryPoint="BitBlt")]
		public static extern bool BitBlt(IntPtr hdcDest,int xDest,
			int yDest,int wDest,int hDest,IntPtr hdcSource,
			int xSrc,int ySrc,int RasterOp);

		[DllImport("gdi32.dll", EntryPoint="CreateCompatibleBitmap")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc,
			int nWidth, int nHeight);

		[DllImport("gdi32.dll", EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll", EntryPoint="SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc,IntPtr bmp);
	}													// end class GDI32

	/// <summary>
	/// USER32 dll access
	/// </summary>
	public class USER32
	{
		public const int SM_CXSCREEN=0;
		public const int SM_CYSCREEN=1;

		[DllImport("user32.dll", EntryPoint="GetDesktopWindow")]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll",EntryPoint="GetDC")]
		public static extern IntPtr GetDC(IntPtr ptr);

		[DllImport("user32.dll",EntryPoint="GetSystemMetrics")]
		public static extern int GetSystemMetrics(int abc);

		[DllImport("user32.dll",EntryPoint="GetWindowDC")]
		public static extern IntPtr GetWindowDC(Int32 ptr);

		[DllImport("user32.dll",EntryPoint="ReleaseDC")]
		public static extern IntPtr ReleaseDC(IntPtr hWnd,IntPtr hDc);
	}													// end class USER32
}														// end namespace Dll
