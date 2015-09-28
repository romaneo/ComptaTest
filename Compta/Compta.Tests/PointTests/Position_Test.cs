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
        public void PositionWithoutPoints()
        {
            Position<Point2D<double>> p = new Position<Point2D<double>>(new List<Point2D<double>>());
            Assert.AreEqual(p.Count(), 0);
        }

        [TestMethod]
        public void CreatePositionFromList()
        {
            var p = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
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


    }
}
