using Compta.Core.Models.Containers;
using Compta.Core.Models.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Extensions
{
    public static class Creator
    {
        /// <summary>
        /// Create new position from array of points
        /// </summary>
        /// <typeparam name="T">Type of points</typeparam>
        /// <param name="args">Elements of the position</param>
        /// <returns></returns>
        public static Position<T> CreatePosition<T>(params T[] args) where T : IPoint
        {
            return (args.ToList().PushToPosition());
        }

        /// <summary>
        /// Create new matrix from array of position
        /// </summary>
        /// <param name="args">Elements of matrix</param>
        /// <returns></returns>
        public static Matrix<IContainer> CreateMatrix(params IContainer[] args) 
        {
            return (args.PushToMatrix());
        }

        /// <summary>
        /// Create new container from array of matrix
        /// </summary>
        /// <param name="args">Elements of container</param>
        /// <returns></returns>
        public static Container<IContainer> CreateContainer(params IContainer[] args)
        {
            return (args.PushToContainer());
        }

        /// <summary>
        /// Create new containers from array of container
        /// </summary>
        /// <param name="args">Elements of containers</param>
        /// <returns></returns>
        public static Containers<IContainer> CreateContainers(params IContainer[] args)
        {
            return (args.PushToContainers());
        }
    }
}
