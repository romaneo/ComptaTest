using Pmc.Core.Settings;
using System;

namespace Pmc.Core.Models.Point
{
    public class Point2D<T> : IPoint
    {
        #region X property
        private T _x;

        /// <summary>
        /// Gets the x-coordinate of this 2D point
        /// </summary>
        public T X
        {
            get
            {
                return _x;
            }
        }
        #endregion

        #region Y property

        private T _y;

        /// <summary>
        /// Gets the y-coordinate of this 2D point
        /// </summary>
        public T Y
        {
            get
            {
                return _y;
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a new instance of the 2D point with the specified coordinates
        /// </summary>
        /// <param name="x">The horizontal position of the point </param>
        /// <param name="y">The vertical position of the point </param>
        public Point2D(T x, T y)
        {
            if (Limits.CheckNumericalData(typeof(T)))
            {
                _x = x;
                _y = y;
            }
        }

        /// <summary>
        /// Initialize a new instance of the 2D point with default value
        /// </summary>
        public Point2D()
        {
            if (Limits.CheckNumericalData(typeof(T)))
            {
                _x = default(T);
                _y = default(T);
            }
        }
        #endregion

        /// <summary>
        /// Returns a string that represent the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("2D point: (x: {0}; y: {1})", X, Y);
        }
    }
}
