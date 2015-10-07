using System;
using Pmc.Core.Settings;

namespace Pmc.Core.Models.Point
{
    public class Point1D<T> : IPoint
    {

        #region X property
        private T _x;

        /// <summary>
        /// Gets the single coordinate of this 1D point
        /// </summary>
        public T X
        {
            get
            {
                return _x;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a new instance of the 1D point
        /// </summary>
        /// <param name="x">The position of the point </param>
        public Point1D(T x)
        {
            if (Limits.CheckNumericalData(typeof(T)))
                _x = x;
        }

        /// <summary>
        /// Initialize a new instance of the 1D point with default value
        /// </summary>
        public Point1D()
        {
            if (Limits.CheckNumericalData(typeof(T)))
                _x = default(T);
        }
        #endregion

        /// <summary>
        /// Returns a string that represent the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("1D point: (x: {0})", X);
        }
    }
}
