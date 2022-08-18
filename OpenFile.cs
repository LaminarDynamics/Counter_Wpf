using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;

namespace Counter_Wpf
{
    class OpenFile
    {

        int index = 0;
        string name = "";
        int count = 0;
        List<Point> locations = new List<Point>();
        string color = "";
        bool active;

      
        /// <summary>
        /// Read image metadata into object list and return
        /// </summary>
        /// <param name="myMetadata">The metadata to read</param>
        /// <returns></returns>
        public List<Catagories> CreateObjects(BitmapMetadata myMetadata)
        {
            List<Catagories> readCatagories = new List<Catagories>();
            List<Point> locations = new List<Point>();

            string lastType = "";

            XmlReader mine = XmlReader.Create(new StringReader(myMetadata.Comment.ToString()));
           
            int numberOfObjects = 0;
         
            while (mine.Read())
            {
                Console.WriteLine(mine.Name);

                if (numberOfObjects == 0)
                {
                    int.TryParse(mine.GetAttribute("count"), out numberOfObjects);
                    Console.WriteLine("UPDATED!");
                    Console.WriteLine("Number of objects = " + numberOfObjects);
                }
                

                // Type
                if (mine.NodeType == XmlNodeType.Element && mine.Name != "")
                {
                    lastType = mine.Name;
                }

                // Index
                if (mine.NodeType == XmlNodeType.Text && lastType == "index" && mine.Value != "")
                {
                    int.TryParse(mine.Value, out index);
                }

                // Name
                if (mine.NodeType == XmlNodeType.Text && lastType == "name" && mine.Value != "")
                {
                    name = mine.Value;
                }

                // Count
                if (mine.NodeType == XmlNodeType.Text && lastType == "count" && mine.Value != "")
                {
                    int.TryParse(mine.Value, out count);
                }

                // Location List
                if (mine.NodeType == XmlNodeType.Text && lastType == "locations" && mine.Value != "")
                {
                    locations = Listerizer(mine.Value);
                }

                // Color
                if (mine.NodeType == XmlNodeType.Text && lastType == "color" && mine.Value != "")
                {
                    color = mine.Value;
                }

                // Active
                if (mine.NodeType == XmlNodeType.Text && lastType == "active" && mine.Value != "")
                {
                    active = bool.Parse(mine.Value);
                }

                // End of current object
                if (mine.NodeType == XmlNodeType.EndElement && mine.Name == "object" && readCatagories.Count <= numberOfObjects)    // Fires when all data for one object complete
                {
                    Console.WriteLine();
                    List<Point> pointsToAdd = new List<Point>(locations); // Need this else newObjectToAdd.points gets cleared out 
                    var newObjectToAdd = new Catagories(index, name, count, pointsToAdd, color, active);
                    readCatagories.Add(newObjectToAdd);

                    // Reset variables
                    index = 0;
                    name = "";
                    count = 0;
                    locations.Clear();
                    color = "";
                    active = false;
                }

            }
            return readCatagories;
        }



        /// <summary>
        /// Take a long string and turn into list of points
        /// </summary>
        /// <param name="pointsData">string to transform</param>
        /// <returns></returns>
        public static List<Point> Listerizer(string pointsData)
        {
            List<Point> listOfPoints = new List<Point>();

            
            string[] points = pointsData.Split('\n');   // Have to use single quotes

            foreach (var item in points)
            {
                string[] coords = item.Split(',');
                if (coords.Length == 2) // Make sure two points are there
                {
                    Point thisPoint = new Point
                    {
                        X = Convert.ToInt32(Math.Round(Convert.ToDouble(coords[0]))),   // Change from strings to point
                        Y = Convert.ToInt32(Math.Round(Convert.ToDouble(coords[1])))
                    };
                    listOfPoints.Add(thisPoint);
                }
            }
            return listOfPoints;
        }

    }
}
