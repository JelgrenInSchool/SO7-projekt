using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphs.LeastSquares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.LeastSquares.Tests
{
    [TestClass()]
    public class LeastSquaresDerivativeTests
    {
        LeastSquaresDerivative deriv;
        LeastSquaresDerivative deriv2;

        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(10, 0, 10)]
        [DataRow(25, 345, 23)]
        public void LeastSquaresDerivativeTest(double a, double b, double c)
        {
            deriv = new(a, b, c);

            bool validation =
                deriv.CountA == a &&
                deriv.CountB == b &&
                deriv.Constant == c;

            Assert.IsTrue(validation);
        }

        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(10, 0, 10)]
        [DataRow(25, 345, 23)]
        public void FindATest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow(1, 1, 2, 1, 5, 1)]
        [DataRow(10, 0, 10, 0, 10, 0)]
        [DataRow(25, 345, 23, 43, 17, 349)]
        public void FindBTest(double a, double b, double c, double a2, double b2, double c2)
        {
            deriv = new(a, b, c);
            deriv2 = new(a2, b2, c2);

            double foundB = deriv.FindB(deriv2);

            double s = (a2 * c + a * -c2) / (a * ((-a2 * b + a * b2) / a));

            Assert.IsTrue(foundB == s);
        }

        [TestMethod()]
        [DataRow(0, 0, 0)]
        [DataRow(10, 0, 10)]
        [DataRow(25, 345, 23)]
        public void ToStringTest(double a, double b, double c)
        {
            deriv = new(a, b, c);
            string temp = $"{a}a + ({b}b) + ({c})";

            Assert.IsTrue(deriv.ToString() == temp);
        }
    }
}