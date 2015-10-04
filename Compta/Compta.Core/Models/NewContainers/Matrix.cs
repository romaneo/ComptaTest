using Compta.Core.Models.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
    public class Matrix:IContainer, IEnumerable<IPointContainer>
    {
        List<IPointContainer> _positionList;
        int position = -1;

        public Matrix(List<IPointContainer> position)
        {
            _positionList = position;
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
        public IPointContainer this[int i]
        {
            get
            {
                return _positionList[i];
            }
        }

        #endregion

        #region IContainer
        public Type GetElemetType(int index = 0)
        {
            return _positionList[index].GetType();
        }

        public Type[] GetElementTypes()
        {
            return _positionList.Select(x => x.GetType()).ToArray();
        }

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
