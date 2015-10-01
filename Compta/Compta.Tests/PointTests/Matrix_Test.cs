using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Compta.Tests.PointTests;
using Compta.Core.Models.Point;
using System.Collections.Generic;
using Compta.Core.Models.Extensions;
using Compta.Core.Models.Containers;

namespace Compta.Tests.PointTests
{
    [TestClass]
    public class Matrix_Test
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
        public void AllPositionInMatrixSameType()
        {
            var p1 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
            var p2 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            var m = new IContainer[] { p1, p2 }.PushToMatrix();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void All3DPositionInMatrixHaveEqualDataPoint()
        {
            var p1 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p2 = CreateListOfPoint<Point3D<int>>(20).PushToPosition();
            var m = new IContainer[] { p1, p2 }.PushToMatrix();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CannotCreateMatricesWithDifferentNumberOfPosition()
        {
            var p1 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            var p2 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            var p3 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            var p4 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            var m = new IContainer[] { p1, p2, p3 }.PushToMatrix();
            var m1 = new IContainer[] { p1, p2, p3, p4 }.PushToMatrix();
        }

        [TestMethod]
        public void Different3DMatricesHaveDifferentNumberOfPosition()
        {
            var p1 = CreateListOfPoint<Point3D<int>>(3).PushToPosition();
            var p2 = CreateListOfPoint<Point3D<int>>(3).PushToPosition();
            var p3 = CreateListOfPoint<Point3D<int>>(3).PushToPosition();
            var p4 = CreateListOfPoint<Point3D<int>>(3).PushToPosition();

            var m1 = new IContainer[] { p1, p2 }.PushToMatrix();
            var m2 = new IContainer[] { p1, p2,p3 }.PushToMatrix();
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void XYZPositionHaveSameNumberOfPointForAllPositionOnAMatrix()
        {
            var p1 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p2 = CreateListOfPoint<Point3D<int>>(9).PushToPosition();
            var m1 = new IContainer[] { p1, p2 }.PushToMatrix();
        }

     
    }
}
