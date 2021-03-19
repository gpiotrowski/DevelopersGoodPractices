using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_bad
{
    public class AreaCalculation
    {
        public double CalculateTotalArea(object[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    var rect = (Rectangle) shape;
                    area += rect.Height * rect.Width;
                }
                else if (shape is Circle)
                {
                    var cir = (Circle) shape;
                    area += Math.PI*Math.Pow(cir.Radius, 2);
                }
            }

            return area;
        }
    }
}
