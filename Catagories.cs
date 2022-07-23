using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Wpf
{
    class Catagories
    {
        private int index;
        private string name;
        private int count;
        private string color;

        public Catagories(int index, string name, int count, string color)
        {
            this.index = index;
            this.name = name;
            this.count = count;
            this.color = color;
        }

        public int Index { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }

    }
}
