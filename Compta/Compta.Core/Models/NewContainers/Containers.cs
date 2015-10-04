using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
    public class Containers:IContainer, IEnumerable<Container>
    {
        List<Container> _containersList;
        int position = -1;

        public Containers(List<Container> containers)
        {
            _containersList = containers;
        }

        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator<Container> IEnumerable<Container>.GetEnumerator()
        {
            return _containersList.Cast<Container>().GetEnumerator();
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
        public IContainer this[int i]
        {
            get
            {
                return (_containersList[i]);
            }
        }

        #endregion

        #region IContainer
        public Type GetElemetType(int index = 0)
        {
            return _containersList[index].GetType();
        }

        public Type[] GetElementTypes()
        {
            return _containersList.Select(x => x.GetType()).ToArray();
        }

        public int Count
        {
            get
            {
                return _containersList.Count;
            }
        }
        #endregion
    }
}
