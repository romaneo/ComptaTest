using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compta.Core.Models;
using Compta.Core.Models.Point;
using Compta.Core.Models.Containers;


namespace Compta
{
    class Program
    {
        static void Main(string[] args)
        {
            Position<Point1D<int>> p = new Position<Point1D<int>>(new List<Point1D<int>>(){new Point1D<int>(3), new Point1D<int>(4), new Point1D<int>(5)});
            Position<Point1D<int>> p1 = new Position<Point1D<int>>(new List<Point1D<int>>() { new Point1D<int>(-3), new Point1D<int>(-4), new Point1D<int>(-5) });
            Matrix<Position<Point1D<int>>> m = new Matrix<Position<Point1D<int>>>(new List<Position<Point1D<int>>>() { p, p1 });
            Container<Matrix<Position<Point1D<int>>>> c = new Container<Matrix<Position<Point1D<int>>>>(new List<Matrix<Position<Point1D<int>>>>() { m });
            Containers<Container<Matrix<Position<Point1D<int>>>>> cs = new Containers<Container<Matrix<Position<Point1D<int>>>>>(new List<Container<Matrix<Position<Point1D<int>>>>>() { c });
            
                 


            Console.WriteLine("\n\ncompleted!".ToUpper());
            Console.ReadKey();
        }
    }
}
