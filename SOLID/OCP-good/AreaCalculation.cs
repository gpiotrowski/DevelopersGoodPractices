using System;

namespace OCP_good
{
    public class AreaCalculation
    {
        public double CalculateTotalArea(IShape[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.CalculateArea();
            }

            return area;
        }
    }
}
