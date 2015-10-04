using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
   /// <summary>
    /// Represents a container of indexed collection of matrix
   /// </summary>
    public class Container: IContainer, IEnumerable<Matrix>
    {
        List<Matrix> _matrixList;
        int position = -1;

        /// <summary>
        /// Initialize a new instance of the Container
        /// </summary>
        /// <param name="matrices">List of matrices</param>
        public Container(List<Matrix> matrices)
        {
            _matrixList = matrices;
        }

        /// <summary>
        /// Returns a collection of items from the Container
        /// </summary>
        public List<Matrix> GetItems
        {
            get
            {
                return _matrixList;
            }
        }

        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
         IEnumerator<Matrix> IEnumerable<Matrix>.GetEnumerator()
        {
            return _matrixList.Cast<Matrix>().GetEnumerator();
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
            return (position < _matrixList.Count());
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
            get { return _matrixList[position]; }
        }

        /// <summary>
        /// Gets the element at the specified index
        /// </summary>
        /// <param name="i">index of the element</param>
        /// <returns></returns>
        public Matrix this[int i]
        {
            get
            {
                return _matrixList[i];
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
            return _matrixList[index].GetType();
        }
        
        /// <summary>
        /// Returns an array of types of inner items
        /// </summary>
        /// <returns></returns>
        public Type[] GetElementTypes()
        {
            return _matrixList.Select(x => x.GetType()).ToArray();
        }

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get
            {
                return _matrixList.Count;
            }
        }
        #endregion

    }
}
