using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Lines
{
    public class LinearLine
    {
        public double A { get; set; }
        public double B { get; set; }

        public LinearLine(double A = 0, double B = 0)
        {
            this.A = A;
            this.B = B;
        }

        public double GetX(double y) => (y - B) / A;
        public double GetY(double x) => A * x + B;

        public double VerticalDistanceToPoint(Point2D p) => A * p.X + B - p.Y;
        public double SqaredVerticalDistanceToPoint(Point2D p)
        {
            double dist = VerticalDistanceToPoint(p);
            return dist * dist;
        }


        public static LinearLine operator +(LinearLine lh, LinearLine rh)
        {
            lh.A += rh.A;
            lh.B += rh.B;
            return lh;
        }

        public static LinearLine operator -(LinearLine lh, LinearLine rh)
        {
            lh.A -= rh.A;
            lh.B -= rh.B;
            return lh;
        }

        public override string ToString()
        {
            return $"y = {A}x + {B}";
        }
    }
}
