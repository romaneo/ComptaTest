using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compta.Core.Models;
using Compta.Core.Models.Point;
using NE = Compta.Core.Models.NewExtensions;
using NC = Compta.Core.Models.NewContainers;
using Compta.Core.Models.NewContainers;
using Compta.Core.Models.NewExtensions;


namespace Compta
{
    class Program
    {
        /// <summary>
        /// Create list of IPoint with default value
        /// </summary>
        /// <typeparam name="T">Type of the point</typeparam>
        /// <param name="count">Count of point</param>
        /// <returns></returns>
        public static T[] CreateListOfPoint<T>(int count) where T : IPoint
        {
            List<T> t = new List<T>();
            for (int i = 0; i < count; i++)
            {
                t.Add((T)Activator.CreateInstance(typeof(T)));
            }
            return t.ToArray();
        }

        /// <summary>
        /// Create new matrix that contain position with point
        /// </summary>
        /// <typeparam name="T">Type of point</typeparam>
        /// <param name="positionCount">Positions count</param>
        /// <param name="pointCount">Points count</param>
        /// <returns></returns>
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

        static void Main(string[] args)
        {
            try
            {
                var p1 = NE.Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(2).ToArray());
                var p2 = NE.Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(2).ToArray());

                var p3 = NE.Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(1).ToArray());
                var p4 = NE.Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(1).ToArray());

                var p5 = NE.Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(2).ToArray());
                var p6 = NE.Creator.CreatePosition<Point1D<int>>(CreateListOfPoint<Point1D<int>>(2).ToArray());

                var p7 = NE.Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(1).ToArray());
                var p8 = NE.Creator.CreatePosition<Point2D<int>>(CreateListOfPoint<Point2D<int>>(1).ToArray());

                var m1 = NE.Creator.CreateMatrix(p1, p2);
                var m2 = NE.Creator.CreateMatrix(p3, p4);
                var m3 = NE.Creator.CreateMatrix(p5, p6);
                var m4 = NE.Creator.CreateMatrix(p7, p8);

                var c1 = NE.Creator.CreateContainer(m1, m2);
                var c2 = NE.Creator.CreateContainer(m3, m4);

                var cs = NE.Creator.CreateContainers(c1, c2);


                int cont = 1;

                foreach (var container in cs)
                {
                    int mt = 1;
                    Console.WriteLine("Container {0}", cont);
                    foreach (var matrix in container)
                    {
                        int ps = 1;
                        Console.WriteLine("\tMatrix {0}", mt);
                        foreach (var position in matrix)
                        {
                            Console.WriteLine("\t\tPosition {0}  {1}", ps, position.Count);
                            foreach (var point in position)
                            {
                                Console.WriteLine("\t\t\t" + point.ToString());
                            }
                            ps++;
                        }
                        mt++;
                    }
                    cont++;
                }


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



