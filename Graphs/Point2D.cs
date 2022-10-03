namespace Graphs
{
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double X = 0, double Y = 0)
        {
            this.X = X;
            this.Y = Y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}