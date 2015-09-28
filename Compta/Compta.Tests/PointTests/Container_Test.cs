using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Compta.Core.Models.Point;
using Compta.Core.Models.Extensions;
using Compta.Core.Models.Containers;

namespace Compta.Tests.PointTests
{
    [TestClass]
    public class Container_Test
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
        [ExpectedException(typeof(Exception))]
        public void EachContainerContainsTheSameNumberOfMatrices ()
        {
            var p1 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
            var p2 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
            var p3 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
            var p4 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            var p5 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            var p6 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();

            var m1 = new IContainer[] { p1, p2, p3 }.PushToMatrix();
            var m2 = new IContainer[] { p3, p4, p5 }.PushToMatrix();
            var m3 = new IContainer[] { p4, p5, p6 }.PushToMatrix();

            var c1 = new IContainer[] { m1, m2 }.PushToContainer();
            var c2 = new IContainer[] { m1, m2,m3 }.PushToContainer();
        }
    }
}

