using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Pmc.Core.Models.Point;
using Pmc.Core.Models.NewContainers;
using Pmc.Core.Models.NewExtensions;

namespace Pmc.Tests.NewTests.Container_Tests
{
    [TestClass]
    public class Container_Tests
    {
        public static Matrix CreateMatrix<T>(int positionCount, int pointCount) where T : IPoint
        {
            List<Position<T>> t = new List<Position<T>>();
            for (int i = 0; i < positionCount; i++)
            {
                List<T> tp = new List<T>();
                for (int j = 0; j < pointCount; j++)
                {
                    tp.Add((T)Activator.CreateInstance(typeof(T)));
                }
                t.Add(Creator.CreatePosition<T>(tp.ToArray()));

            }
            return Creator.CreateMatrix(t.ToArray());
        }

        public static T[] CreateListOfPoint<T>(int count) where T : IPoint
        {
            List<T> t = new List<T>();
            for (int i = 0; i < count; i++)
            {
                t.Add((T)Activator.CreateInstance(typeof(T)));
            }
            return t.ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EachContainerContainsTheSameNumberOfMatrices()
        {
            var p1 = Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(20));
            var p2 = Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(20));
            var p3 = Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(20));
            var p4 = Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(20));
            var p5 = Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(20));
            var p6 = Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(20));

            var m1 = Creator.CreateMatrix(p1, p2, p3);
            var m2 = Creator.CreateMatrix(p3, p4, p5);
            var m3 = Creator.CreateMatrix(p4, p5, p6);

            var c1 = Creator.CreateContainer(m1, m2);
            var c2 = Creator.CreateContainer(m1, m2, m3);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void TypeOfEachIndexedMatrixSameAcrossContainers()
        {
            var m1 = CreateMatrix<Point2D<int>>(2, 3);
            var m2 = CreateMatrix<Point1D<int>>(2, 3);
            var m3 = CreateMatrix<Point2D<int>>(2, 3);
            var m4 = CreateMatrix<Point1D<int>>(2, 3);

            var c1 = Creator.CreateContainer(m2, m1);
            var c2 = Creator.CreateContainer(m3, m4);
        }

        [TestMethod]
        public void NumberOfPointsAtEach3DPositionSameAcrossEquivalentMatrixIndexesAcrossContainers()
        {
            var p1 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(5));
            var p2 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(5));
            var p3 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10));
            var p4 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10));
            var p5 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10));
            var p6 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10));
            var p7 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10));

            var m1 = Creator.CreateMatrix(p1, p2);
            var m2 = Creator.CreateMatrix(p3, p4, p5);

            var m3 = Creator.CreateMatrix(p1, p2);
            var m4 = Creator.CreateMatrix(p5, p6, p7);

            var c1 = Creator.CreateContainer(m1, m2);
            var c2 = Creator.CreateContainer(m3, m4);

        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void Incorrect_NumberOfPointsAtEach3DPositionSameAcrossEquivalentMatrixIndexesAcrossContainers()
        {
            var p1 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(5));
            var p2 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(5));
            var p3 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10));
            var p4 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10));
            var p5 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(10));
            var p6 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(20));
            var p7 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(20));

            var m1 = Creator.CreateMatrix(p1, p2);
            var m2 = Creator.CreateMatrix(p3, p4, p5);

            var m3 = Creator.CreateMatrix(p1, p2);
            var m4 = Creator.CreateMatrix(p6, p7);

            var c1 = Creator.CreateContainer(m1, m2);
            var c2 = Creator.CreateContainer(m3, m4);
        }
    }
}
