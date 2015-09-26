﻿using Compta.Core.Models.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public class Position<T> : IContainer where T : IPoint
    {
        private List<T> _pointList;
        int position = -1;

        public List<T> GetItems
        {
            get
            {
                return _pointList;
            }
        }

        public Position(List<T> points)
        {
            _pointList = points;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _pointList.Count());
        }

        //IEnumerable
        public void Reset()
        {
            position = 0;
        }

        //IEnumerable
        public object Current
        {
            get { return _pointList[position]; }
        }

        public IPoint this[int i]
        {
            get
            {
                return _pointList[i];
            }
        }


    }
}
