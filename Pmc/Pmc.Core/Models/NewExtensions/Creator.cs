using Pmc.Core.Models.NewContainers;
using Pmc.Core.Models.Point;
using System.Linq;

namespace Pmc.Core.Models.NewExtensions
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
            return new Position<T>(args.ToList());
        }

        /// <summary>
        /// Create new matrix from array of position
        /// </summary>
        /// <param name="args">Elements of matrix</param>
        /// <returns></returns>
        public static Matrix CreateMatrix(params IPointContainer[] args)
        {
            return new Matrix(args.ToList());
        }

        /// <summary>
        /// Create new container from array of matrix
        /// </summary>
        /// <param name="args">Elements of container</param>
        /// <returns></returns>
        public static Container CreateContainer(params Matrix[] args)
        {
            return new Container(args.ToList());
        }
        
        /// <summary>
        /// Create new containers from array of container
        /// </summary>
        /// <param name="args">Elements of containers</param>
        /// <returns></returns>
        public static NewContainers.Containers CreateContainers(params Container[] args)
        {
            return new NewContainers.Containers(args.ToList());
        }
    }
}
