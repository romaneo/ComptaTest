using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compta.Core.Models;
using Compta.Core.Models.Point;


namespace Compta
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Point3D<int>(2,3,5);
            Console.WriteLine(t.ToString());


            Console.WriteLine("\n\ncompleted!".ToUpper());
            Console.ReadKey();
        }
    }
}
