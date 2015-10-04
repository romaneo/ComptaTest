using Compta.Core.Models.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
    /// <summary>
    /// Represents a container of indexed collection of position
    /// </summary>
    /// <typeparam name="T">The types of container in container</typeparam>
    public class Matrix:IContainer, IEnumerable<IPointContainer>
    {
        List<IPointContainer> _positionList;
        int position = -1;

        /// <summary>
        /// Initialize a new instance of the Matrix
        /// </summary>
        /// <param name="positions">List of positions</param>
        public Matrix(List<IPointContainer> position)
        {
            _positionList = position;
        }

        /// <summary>
        /// Returns a collection of items from the Matrix
        /// </summary>
        public List<Position<IPoint>> GetItems
        {
            get
            {
                return _positionList.Cast<Position<IPoint>>().ToList();
            }
        }

        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator<IPointContainer> IEnumerable<IPointContainer>.GetEnumerator()
        {
            return _positionList.Cast<IPointContainer>().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>

        IEnumerator IEnumerable.GetEnumerator()
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
        public Position<IPoint> this[int i]
        {
            get
            {
                return (_positionList[i] as Position<IPoint>);
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
            return _positionList[index].GetType();
        }

        /// <summary>
        /// Returns an array of types of inner items
        /// </summary>
        /// <returns></returns>
        public Type[] GetElementTypes()
        {
            return _positionList.Select(x => x.GetType()).ToArray();
        }

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get
            {
                return _positionList.Count;
            }
        }


        #endregion

    }
}
