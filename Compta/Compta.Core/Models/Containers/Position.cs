using Compta.Core.Models.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public class Position<T> : IContainer where T: IPoint
    {
        private List<T> _pointList;

        List<T> PointList
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
    }
}
