using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Point
{
    public class Point3D<T> : IPoint
    {
        #region X property
        private T _x;

        /// <summary>
        /// Gets the x-coordinate of this 3D point
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
        /// Gets the y-coordinate of this 3D point
        /// </summary>
        public T Y
        {
            get
            {
                return _y;
            }
        }

        #endregion

        #region Z property

        private T _z;

        /// <summary>
        /// Gets the z-coordinate of this 3D point
        /// </summary>
        public T Z
        {
            get
            {
                return _z;
            }
           
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a new instance of the 3D point with the specified coordinates
        /// </summary>
        /// <param name="x">The horizontal position of the point </param>
        /// <param name="y">The vertical position of the point </param>
        /// <param name="z">The applicate position of the point </param>
        public Point3D(T x, T y, T z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Initialize a new instance of the 3D point with default value
        /// </summary>
        public Point3D()
        {
            _x = default(T);
            _y = default(T);
            _z = default(T);
        } 
        #endregion

        public override string ToString()
        {
            return String.Format("3D point: (x: {0}; y: {1}; z: {2})", X, Y, Z);
        }
    }
}
