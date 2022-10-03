using Graphs;
using Graphs.LeastSquare;
using Graphs.Lines;

namespace MetodeTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Point2D[] points = new[]
            {
                new Point2D(2, 3),
                new Point2D(8, 15),
                new Point2D(-2, 4)
            };

            // Print the points, were handling.
            Console.Write("Punkterne der bliver lavet en lineær regression på: ");
            for (int i = 0; i < points.Length - 1; i++)
            {
                Console.Write(points[i] + ", ");
            }
            Console.WriteLine($"{points[^1]}\n");

            LinearLine line = LinearRegression(points);

            Console.WriteLine(line);
        }

        public static LinearLine LinearRegression(Point2D[] points)
        {
            Console.WriteLine("Fra forskriften 'ax + b - y':");

            LeastSquaresArea area = new();
            for (int i = 0; i < points.Length; i++)
            {
                area += points[i];
            }

            Console.WriteLine($"Arealet af alle kvadrater: {area}");

            LeastSquaresDerivative derivForA = area.GetLeastSquaresDerivativeForA();
            LeastSquaresDerivative derivForB = area.GetLeastSquaresDerivativeForB();

            Console.WriteLine($"Differentieret med hensyn til a: {derivForA}");
            Console.WriteLine($"Differentieret med hensyn til b: {derivForB}");

            double a = derivForA.FindA(derivForB);
            double b = derivForA.FindB(derivForB);

            Console.WriteLine($"Dermed er a: {derivForA.FindA(derivForB)}");
            Console.WriteLine($"og resultatet for b er: {derivForA.FindB(derivForB)}");

            LinearLine line = new(a, b);
            return line;
        }
    }
}