using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Tests
{
    [TestClass()]
    public class Point2DTests
    {
        Point2D point;

        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(25, 0)]
        [DataRow(0, 25)]
        [DataRow(25, 25)]
        public void Point2DTest(int x, int y)
        {
            point = new(x, y);

            Assert.IsTrue(point.X == x && point.Y == y);
        }

        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(0, 25)]
        [DataRow(25, 0)]
        [DataRow(25, 25)]
        public void ToStringTest(double x, double y)
        {
            point = new(x, y);
            Assert.IsTrue(point.ToString() == $"({x};{y})");
        }
    }
}