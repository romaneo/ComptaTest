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
        public static List<T> CreateListOfPoint<T>(int count) where T:IPoint
        {
            List<T> t = new List<T>();
            for (int i = 0; i < count; i++)
            {
                t.Add(default(T));
            }
            return t;
        }

        static void Main(string[] args)
        {
            //Position<Point1D<int>> p = new Position<Point1D<int>>(new List<Point1D<int>>() { new Point1D<int>(3), new Point1D<int>(4), new Point1D<int>(5) });
            //Position<Point1D<int>> p1 = new Position<Point1D<int>>(new List<Point1D<int>>() { new Point1D<int>(-3), new Point1D<int>(-4), new Point1D<int>(-5) });
            //Position<Point2D<int>> p2 = new Position<Point2D<int>>(new List<Point2D<int>>() { new Point2D<int>(-3, -4), new Point2D<int>(-4, -5), new Point2D<int>(-5, -5) });
            //Matrix<Position<Point1D<int>>> m = new Matrix<Position<Point1D<int>>>(new List<Position<Point1D<int>>>() { p, p1 });
            //Matrix<Position<Point2D<int>>> m1 = new Matrix<Position<Point2D<int>>>(new List<Position<Point2D<int>>>() { p2 });
            //Container<Matrix<Position<Point1D<int>>>> c = new Container<Matrix<Position<Point1D<int>>>>(new List<Matrix<Position<Point1D<int>>>>() { m, (m1 as IContainer) });
            //Containers<Container<Matrix<Position<Point1D<int>>>>> cs = new Containers<Container<Matrix<Position<Point1D<int>>>>>(new List<Container<Matrix<Position<Point1D<int>>>>>() { c });

            //Position<IPoint> t = new Position<IPoint>(new List<IPoint>() { new Point1D<int>(2) });
            //Position<IPoint> t1 = new Position<IPoint>(new List<IPoint>() { new Point1D<int>(3) });
            //Position<IPoint> t2 = new Position<IPoint>(new List<IPoint>() { new Point1D<int>(4) });
            //Position<IPoint> t3 = new Position<IPoint>(new List<IPoint>() { new Point2D<int>(3, 4) });
            //Matrix<IContainer> tm = new Matrix<IContainer>(new List<IContainer>() { t, t1, t2 });
            //Matrix<IContainer> tm2 = new Matrix<IContainer>(new List<IContainer>() { t3 });
            //Container<IContainer> tc = new Container<IContainer>(new List<IContainer>() { tm, tm2 });
            //Container<IContainer> tc2 = new Container<IContainer>(new List<IContainer>() { tm, tm2 });
            //Containers<IContainer> tcs = new Containers<IContainer>(new List<IContainer>() { tc, tc2 });

            //var k = (((tcs.GetItems[1] as Container<IContainer>).GetItems[1] as Matrix<IContainer>).GetItems[0] as Point3D<int>);




            //IPoint t = new Point2D<double>(3, 5);
            //IPoint t1 = new Point2D<double>(3, 5);
            //Position<IPoint> m;
            //Type j = t.GetType();
            //Console.WriteLine();

            //List<Point1D<int>> p = new List<Point1D<int>>() { new Point1D<int>(2), new Point1D<int>(3) };

            //List<Point1D<int>> p1 = new List<Point1D<int>>() { new Point1D<int>(2), new Point1D<int>(3) };
            //List<IContainer> pl = new List<IContainer>() { p.PushToPosition(), p1.PushToPosition() };
            //var c = pl.PushToMatrix();
            //Console.WriteLine(c.GetType().Name);

            var p1 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();
            var p2 = CreateListOfPoint<Point2D<int>>(20).PushToPosition();
            var p3 = CreateListOfPoint<Point1D<int>>(20).PushToPosition();

            var m1 = new IContainer[] { p1, p2, p3 }.PushToMatrix();
            var m2 = new IContainer[] { p2, p3 }.PushToMatrix();

            var c1 = new IContainer[] { m1, m2 }.PushToContainer();
            var c2 = new IContainer[] { m2, m1 }.PushToContainer();

            var cs1 = new IContainer[] { c1, c2 }.PushToContainers();

            

            var r = ((m2.GetItems.First() as Position<IPoint
                >).GetItems.First() as Point2D<int>).Y;
            Console.WriteLine(r);


            IPoint t = new Point2D<int>(2, 5);
            Console.WriteLine(t.ToString());
            //IPoint t1 = t;
            //Point2D<int> t2 = (Point2D<int>)t1;

            
            


            

            
            
                 


            Console.WriteLine("\n\ncompleted!".ToUpper());
            Console.ReadKey();
        }
    }
}
