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
        public static Matrix<IContainer> CreateMatrix<T>(int positionCount, int pointCount) where T : IPoint
        {
            List<Position<T>> t = new List<Position<T>>();
            for (int i = 0; i < positionCount; i++)
            {
                List<T> tp = new List<T>();
                for (int j = 0; j < pointCount; j++)
                {
                    tp.Add((T)Activator.CreateInstance(typeof(T)));
                }
                t.Add(tp.PushToPosition());

            }
            return t.ToArray().PushToMatrix();
        }

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
        public void EachContainerContainsTheSameNumberOfMatrices()
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
            var c2 = new IContainer[] { m1, m2, m3 }.PushToContainer();
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TypeOfEachIndexedMatrixSameAcrossContainers()
        {
            var m1 = CreateMatrix<Point2D<int>>(2, 3);
            var m2 = CreateMatrix<Point1D<int>>(2, 3);
            var m3 = CreateMatrix<Point2D<int>>(2, 3);
            var m4 = CreateMatrix<Point1D<int>>(2, 3);

            var c1 = new IContainer[] { m2,m1 }.PushToContainer();
            var c2 = new IContainer[] { m3, m4 }.PushToContainer();
        }

        [TestMethod]
        public void NumberOfPointsAtEach3DPositionSameAcrossEquivalentMatrixIndexesAcrossContainers()
        {
            var p1 = CreateListOfPoint<Point3D<int>>(5).PushToPosition();
            var p2 = CreateListOfPoint<Point3D<int>>(5).PushToPosition();
            var p3 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p4 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p5 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p6 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p7 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();

            var m1 = new IContainer[] { p1, p2 }.PushToMatrix();
            var m2 = new IContainer[] { p3, p4, p5 }.PushToMatrix();

            var m3 = new IContainer[] { p1, p2 }.PushToMatrix();
            var m4 = new IContainer[] { p5, p6, p7 }.PushToMatrix();

            var c1 = new IContainer[] { m1, m2 }.PushToContainer();
            var c2 = new IContainer[] { m3, m4 }.PushToContainer();
            
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void Incorrect_NumberOfPointsAtEach3DPositionSameAcrossEquivalentMatrixIndexesAcrossContainers()
        {
            var p1 = CreateListOfPoint<Point3D<int>>(5).PushToPosition();
            var p2 = CreateListOfPoint<Point3D<int>>(5).PushToPosition();
            var p3 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p4 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p5 = CreateListOfPoint<Point3D<int>>(10).PushToPosition();
            var p6 = CreateListOfPoint<Point3D<int>>(20).PushToPosition();
            var p7 = CreateListOfPoint<Point3D<int>>(20).PushToPosition();

            var m1 = new IContainer[] { p1, p2 }.PushToMatrix();
            var m2 = new IContainer[] { p3, p4, p5 }.PushToMatrix();

            var m3 = new IContainer[] { p1, p2 }.PushToMatrix();
            var m4 = new IContainer[] { p6, p7 }.PushToMatrix();

            var c1 = new IContainer[] { m1, m2 }.PushToContainer();
            var c2 = new IContainer[] { m3, m4 }.PushToContainer();
        }
    }
}

