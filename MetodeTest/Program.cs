using Graphs;
using Graphs.LeastSquares;
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

            Console.WriteLine($"Den bedste linje til at repræsentere disse punkter, er derfor: {line}");
        }

        public static LinearLine LinearRegression(Point2D[] points)
        {
            LeastSquaresArea area = new();
            for (int i = 0; i < points.Length; i++)
            {
                area += points[i];
            }

            LeastSquaresDerivative derivForA = area.GetLeastSquaresDerivativeForA();
            LeastSquaresDerivative derivForB = area.GetLeastSquaresDerivativeForB();

            double a = derivForA.FindA(derivForB);
            double b = derivForA.FindB(derivForB);

            Console.WriteLine($"Alle punkter er en bestemt distance fra linjen. Disse distance bliver kvadreret.");
            Console.WriteLine($"Summen af disse kvadrater udtrykkes som: {area}");
            Console.WriteLine($"Differentieret med hensyn til a: {derivForA}");
            Console.WriteLine($"Differentieret med hensyn til b: {derivForB}");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");

            LinearLine line = new(a, b);
            return line;
        }
    }
}