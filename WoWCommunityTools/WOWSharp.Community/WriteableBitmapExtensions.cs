/*
 Copyright (C) 2011 by Sherif Elmetainy (Grendizer@Doomhammer-EU)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

//   Blit and Foreach methods are taken from WriteableBitmapEx (http://writeablebitmapex.codeplex.com)
//   Copyright © 2009-2010 Bill Reiss, Rene Schulte and WriteableBitmapEx Contributors
//
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace WOWSharp.Community
{
    /// <summary>
    /// Writeable bitmap extensions
    /// </summary>
    internal static class WriteableBitmapExtensions
    {
        /// <summary>
        /// .NET doesn't have a Pixels property, so this is a work around where we use copypixels instead
        /// </summary>
        /// <param name="bmp">the bitmap to get pixels for</param>
        /// <returns>The pixels for the bitmap</returns>
        private static int[] GetPixels(this WriteableBitmap bmp)
        {
#if SILVERLIGHT
            return bmp.Pixels;
#else
            int[] pixels = new int[bmp.PixelWidth * bmp.PixelHeight];
            bmp.CopyPixels(pixels, bmp.PixelWidth * 4, 0);
            return pixels;
#endif
        }

        /// <summary>
        /// .NET doesn't have a Pixels property, so this is a work around where we use writepixels instead
        /// </summary>
        /// <param name="bmp">the bitmap to set pixels for</param>
        /// <param name="pixels">the pixels for the bitmap</param>
        private static void SetPixels(this WriteableBitmap bmp, int[] pixels)
        {
#if SILVERLIGHT
            // do nothing
#else
            bmp.WritePixels(new Int32Rect(0, 0, bmp.PixelWidth, bmp.PixelHeight),
                pixels, bmp.PixelWidth * 4, 0, 0);
#endif
        }


        /// <summary>
        /// Copies (blits) the pixels from the WriteableBitmap source to the destination WriteableBitmap (this).
        /// </summary>
        /// <param name="bmp">The destination WriteableBitmap.</param>
        /// <param name="destRect">The rectangle that defines the destination region.</param>
        /// <param name="source">The source WriteableBitmap.</param>
        /// <param name="sourceRect">The rectangle that will be copied from the source to the destination.</param>
        public static void Blit(this WriteableBitmap bmp, Rect destRect, WriteableBitmap source, Rect sourceRect)
        {
            int dw = (int)destRect.Width;
            int dh = (int)destRect.Height;
            int dpw = bmp.PixelWidth;
            int dph = bmp.PixelHeight;
            Rect intersect = new Rect(0, 0, dpw, dph);
            intersect.Intersect(destRect);
            if (intersect.IsEmpty)
            {
                return;
            }
            int sourceWidth = source.PixelWidth;

            int[] sourcePixels = source.GetPixels();
            int[] destPixels = bmp.GetPixels();
            int sourceLength = sourcePixels.Length;
            int destLength = destPixels.Length;
            int sourceIdx = -1;
            int px = (int)destRect.X;
            int py = (int)destRect.Y;
            int right = px + dw;
            int bottom = py + dh;
            int x;
            int y;
            int idx;
            double ii;
            double jj;
            int sr = 0;
            int sg = 0;
            int sb = 0;
            int dr, dg, db;
            int sourcePixel;
            int sa = 0;
            int da;
            var sw = (int)sourceRect.Width;
            var sdx = sourceRect.Width / destRect.Width;
            var sdy = sourceRect.Height / destRect.Height;
            int sourceStartX = (int)sourceRect.X;
            int sourceStartY = (int)sourceRect.Y;
            int lastii, lastjj;
            lastii = -1;
            lastjj = -1;
            jj = sourceStartY;
            y = py;
            for (int j = 0; j < dh; j++)
            {
                if (y >= 0 && y < dph)
                {
                    ii = sourceStartX;
                    idx = px + y * dpw;
                    x = px;
                    sourcePixel = sourcePixels[0];

                    // Pixel by pixel copying
                    for (int i = 0; i < dw; i++)
                    {
                        if (x >= 0 && x < dpw)
                        {
                            if ((int)ii != lastii || (int)jj != lastjj)
                            {
                                sourceIdx = (int)ii + (int)jj * sourceWidth;
                                if (sourceIdx >= 0 && sourceIdx < sourceLength)
                                {
                                    sourcePixel = sourcePixels[sourceIdx];
                                    sa = ((sourcePixel >> 24) & 0xff);
                                    sr = ((sourcePixel >> 16) & 0xff);
                                    sg = ((sourcePixel >> 8) & 0xff);
                                    sb = ((sourcePixel) & 0xff);
                                }
                                else
                                {
                                    sa = 0;
                                }
                            }
                            if (sa > 0)
                            {
                                int destPixel = destPixels[idx];
                                da = ((destPixel >> 24) & 0xff);
                                if ((sa == 255 || da == 0))
                                {
                                    destPixels[idx] = sourcePixel;
                                }
                                else
                                {
                                    dr = ((destPixel >> 16) & 0xff);
                                    dg = ((destPixel >> 8) & 0xff);
                                    db = ((destPixel) & 0xff);
                                    destPixel = ((sa + (((da * (255 - sa)) * 0x8081) >> 23)) << 24) |
                                                ((sr + (((dr * (255 - sa)) * 0x8081) >> 23)) << 16) |
                                                ((sg + (((dg * (255 - sa)) * 0x8081) >> 23)) << 8) |
                                                ((sb + (((db * (255 - sa)) * 0x8081) >> 23)));
                                    destPixels[idx] = destPixel;
                                }
                            }
                        }
                        x++;
                        idx++;
                        ii += sdx;
                    }
                }
                jj += sdy;
                y++;
            }
            bmp.SetPixels(destPixels);
        }

        /// <summary>
        /// Applies the given function to all the pixels of the bitmap in 
        /// order to set their color.
        /// </summary>
        /// <param name="bmp">The WriteableBitmap.</param>
        /// <param name="func">The function to apply. With parameters x, y, source color and a color as a result</param>
        public static void ForEach(this WriteableBitmap bmp, Func<int, int, Color, Color> func)
        {
            int[] pixels = bmp.GetPixels();
            int w = bmp.PixelWidth;
            int h = bmp.PixelHeight;
            int index = 0;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int c = pixels[index];
                    var color = func(x, y, Color.FromArgb((byte)(c >> 24), (byte)(c >> 16), (byte)(c >> 8), (byte)(c)));
                    // Add one to use mul and cheap bit shift for multiplicaltion
                    var a = color.A + 1;
                    pixels[index++] = (color.A << 24)
                                   | ((byte)((color.R * a) >> 8) << 16)
                                   | ((byte)((color.G * a) >> 8) << 8)
                                   | ((byte)((color.B * a) >> 8));
                }
            }
            bmp.SetPixels(pixels);
        }

    }
}
