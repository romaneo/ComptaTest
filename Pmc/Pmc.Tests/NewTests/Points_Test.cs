﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pmc.Core.Models.Point;

namespace Pmc.Tests.NewTests
{
    [TestClass]
    public class Points_Test
    {
        [TestMethod]
        public void Create1DPoint_WithDefaultValue()
        {
            var point = new Point1D<int>();
            Assert.IsNotNull(point);
            Assert.AreEqual(point.X, 0);
        }

        [TestMethod]
        public void Create2DPoint_WithUserValue()
        {
            var point = new Point2D<int>(34, 90);
            Assert.AreEqual(point.X, 34);
            Assert.AreEqual(point.Y, 90);
        }

        [TestMethod]
        public void Create3DPoint_WithUserValue()
        {
            var point = new Point3D<int>(31, 45, 0);
            Assert.AreEqual(point.X, 31);
            Assert.AreEqual(point.Y, 45);
            Assert.AreEqual(point.Z, 0);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void CreateTwoPointWithDifferentType()
        {
            Point1D<int> p1 = new Point1D<int>(3);
            Point2D<decimal> p2 = new Point2D<decimal>(3m, 4m);
        }
    }
}
