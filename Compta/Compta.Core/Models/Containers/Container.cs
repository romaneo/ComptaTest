﻿using System;
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

        public List<T> GetItems
        {
            get
            {
                return _matrixList;
            }
        }

        public Container(List<T> matrixs)
        {
            _matrixList = matrixs;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _matrixList.Count());
        }

        //IEnumerable
        public void Reset()
        {
            position = 0;
        }

        //IEnumerable
        public object Current
        {
            get { return _matrixList[position]; }
        }

        public Matrix<IContainer> this[int i]
        {
            get
            {
                return (_matrixList[i] as Matrix<IContainer>);
            }
        }
    }
}
