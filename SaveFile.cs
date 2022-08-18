using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;

namespace Counter_Wpf
{
    class SaveFile
    {
        /// <summary>
        /// Sorts through data to save  
        /// </summary>
        /// <param name="fileName">User selected file name</param>
        /// <param name="allCatagories">List of all catagories</param>
        /// <param name="activeCatagories">The currently active catagory</param>
        public void SavePhoto(string fileName, List<Catagories> allCatagories, string imageUrl, Canvas myCanvas, bool saveOverlay)
        {
            // Get xml
            string xml = CreateXml(allCatagories);

            // Alter .exif
            var source = BitmapFrame.Create(new Uri(imageUrl));
            var metadata = (BitmapMetadata)source.Metadata;


            var daClone = source.Clone();   // Make clone so I can edit things
            BitmapMetadata cloneMeta;
            if (metadata == null)
            {
                cloneMeta = new BitmapMetadata("jpg");   // Make new metadata
            }
            else
            {
                cloneMeta = metadata.Clone();   // Make clone of metadata
            }



            cloneMeta.Comment = xml;

            var bmp = new WriteableBitmap(daClone);
            bmp.Lock();
            // magick
            bmp.Unlock();


            //BmpBitmapEncoder encoder = new BmpBitmapEncoder(); // No meta data?
            var encoder = new JpegBitmapEncoder();

            if (saveOverlay)    // Save photo with points overlayed
            {
                // render InkCanvas' visual tree to the RenderTargetBitmap
                double calculatedHeight = (source.Height / source.Width) * myCanvas.ActualWidth;
                RenderTargetBitmap targetBitmap =
                    new RenderTargetBitmap((int)myCanvas.ActualWidth,
                                           (int)calculatedHeight,
                                           96d, 96d,
                                           PixelFormats.Default);
                targetBitmap.Render(myCanvas);

                // add the RenderTargetBitmap to a Bitmapencoder

                encoder.Frames.Add(BitmapFrame.Create(targetBitmap));
            }



            var target = BitmapFrame.Create(bmp, null, cloneMeta, null); // here
            encoder.Frames.Add(target);
            using (var stream = File.OpenWrite(fileName))
            {
                encoder.Save(stream);
            }

        }

        /// <summary>
        /// Creates a .xml string to save
        /// </summary>
        /// <param name="allCatagories"></param>
        /// <returns></returns>
        private string CreateXml(List<Catagories> allCatagories)
        {
            string header = $"<objects count='{allCatagories.Count}'>\n";

            // Add each object
            foreach (var catagory in allCatagories)
            {
                // Compile Points
                string stringPoints = "";
                foreach (var point in catagory.Locations)
                {
                    stringPoints += point.X.ToString() + "," + point.Y.ToString() + "\n";
                }

                string objectXml = $"<object>\n" +
                    $"<index>{catagory.Index}</index>\n" +
                    $"<name>{catagory.Name}</name>\n" +
                    $"<count>{catagory.Count}</count>\n" +
                    $"<locations>{stringPoints}</locations>\n" +
                    $"<color>{catagory.Color}</color>\n" +
                    $"<active>{catagory.Active}</active>\n" +
                    $"</object>\n\n";

                header += objectXml;
            }

            // Compile .exif stuff
            string xml = header + "</objects>";
            return xml;
        }


    }
}
