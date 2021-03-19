using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP_bad
{
    public class Rectangle
    {
        protected double Width;
        protected double Height;

        public virtual void SetWidth(int width)
        {
            Width = width;
        }

        public virtual void SetHeight(int height)
        {
            Height = height;
        }

        public virtual double Area()
        {
            return Width*Height;
        }
    }
}
