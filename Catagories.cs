﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Wpf
{
    public class Catagories
    {
       
        public Catagories(int index, string name, int count, byte[] color)
        {
            this.index = index;
            this.name = name;
            this.count = count;
            this.color = color;
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

        private byte[] color;

        public byte[] Color
        {
            get { return color; }
            set { color = value; }
        }


    }
}