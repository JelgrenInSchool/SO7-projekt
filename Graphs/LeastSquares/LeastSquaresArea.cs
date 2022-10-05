using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static LeastSquaresArea operator +(LeastSquaresArea d, Point2D p)
        {
            d.aSquared += p.X * p.X;
            d.bSquared += 1;
            d.aCount += 2 * p.X * -p.Y;
            d.bCount += 2 * -p.Y;
            d.abCount += 2 * p.X;
            d.constant += p.Y * p.Y;

            return d;
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
