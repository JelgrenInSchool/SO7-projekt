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
    public class LeastSquaresAreaTests
    {
        LeastSquaresArea area;

        [TestMethod()]
        public void LeastSquaresAreaTest()
        {
            area = new();
            bool validation = 
                area.aSquared == 0 && 
                area.bSquared == 0 && 
                area.abCount == 0 && 
                area.aCount == 0 && 
                area.bCount == 0 && 
                area.constant == 0;

            Assert.IsTrue(validation);
        }

        [TestMethod()]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(10, 15, 10, 15, 10, 15)]
        [DataRow(12, 0, 12, 40, 20, 0)]
        public void GetLeastSquaresDerivativeForATest(double aSqr, double bSqr, double aC, double bC, double abC, double constant)
        {
            area = new()
            {
                aSquared = aSqr,
                bSquared = bSqr,
                aCount = aC,
                bCount = bC,
                abCount = abC,
                constant = constant
            };

            LeastSquaresDerivative deriv = area.GetLeastSquaresDerivativeForA();
            bool validation = 
                deriv.CountA == aSqr * 2 && 
                deriv.CountB == abC && 
                deriv.Constant == aC;

            Assert.IsTrue(validation);
        }

        [TestMethod()]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(10, 15, 10, 15, 10, 15)]
        [DataRow(12, 0, 12, 40, 20, 0)]
        public void GetLeastSquaresDerivativeForBTest(double aSqr, double bSqr, double aC, double bC, double abC, double constant)
        {
            area = new()
            {
                aSquared = aSqr,
                bSquared = bSqr,
                aCount = aC,
                bCount = bC,
                abCount = abC,
                constant = constant
            };

            LeastSquaresDerivative deriv = area.GetLeastSquaresDerivativeForB();
            bool validation = 
                deriv.CountA == abC && 
                deriv.CountB == bSqr * 2 && 
                deriv.Constant == bC;

            Assert.IsTrue(validation);
        }

        [TestMethod()]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(10, 15, 10, 15, 10, 15)]
        [DataRow(12, 0, 12, 40, 20, 0)]
        public void ToStringTest(double aSqr, double bSqr, double aC, double bC, double abC, double constant)
        {
            area = new()
            {
                aSquared = aSqr,
                bSquared = bSqr,
                aCount = aC,
                bCount = bC,
                abCount = abC,
                constant = constant
            };

            string layout = $"{abC}ab + ({aSqr}a^2) + ({bSqr}b^2) + ({aC}a) + ({bC}b) + {constant}";

            Assert.IsTrue(area.ToString() == layout);
        }

        [TestMethod()]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(10, 15, 10, 15, 10, 15, 10, 15)]
        [DataRow(12, 0, 12, 40, 20, 0, 30, 22)]
        public void AddPointAreaTest(double aSqr, double bSqr, double aC, double bC, double abC, double constant, double pX, double pY)
        {
            area = new()
            {
                aSquared = aSqr,
                bSquared = bSqr,
                aCount = aC,
                bCount = bC,
                abCount = abC,
                constant = constant
            };

            Point2D p = new(pX, pY);

            area += p;

            bool validation =
                area.aSquared == aSqr + pX * pX &&
                area.bSquared == bSqr + 1 &&
                area.aCount == aC + 2 * pX * -pY &&
                area.bCount == bC + 2 * -pY &&
                area.abCount == abC + 2 * pX &&
                area.constant == constant + pY * pY;

            Assert.IsTrue(validation);
        }

        [TestMethod()]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(10, 15, 10, 15, 10, 15)]
        [DataRow(12, 0, 12, 40, 20, 0)]
        public void AddLeastSquaresAreaTest(double aSqr, double bSqr, double aC, double bC, double abC, double constant)
        {
            area = new()
            {
                aSquared = aSqr,
                bSquared = bSqr,
                aCount = aC,
                bCount = bC,
                abCount = abC,
                constant = constant
            };

            double manip = 10;
            area += new LeastSquaresArea()
            {
                aSquared = manip,
                bSquared = manip,
                aCount = manip,
                bCount = manip,
                abCount = manip,
                constant = manip
            };

            bool validation = 
                area.aSquared == aSqr + manip && 
                area.bSquared == bSqr + manip && 
                area.aCount == aC + manip && 
                area.bCount == bC + manip && 
                area.abCount == abC + manip && 
                area.constant == constant + manip;

            Assert.IsTrue(validation);
        }
    }
}