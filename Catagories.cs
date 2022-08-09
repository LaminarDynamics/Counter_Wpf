using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Wpf
{
    public class Catagories
    {
       
        public Catagories(int index, string name, int count, string color, bool active)
        {
            this.index = index;
            this.name = name;
            this.count = count;
            this.color = color;
            this.active = active;
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


        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }


    }
}
