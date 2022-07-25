using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Wpf
{
    public class Catagories
    {
       
        public Catagories(int index, string name, int count, string color)
        {
            this.index = index;
            this.name = name;
            this.count = count;
            this.color = color;
        }

        public static List<Catagories> listOfCatagories;

        public List<Catagories> MyProperty
        {
            get { return listOfCatagories; }
            set { listOfCatagories = value; }
        }



        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }




        //public int Index { get; set; }
        //public string Name { get; set; }
        //public int Count { get; set; }
        //public string Color { get; set; }

    }
}
