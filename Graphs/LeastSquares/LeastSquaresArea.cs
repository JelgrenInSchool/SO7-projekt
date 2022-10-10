namespace Graphs.LeastSquares
{
    public class LeastSquaresArea
    {
        public double aSquared = 0;
        public double bSquared = 0;
        public double aCount = 0;
        public double bCount = 0;
        public double abCount = 0;
        public double constant = 0;

        public LeastSquaresArea() { }

        public LeastSquaresDerivative GetLeastSquaresDerivativeForA()
        {
            return new(aSquared * 2, abCount, aCount);
        }

        public LeastSquaresDerivative GetLeastSquaresDerivativeForB()
        {
            return new(abCount, bSquared * 2, bCount);
        }

        public override string ToString()
        {
            string area = $"{abCount}ab + ({aSquared}a^2) + ({bSquared}b^2) + ({aCount}a) + ({bCount}b) + {constant}";
            return area;
        }

        public static LeastSquaresArea operator +(LeastSquaresArea lh, Point2D p)
        {
            lh.aSquared += p.X * p.X;
            lh.bSquared += 1;
            lh.aCount += 2 * p.X * -p.Y;
            lh.bCount += 2 * -p.Y;
            lh.abCount += 2 * p.X;
            lh.constant += p.Y * p.Y;

            return lh;
        }

        public static LeastSquaresArea operator +(LeastSquaresArea d, LeastSquaresArea d2)
        {
            d.aSquared += d2.aSquared;
            d.bSquared += d2.bSquared;
            d.aCount += d2.aCount;
            d.bCount += d2.bCount;
            d.abCount += d2.abCount;
            d.constant += d2.constant;

            return d;
        }
    }
}
