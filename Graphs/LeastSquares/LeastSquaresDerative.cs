namespace Graphs.LeastSquares
{
    public class LeastSquaresDerivative
    {
        public double CountA { get; set; }
        public double CountB { get; set; }
        public double Constant { get; set; }

        public LeastSquaresDerivative(double a, double b, double c)
        {
            CountA = a;
            CountB = b;
            Constant = c;
        }

        public double FindA(LeastSquaresDerivative derivB)
        {
            return -(CountB * FindB(derivB) + Constant) / CountA;
        }

        public double FindB(LeastSquaresDerivative derivB)
        {
            return (derivB.CountA * Constant + CountA * -derivB.Constant) / (CountA * ((-derivB.CountA * CountB + CountA * derivB.CountB) / CountA));
        }

        public override string ToString()
        {
            return $"{CountA}a + ({CountB}b) + ({Constant})";
        }
    }
}
