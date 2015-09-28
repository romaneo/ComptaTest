﻿using Compta.Core.Models.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compta.Core.Settings;

namespace Compta.Core.Models.Containers
{
    public class Position<T> : IContainer where T : IPoint
    {
        private List<T> _pointList;
        int position = -1;

        /// <summary>
        /// Returns a collection of items from the Position
        /// </summary>
        public List<T> GetItems
        {
            get
            {
                return _pointList;
            }
        }

        /// <summary>
        /// Initialize a new instance of the Position
        /// </summary>
        /// <param name="points">List of points</param>
        public Position(List<T> points)
        {
            

            _pointList = points;
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
            return (position < _pointList.Count());
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
            get { return _pointList[position]; }
        }

        /// <summary>
        /// Gets the element at the specified index
        /// </summary>
        /// <param name="i">index of the element</param>
        /// <returns></returns>
        public IPoint this[int i]
        {
            get
            {
                return _pointList[i];
            }
        } 
        #endregion

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        public  int Count()
        {
            return _pointList.Count;
        }

    }
}
