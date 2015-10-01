using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Compta.Core.Models.Point;
using Compta.Core.Models.Extensions;
using Compta.Core.Models.Containers;
using System.Collections.Generic;
using Compta;

namespace Compta.Tests.PointTests
{
    /// <summary>
    /// Summary description for Containers_Test
    /// </summary>
    [TestClass]
    public class Position_Test
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
            Position<Point2D<double>> p = new Position<Point2D<double>>(new List<Point2D<double>>());
            Assert.AreEqual(p.Count(), 0);
        }

        [TestMethod]
        public void CreateNotEmpty2DPositionFromList()
        {
            var p = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Count(), 20);
        }

        [TestMethod]
        public void PositionsWithDifferentItemsCount()
        {
            var p1 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
            var p2 = CreateListOfPoint<Point1D<int>>(30).PushToPosition();
            Assert.AreEqual(p1.Count(), 20);
            Assert.AreEqual(p2.Count(), 30);
        }

        [TestMethod]
        public void DifferentNumberOfDataPointsFor2DPosition()
        {
            var p1 = CreateListOfPoint<Point2D<int>>(3).PushToPosition();
            var p2 = CreateListOfPoint<Point2D<int>>(4).PushToPosition();
            var p3 = CreateListOfPoint<Point2D<int>>(10).PushToPosition();
            var p4 = CreateListOfPoint<Point2D<int>>(15).PushToPosition();
            var p5 = CreateListOfPoint<Point2D<int>>(9).PushToPosition();

            var m1 = new IContainer[] { p1, p2, p3 }.PushToMatrix();
            var m2 = new IContainer[] { p3, p4, p5 }.PushToMatrix();
        }

        [TestMethod]
        public void XYZPositionWithoutPoints()
        {
            var p1 = CreateListOfPoint<Point3D<int>>(0).PushToPosition();
            Assert.AreEqual(p1.Count(), 0);
        }

        [TestMethod]
        public void XYZPositionWithPoints()
        {
            var p1 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            Assert.AreEqual(p1.Count(), 10);
        }

        [TestMethod]
        public void XPositionWithoutPoints()
        {
            var p1 = CreateListOfPoint<Point1D<int>>(0).PushToPosition();
            Assert.AreEqual(p1.Count(), 0);
        }

       
    }
}
