using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Pmc.Core.Models.Point;
using Pmc.Core.Models.NewExtensions;

namespace Pmc.Tests.NewTests.Matrix_Tests
{
    [TestClass]
    public class Matrix_Tests
    {
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
        public void AllPositionInMatrixSameType()
        {
            var p1 = Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(20));
            var p2 = Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(10));
            var m = Creator.CreateMatrix(p1, p2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void All3DPositionInMatrixHaveEqualDataPoint()
        {
            var p1 = Creator.CreatePosition<Point3D<int>>( CreateListOfPoint<Point3D<int>>(10));
            var p2 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(20));
            var m = Creator.CreateMatrix(p1, p2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CannotCreateMatricesWithDifferentNumberOfPosition()
        {
            var p1 = Creator.CreatePosition<Point2D<int>>( CreateListOfPoint<Point2D<int>>(20));
            var p2 = Creator.CreatePosition<Point2D<int>>( CreateListOfPoint<Point2D<int>>(20));
            var p3 =  Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(20));
            var p4 = Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(20));
            var m = Creator.CreateMatrix(p1, p1, p3);
            var m1 = Creator.CreateMatrix(p1, p2, p3, p4);
        }

        [TestMethod]
        public void Different3DMatricesHaveDifferentNumberOfPosition()
        {
            var p1 =  Creator.CreatePosition<Point3D<int>>( CreateListOfPoint<Point3D<int>>(3));
            var p2 =  Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(3));
            var p3 =  Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(3));
            var p4 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(3));

            var m1 = Creator.CreateMatrix(p1, p2);
            var m2 = Creator.CreateMatrix(p1, p2, p3);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void XYZPositionHaveSameNumberOfPointForAllPositionOnAMatrix()
        {
            var p1 =Creator.CreatePosition<Point3D<int>>( CreateListOfPoint<Point3D<int>>(10));
            var p2 = Creator.CreatePosition<Point3D<int>>(CreateListOfPoint<Point3D<int>>(9));
            var m1 = Creator.CreateMatrix(p1, p2);
        }

     
    }
}
