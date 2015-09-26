﻿using Compta.Core.Models.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public class Matrix<T> : IContainer where T : IContainer
    {
        private List<T> _positionList;
        int position = -1;

        public List<T> GetItems
        {
            get
            {
                return _positionList;
            }
        }

        public Matrix(List<T> positions)
        {
            _positionList = positions;
        }


        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _positionList.Count());
        }

        //IEnumerable
        public void Reset()
        {
            position = 0;
        }

        //IEnumerable
        public object Current
        {
            get { return _positionList[position]; }
        }

        public Position<IPoint> this[int i]
        {
            get
            {
                return (_positionList[i] as Position<IPoint>);
            }
        }
    }
}
