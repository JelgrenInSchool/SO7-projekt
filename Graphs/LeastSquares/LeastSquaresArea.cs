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
            LeastSquaresArea d2 = new()
            {
                aSquared = p.X * p.X,
                bSquared = 1,
                aCount = 2 * p.X * -p.Y,
                bCount = 2 * -p.Y,
                abCount = 2 * p.X,
                constant = p.Y * p.Y
            };

            return d + d2;
        }

        public static LeastSquaresArea operator +(LeastSquaresArea d, LeastSquaresArea d2)
        {
            LeastSquaresArea f = new()
            {
                aSquared = d.aSquared + d2.aSquared,
                bSquared = d.bSquared + d2.bSquared,
                aCount = d.aCount + d2.aCount,
                bCount = d.bCount + d2.bCount,
                abCount = d.abCount + d2.abCount,
                constant = d.constant + d2.constant
            };
            return f;
        }
    }
}
