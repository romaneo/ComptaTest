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

        public List<T> GetItems
        {
            get
            {
                return _containersList;
            }
        }

        public Containers(List<T> containers)
        {
            _containersList = containers;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _containersList.Count());
        }

        //IEnumerable
        public void Reset()
        {
            position = 0;
        }

        //IEnumerable
        public object Current
        {
            get { return _containersList[position]; }
        }

        public Container<IContainer> this[int i]
        {
            get
            {
                return (_containersList[i] as Container<IContainer>);
            }
        }
    }
}
