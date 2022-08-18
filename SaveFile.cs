using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void SavePhoto(string fileName, List<Catagories> allCatagories, string imageUrl)
        {
            // Get xml
            string xml = CreateXml(allCatagories);

            // Alter .exif
            var source = BitmapFrame.Create(new Uri(imageUrl));
            var metadata = (BitmapMetadata)source.Metadata;

            var daClone = source.Clone();   // Make clone so I can edit things
            var cloneMeta = metadata.Clone();   // Make clone of metadata

            cloneMeta.Comment = xml;

            var bmp = new WriteableBitmap(daClone);
            bmp.Lock();
            // magick
            bmp.Unlock();

            var target = BitmapFrame.Create(bmp, null, cloneMeta, null); // here
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(target);
            using (var stream = File.OpenWrite(fileName))
            {
                encoder.Save(stream);
            }



            // Save to file
            //File.WriteAllText(fileName, xml);
            Console.WriteLine(xml);
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
