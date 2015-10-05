using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Compta.Core.Models.Point;
using Compta.Core.Models.NewContainers;
using Compta.Core.Models.NewExtensions;

namespace Compta.Tests.NewTests.Position_Tests
{
    [TestClass]
    public class Position_Tests
    {

        public static List<T> CreateListOfPoint<T>(int count) where T : IPoint
        {
            List<T> t = new List<T>();
            for (int i = 0; i < count; i++)
            {
                t.Add((T)Activator.CreateInstance(typeof(T)));
            }
            return t;
        }

        [TestMethod]
        public void XYPositionWithoutPoints()
        {
            Position<Point2D<int>> p = new Position<Point2D<int>>(new List<Point2D<int>>());
            Assert.AreEqual(p.Count, 0);
        }

        [TestMethod]
        public void CreateNotEmpty2DPositionFromList()
        {
            var p = Creator.CreatePosition(CreateListOfPoint<Point2D<int>>(20).ToArray());
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Count, 20);
        }

        [TestMethod]
        public void PositionsWithDifferentItemsCount()
        {
            var p1 = Creator.CreatePosition(CreateListOfPoint<Point2D<int>>(20).ToArray());
            var p2 = Creator.CreatePosition(CreateListOfPoint<Point2D<int>>(30).ToArray());
            Assert.AreEqual(p1.Count, 20);
            Assert.AreEqual(p2.Count, 30);
        }

        [TestMethod]
        public void DifferentNumberOfDataPointsFor2DPosition()
        {
            var p1 = Creator.CreatePosition(CreateListOfPoint<Point2D<int>>(30).ToArray());
            var p2 = Creator.CreatePosition(CreateListOfPoint<Point2D<int>>(2).ToArray());
            var p3 = Creator.CreatePosition(CreateListOfPoint<Point2D<int>>(40).ToArray());
            var p4 = Creator.CreatePosition(CreateListOfPoint<Point2D<int>>(10).ToArray());
            var p5 = Creator.CreatePosition(CreateListOfPoint<Point2D<int>>(2).ToArray());

            var m1 = Creator.CreateMatrix(p1, p2, p3);
            var m2 = Creator.CreateMatrix(p3, p4, p5);
        }

        [TestMethod]
        public void XYZPositionWithoutPoints()
        {
            var p1 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(0).ToArray());
            Assert.AreEqual(p1.Count, 0);
        }

        [TestMethod]
        public void XYZPositionWithPoints()
        {
            var p1 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10).ToArray());
            Assert.AreEqual(p1.Count, 10);
        }

        [TestMethod]
        public void XPositionWithoutPoints()
        {
            var p1 = Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(0).ToArray());
            Assert.AreEqual(p1.Count, 0);
        }
    }
}
