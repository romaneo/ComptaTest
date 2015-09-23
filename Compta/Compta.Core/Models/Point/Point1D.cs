using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Point
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
            _x = x;
        }

        /// <summary>
        /// Initialize a new instance of the 1D point with default value
        /// </summary>
        public Point1D()
        {
            _x = default(T);
        } 
        #endregion

        public override string ToString()
        {
            return String.Format("1D point: (x: {0})", X);
        }
    }
}
