using Compta.Core.Models.Containers;
using Compta.Core.Models.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Extensions
{
    public static class Extension
    {
        public static Position<T> PushToPosition<T>(this List<T> points) where T:IPoint
        {
            return new Position<T>(points);
        }

        public static Matrix<IContainer> PushToMatrix(this IContainer[] positions)
        {
            return new Matrix<IContainer>(positions.ToList());
        }

        public static Container<IContainer> PushToContainer(this IContainer[] matrixes) 
        {
            return new Container<IContainer>(matrixes.ToList() );
        }

        public static Containers<IContainer> PushToContainers(this IContainer[] containers)
        {
            return new Containers<IContainer>(containers.ToList());
        }
    }
}
