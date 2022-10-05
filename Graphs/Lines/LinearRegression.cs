using Graphs.LeastSquares;

namespace Graphs.Lines
{
    public static class LinearRegression
    {
        public static LinearLine RegressionFromPoints(Point2D[] points)
        {
            LeastSquaresArea area = new();
            for (int i = 0; i < points.Length; i++)
            {
                area += points[i];
            }

            LeastSquaresDerivative derivForA = area.GetLeastSquaresDerivativeForA();
            LeastSquaresDerivative derivForB = area.GetLeastSquaresDerivativeForB();

            LinearLine line = new(derivForA.FindA(derivForB), derivForA.FindB(derivForB));

            return line;
        }
    }
}
