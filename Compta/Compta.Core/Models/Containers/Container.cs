﻿using Compta.Core.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public class Container<T> : IContainer where T : IContainer
    {
        private List<T> _matrixList;
        int position = -1;

        /// <summary>
        /// Returns a collection of items from the Container
        /// </summary>
        public List<T> GetItems
        {
            get
            {
                return _matrixList;
            }
        }

        /// <summary>
        /// Initialize a new instance of the Container
        /// </summary>
        /// <param name="matrices">List of matrices</param>
        public Container(List<T> matrices)
        {
            #region Check Each container in a containers collection contains the same number of matrices 

            if (Limits.MatrixCountInContainer < 0)
                Limits.MatrixCountInContainer = matrices.Count;

            if (Limits.MatrixCountInContainer >= 0 && Limits.MatrixCountInContainer != matrices.Count)
                throw new Exception("Each container in a containers collection contains the same number of matrices"); 

            #endregion

            _matrixList = matrices;
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
        public Matrix<IContainer> this[int i]
        {
            get
            {
                return (_matrixList[i] as Matrix<IContainer>);
            }
        } 

        #endregion

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        public  int Count()
        {
            return _matrixList.Count;
        }
    }
}
