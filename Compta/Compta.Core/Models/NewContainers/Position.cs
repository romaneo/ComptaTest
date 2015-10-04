using Compta.Core.Models.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
    /// <summary>
    /// Represents a container of indexed collection of points
    /// </summary>
    /// <typeparam name="T">The types of points in container</typeparam>
    public class Position<T> : IPointContainer, IContainer, IEnumerable<IPoint> where T : IPoint
    {
        private List<T> _pointList;
        int position = -1;

        /// <summary>
        /// Initialize a new instance of the Position
        /// </summary>
        /// <param name="points">List of points</param>
        public Position(List<T> points)
        {
            _pointList = points;
        }

        /// <summary>
        /// Returns a collection of items from the Position
        /// </summary>
        public List<IPoint> GetItems
        {
            get
            {
                return _pointList.Cast<IPoint>().ToList();
            }
        }

        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator<IPoint> IEnumerable<IPoint>.GetEnumerator()
        {
            return _pointList.Cast<IPoint>().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
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

        #region IContainer

        /// <summary>
        /// Returns the type of inner element by index 
        /// </summary>
        /// <param name="index">Index of the element</param>
        /// <returns></returns>
        public Type GetElemetType(int index = 0)
        {
            return _pointList[index].GetType();
        }

        /// <summary>
        /// Returns an array of types of inner items
        /// </summary>
        /// <returns></returns>
        public Type[] GetElementTypes()
        {
            return _pointList.Select(x => x.GetType()).ToArray();
        }

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get
            {
                return _pointList.Count;
            }
        }
        #endregion
    }
}
