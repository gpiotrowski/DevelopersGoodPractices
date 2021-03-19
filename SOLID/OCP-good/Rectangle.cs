namespace OCP_good
{
    public class Rectangle : IShape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double CalculateArea()
        {
            return Height*Width;
        }
    }
}
