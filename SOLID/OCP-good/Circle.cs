using System;

namespace OCP_good
{
    public class Circle : IShape
    {
        public double Radius { get; set; }
        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
