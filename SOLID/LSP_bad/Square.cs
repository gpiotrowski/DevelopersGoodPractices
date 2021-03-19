using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP_bad
{
    public class Square : Rectangle
    {
        public override void SetHeight(int height)
        {
            Width = height;
            Height = height;
        }

        public override void SetWidth(int width)
        {
            Width = width;
            Height = width;
        }
    }
}
