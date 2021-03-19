using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP_bad
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            //Rectangle rect = new Square();

            rect.SetHeight(10);
            rect.SetWidth(20);

            if (rect.Area() != 200)
            {
                throw new Exception("Rectangle area other than expected!");
            }

            Console.WriteLine(rect.Area());

            Console.ReadKey();
        }
    }
}
