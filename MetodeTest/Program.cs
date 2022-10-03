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

            double xSquaredSum = 0;
            double ySquaredSum = 0;
            double xDoubleSum = 0;
            double yNegDoubleSum = 0;
            double xySum = 0;

            int i = 0;
            for (; i < points.Length; i++)
            {
                double xSquared = points[i].X * points[i].X;
                xSquaredSum += xSquared;

                double ySquared = points[i].Y * points[i].Y;
                ySquaredSum += ySquared;

                double xDouble = 2 * points[i].X;
                xDoubleSum += xDouble;

                double yNegDouble = 2 * -points[i].Y;
                yNegDoubleSum += yNegDouble;

                double xy = 2 * points[i].X * -points[i].Y;
                xySum += xy;

                string distance = $"{xSquared}a^2 + ({xDouble}ab) + ({xy}a) + b^2 + ({yNegDouble}b) + {ySquared}";

                Console.WriteLine($"Distance fra linje til punkt {i + 1}: {distance}");
            }

            LeastSquaresArea area = new(xDoubleSum, xSquaredSum, i, xySum, yNegDoubleSum, ySquaredSum);

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