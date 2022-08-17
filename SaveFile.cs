using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void SavePhoto(string fileName, List<Catagories> allCatagories, Catagories activeCatagory)
        {
            // Compile .exif stuff
            string xml = "";
            string header = $"<objects count='{allCatagories.Count}'";




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
                    $"<active>{catagory.Active}</active>\n " +
                    $"</object>\n\n";

                header += objectXml;
            }

            xml = header + "</objects>";

            // Save to file
            File.WriteAllText(fileName, xml);
            Console.WriteLine(xml);
        }

    }
}
