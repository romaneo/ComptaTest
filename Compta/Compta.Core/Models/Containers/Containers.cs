﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public class Containers<T> : IContainer where T : IContainer
    {
        private List<T> _containersList;
        int position = -1;

        /// <summary>
        /// Returns a collection of items from the Container
        /// </summary>
        public List<T> GetItems
        {
            get
            {
                return _containersList;
            }
        }

        /// <summary>
        /// Initialize a new instance of the Containers
        /// </summary>
        /// <param name="containers">List of container</param>
        public Containers(List<T> containers)
        {
            _containersList = containers;
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
            return (position < _containersList.Count());
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
            get { return _containersList[position]; }
        }

        /// <summary>
        /// Gets the element at the specified index
        /// </summary>
        /// <param name="i">index of the element</param>
        /// <returns></returns>
        public Container<IContainer> this[int i]
        {
            get
            {
                return (_containersList[i] as Container<IContainer>);
            }
        } 

        #endregion

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _containersList.Count;
        }
    }
}
