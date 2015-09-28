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

        /// <summary>
        /// Creates a Position from a List of IPoint
        /// </summary>
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="points">List of IPoint</param>
        /// <returns></returns>
        public static Position<T> PushToPosition<T>(this List<T> points) where T : IPoint
        {
            return new Position<T>(points);
        }

        /// <summary>
        /// Creates a Matrix from a array of Position
        /// </summary>
        /// <param name="positions">array of position</param>
        /// <returns></returns>
        public static Matrix<IContainer> PushToMatrix(this IContainer[] positions)
        {
            return new Matrix<IContainer>(positions.ToList());
        }

        /// <summary>
        /// Creates a Container from a array of Matrix
        /// </summary>
        /// <param name="matrices">Array of matrices </param>
        /// <returns></returns>
        public static Container<IContainer> PushToContainer(this IContainer[] matrices)
        {
            return new Container<IContainer>(matrices.ToList());
        }

        /// <summary>
        /// Creates a Containers from a array of Container
        /// </summary>
        /// <param name="containers">Array of Container</param>
        /// <returns></returns>
        public static Containers<IContainer> PushToContainers(this IContainer[] containers)
        {
            return new Containers<IContainer>(containers.ToList());
        }
    }
}
