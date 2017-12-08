using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DefineClass
{
    class Display
    {
        private string size;
        private int numberOfColors;

        public Display()
        {

        }

        public Display(string size)
        {
            this.size = size;
        }

        public Display(string size, int numberOfColors)
            : this (size)
        {
            this.numberOfColors = numberOfColors;
        }

        public string Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                this.numberOfColors = value;
            }
        }
    }
}
