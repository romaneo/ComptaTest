using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compta.Core.Models;
using Compta.Core.Models.Point;
using Compta.Core.Models.Containers;
using Compta.Core.Models.Extensions;


namespace Compta
{
    class Program
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
        static void Main(string[] args)
        {
            try
            {
                //var p1 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
                //var p2 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
                //var p3 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();



                //var m1 = new IContainer[] { p1, p2, p3 }.PushToMatrix();
                //var m2 = new IContainer[] { p2, p3 }.PushToMatrix();

                //var c1 = new IContainer[] { m1, m2 }.PushToContainer();
                //var c2 = new IContainer[] { m2, m1 }.PushToContainer();

                //var cs1 = new IContainer[] { c1, c2 }.PushToContainers();

                var m1 = CreateMatrix<Point2D<double>>(2, 3);
                var m2 = CreateMatrix<Point1D<double>>(2, 3);
                var m3 = CreateMatrix<Point2D<double>>(2, 3);
                var m4 = CreateMatrix<Point1D<double>>(2, 3);
                var m5 = CreateMatrix<Point2D<double>>(2, 3);
                var m6 = CreateMatrix<Point1D<double>>(2, 3);

                var c1 = new IContainer[] { m1, m2 }.PushToContainer();
                var c2 = new IContainer[] { m3, m4 }.PushToContainer();
                var c3 = new IContainer[] { m5, m6 }.PushToContainer();

                var cs = new IContainer[] { c1, c2, c3 }.PushToContainers();


                //int cont = 1;


                //foreach (IContainer container in cs)
                //{
                //    int mt = 1;
                //    Console.WriteLine("Container {0}", cont);
                //    foreach (IContainer matrix in container)
                //    {
                //        int ps = 1;
                //        Console.WriteLine("\tMatrix {0}", mt);
                //        foreach (IContainer position in matrix)
                //        {
                //            Console.WriteLine("\t\tPosition {0}", ps);
                //            foreach (IPoint point in position)
                //            {
                //                Console.WriteLine("\t\t\t" + point.ToString());
                //            }
                //            ps++;
                //        }
                //        mt++;
                //    }
                //    cont++;
                //}

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }












            Console.WriteLine("\n\ncompleted!".ToUpper());
            Console.ReadKey();
        }
    }
}

