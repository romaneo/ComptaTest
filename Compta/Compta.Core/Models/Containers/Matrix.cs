﻿using Compta.Core.Models.Point;
using Compta.Core.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    /// <summary>
    /// Represents a container of indexed collection of position
    /// </summary>
    /// <typeparam name="T">The types of container in container</typeparam>
    public class Matrix<T> : IContainer where T : IContainer
    {
        private List<T> _positionList;
        int position = -1;

        /// <summary>
        /// Returns a collection of items from the Matrix
        /// </summary>
        public List<T> GetItems
        {
            get
            {
                return _positionList;
            }
        }

        /// <summary>
        /// Initialize a new instance of the Matrix
        /// </summary>
        /// <param name="positions">List of positions</param>
        public Matrix(List<T> positions)
        {
            #region check All matrices in all containers have the same number of positions 

            if (Limits.PositionCountInMatrix < 0)
                Limits.PositionCountInMatrix = positions.Count;

            if (Limits.PositionCountInMatrix >= 0 && Limits.PositionCountInMatrix != positions.Count && !(positions.FirstOrDefault()).GetType().GetGenericArguments()[0].Name.Contains("3D"))
                throw new Exception("All matrices in all containers have the same number of positions."); 

            #endregion

            #region Check The number of data points at each XYZ position will be the same for all positions on a matrix 


            if ((positions.FirstOrDefault()).GetType().GetGenericArguments()[0].Name.Contains("3D"))
            {
                int pointCount = positions.FirstOrDefault().Count();
                bool isPointsCountEqual = positions.Where(x => x.Count() == pointCount).Count() == positions.Count();

                if (!isPointsCountEqual)
                    throw new Exception("The number of data points at each XYZ position will be the same for all positions on a matrix ");                
            } 

            #endregion

            #region Check All positions in a specific matrix will be of the same position type.
            
            Type PositionTypeInMatrix = positions.FirstOrDefault().GetType();
            bool isTypesEqual = positions.Where(x => x.GetType() == PositionTypeInMatrix).Count() == positions.Count();
            if (!isTypesEqual)
                throw new Exception("All positions in a specific matrix will be of the same position type."); 

            #endregion

            _positionList = positions;
        }

        #region IEnumerable
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position++;
            return (position < _positionList.Count());
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            position = 0;
        }

        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        public object Current
        {
            get { return _positionList[position]; }
        }

        /// <summary>
        /// Gets the element at the specified index
        /// </summary>
        /// <param name="i">index of the element</param>
        /// <returns></returns>
        public IContainer this[int i]
        {
            get
            {
                return _positionList[i];
            }
        } 

        #endregion

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        public  int Count()
        {
            return _positionList.Count;
        }
    }
}
