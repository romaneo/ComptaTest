using Compta.Core.Models.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
    public class Position<T> : IPointContainer,IContainer, IEnumerable<IPoint> where T : IPoint
    {
        private List<T> _pointList;
        int position = -1;

        public Position(List<T> poisnts)
        {
            _pointList = poisnts;
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
        public Type GetElemetType(int index = 0)
        {
            return _pointList[index].GetType();
        }

        public Type[] GetElementTypes()
        {
            return _pointList.Select(x => x.GetType()).ToArray();
        } 

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
