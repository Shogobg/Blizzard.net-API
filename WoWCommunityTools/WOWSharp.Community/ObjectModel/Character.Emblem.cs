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

using System;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Globalization;
#if !SILVERLIGHT
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
#endif

namespace WOWSharp.Community.ObjectModel
{
    /// <summary>
    /// Represents character profile information
    /// </summary>
    public partial class Character
    {
#if !SILVERLIGHT
        /// <summary>
        /// Saves the character's guild emblem to a stream in PNG format
        /// </summary>
        /// <param name="stream">stream to which the tabard should be saved</param>
        /// <param name="width">image width</param>
        /// <param name="height">image height</param>
        public void SaveGuildTabardImage(Stream stream, int width, int height)
        {
            IAsyncResult result = BeginGenerateTabardImage(width, height, null, null);
            ApiAsyncResult<GenerateImageState> imageAsyncResult = (ApiAsyncResult<GenerateImageState>)result;
            GenerateImageState state = imageAsyncResult.EndProcessing(this.Client);
            System.Windows.Media.Color?[] color = {
                                 null, 
                                 null, 
                                 (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#"+ this.Guild.Emblem.BackgroundColor),
                                 //null,
                                 (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#"+ this.Guild.Emblem.BorderColor),
                                 (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#"+ this.Guild.Emblem.IconColor),
                                 null,
                                 null
                             };
            RectangleF[] positions = {
                                   new RectangleF(0, 0, width * 216/240, height * 216/240),
                                   new RectangleF(width * 18/240, height * 27/240, width * 179/240, height * 216/240),
                                   new RectangleF(width * 18/240, height * 27/240, width * 179/240, height * 210/240),
                                   new RectangleF(width * 31/240, height * 40/240, width * 145/240, height * 159/240),
                                   new RectangleF(width * 33/240, height * 57/240, width * 125/240, height * 125/240),
                                   new RectangleF(width * 18/240, height * 27/240, width * 179/240, height * 32/240),
                               };
            // We use GDI+ and System.Drawing namespace here since WPF doesn't have an image encoder
            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics gr = Graphics.FromImage(bmp))
                {

                    for (int i = 0; i < state.Images.Length; i++)
                    {
                        using (MemoryStream ms = new MemoryStream(state.Images[i]))
                        {
                            Bitmap source = (Bitmap)Image.FromStream(ms);
                            if (color[i].HasValue)
                            {
                                double r = color[i].Value.R;
                                double g = color[i].Value.G;
                                double b = color[i].Value.B;
                                double intensityScale = 19;
                                double blend = 1.0 / 8;
                                double added_r = r / intensityScale + r * blend;
                                double added_g = g / intensityScale + g * blend;
                                double added_b = b / intensityScale + b * blend;
                                double scale_r = r / 255 + blend;
                                double scale_g = g / 255 + blend;
                                double scale_b = b / 255 + blend;
                                for (int x = 0; x < source.Width; x++)
                                {
                                    for (int y = 0; y < source.Height; y++)
                                    {
                                        System.Drawing.Color c = source.GetPixel(x, y);
                                        if (c.A != 0)
                                        {
                                            c = System.Drawing.Color.FromArgb(
                                                c.A,
                                                (byte)(c.R * scale_r + added_r),
                                                (byte)(c.G * scale_g + added_g),
                                                (byte)(c.B * scale_b + added_b));
                                            source.SetPixel(x, y, c);
                                        }
                                    }
                                }
                            }
                            gr.CompositingMode = CompositingMode.SourceOver;
                            gr.CompositingQuality = CompositingQuality.HighQuality;
                            gr.DrawImage(source, positions[i], new RectangleF(0, 0, source.Width, source.Height), GraphicsUnit.Pixel);
                        }
                    }
                }
                bmp.Save(stream, ImageFormat.Png);
            }
        }
#endif

        /// <summary>
        /// Begins an async operation to generate the tabard image
        /// </summary>
        /// <param name="width">Width of the tabard image</param>
        /// <param name="height">Height of the tabard image</param>
        /// <param name="callback">Call back method to call when the operation is completed</param>
        /// <param name="asyncState">user defined state</param>
        /// <returns>The status of the async operation</returns>
        public IAsyncResult BeginGenerateTabardImage(int width, int height, AsyncCallback callback, object asyncState)
        {
            ApiAsyncResult<GenerateImageState> imageAsyncResult = new ApiAsyncResult<GenerateImageState>(callback, asyncState, this.Client);
            if (this.Guild == null
                || this.Guild.Emblem == null
                || string.IsNullOrEmpty(this.Guild.Emblem.BackgroundColor)
                || string.IsNullOrEmpty(this.Guild.Emblem.IconColor)
                || string.IsNullOrEmpty(this.Guild.Emblem.BorderColor))
            {
                imageAsyncResult.SetComplete((GenerateImageState)null, true);
                return imageAsyncResult;
            }

            string path = "/wow/static/images/guild/tabards/";
            // sources
            string[] sources = 
            {
                path + "ring-" + EnumHelper<Faction>.EnumToString(this.Faction) + ".png",
                path + "shadow_00.png",
                path + "bg_00.png",
                path + "border_" + this.Guild.Emblem.Border.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + ".png",
                path + "emblem_" + this.Guild.Emblem.Icon.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + ".png",
                path + "hooks.png"
            };
            GenerateImageState gis = new GenerateImageState(sources.Length, width, height, imageAsyncResult);
            for (int i = 0; i < sources.Length; i++)
            {
                object[] state = { gis, i };
                Client.BeginRequest<byte[]>(sources[i], null, ImageCompletedCallback, state);
            }
            return imageAsyncResult;
        }


        /// <summary>
        /// Begins an async operation to generate the tabard image
        /// </summary>
        /// <param name="width">Width of the tabard image</param>
        /// <param name="height">Height of the tabard image</param>
        /// <param name="callback">Call back method to call when the operation is completed</param>
        /// <param name="asyncState">user defined state</param>
        /// <returns>The status of the async operation</returns>
        public BitmapSource EndGenerateTabardImage(IAsyncResult result)
        {
            ApiAsyncResult<GenerateImageState> imageAsyncResult = (ApiAsyncResult<GenerateImageState>)result;
            GenerateImageState state = imageAsyncResult.EndProcessing(this.Client);
            if (state == null)
                return null;
            double width = state.Width;
            double height = state.Height;
            System.Windows.Media.Color?[] color = {
                                 null, 
                                 null, 
                                 (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#"+ this.Guild.Emblem.BackgroundColor),
                                 //null,
                                 (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#"+ this.Guild.Emblem.BorderColor),
                                 (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#"+ this.Guild.Emblem.IconColor),
                                 null,
                                 null
                             };
            Rect[] positions = {
                                   new Rect(0, 0, width * 216/240, height * 216/240),
                                   new Rect(width * 18/240, height * 27/240, width * 179/240, height * 216/240),
                                   new Rect(width * 18/240, height * 27/240, width * 179/240, height * 210/240),
                                   new Rect(width * 31/240, height * 40/240, width * 145/240, height * 159/240),
                                   new Rect(width * 33/240, height * 57/240, width * 125/240, height * 125/240),
                                   new Rect(width * 18/240, height * 27/240, width * 179/240, height * 32/240),
                               };

#if SILVERLIGHT
            WriteableBitmap bmp = new WriteableBitmap((int)width, (int)height);
#else
            WriteableBitmap bmp = new WriteableBitmap((int)width, (int)height, 300, 300, PixelFormats.Pbgra32, null);
#endif
            for (int i = 0; i < state.Images.Length; i++)
            {

                using (MemoryStream ms = new MemoryStream(state.Images[i]))
                {
                    BitmapImage downloadedImage = new BitmapImage();
#if SILVERLIGHT
                    downloadedImage.SetSource(ms);
#else
                    downloadedImage.BeginInit();
                    downloadedImage.CacheOption = BitmapCacheOption.OnLoad;
                    downloadedImage.StreamSource = ms;
                    downloadedImage.EndInit();
#endif
                    WriteableBitmap source = new WriteableBitmap(downloadedImage);
                    if (color[i].HasValue)
                    {
                        double r = color[i].Value.R;
                        double g = color[i].Value.G;
                        double b = color[i].Value.B;
                        double intensityScale = 19;
                        double blend = 1.0 / 8;
                        double added_r = r / intensityScale + r * blend;
                        double added_g = g / intensityScale + g * blend;
                        double added_b = b / intensityScale + b * blend;
                        double scale_r = r / 255 + blend;
                        double scale_g = g / 255 + blend;
                        double scale_b = b / 255 + blend;
                        source.ForEach((x, y, c) =>
                        {
                            if (c.A != 0)
                            {
                                return System.Windows.Media.Color.FromArgb(
                                    c.A,
                                    (byte)(c.R * scale_r + added_r),
                                    (byte)(c.G * scale_g + added_g),
                                    (byte)(c.B * scale_b + added_b));
                            }
                            return c;

                        });
                    }
                    bmp.Blit(positions[i], source, new Rect(0, 0, source.PixelWidth, source.PixelHeight));
                }

            }
            return bmp;
        }

        /// <summary>
        /// Boxes and wraps the number of images finished
        /// </summary>
        private class GenerateImageState
        {
            public GenerateImageState(int numberOfSources, int width, int height, ApiAsyncResult<GenerateImageState> result)
            {
                DownloadCount = numberOfSources;
                Width = width;
                Height = height;
                Images = new byte[numberOfSources][];
                AsyncResult = result;
            }

            /// <summary>
            /// The number of images downloaded
            /// </summary>
            public int DownloadCount;

            /// <summary>
            /// The content of downloaded images
            /// </summary>
            public readonly byte[][] Images;

            /// <summary>
            /// The async result
            /// </summary>
            public readonly ApiAsyncResult<GenerateImageState> AsyncResult;

            /// <summary>
            /// Image width
            /// </summary>
            public readonly int Width;

            /// <summary>
            /// Image height
            /// </summary>
            public readonly int Height;
        }

        /// <summary>
        /// Callback when the client finishes downloading a static image
        /// </summary>
        /// <param name="httpAsyncResult">status of the image download async operation</param>
        private void ImageCompletedCallback(IAsyncResult httpAsyncResult)
        {
            // Get state
            object[] state = (object[])httpAsyncResult.AsyncState;
            GenerateImageState gis = (GenerateImageState)state[0];
            int currentImage = (int)state[1];
            try
            {
                // Get the downloaded image
                byte[] imageContent = Client.EndRequest<byte[]>(httpAsyncResult);
                gis.Images[currentImage] = imageContent;
                if (Interlocked.Decrement(ref gis.DownloadCount) == 0)
                {
                    gis.AsyncResult.SetComplete(gis, false);
                }
            }
            catch (Exception ex)
            {
                ApiAsyncResult<WriteableBitmap> imageAsyncResult = (ApiAsyncResult<WriteableBitmap>)state[0];
                imageAsyncResult.SetComplete(ex, false);
            }
        }
    }
}
