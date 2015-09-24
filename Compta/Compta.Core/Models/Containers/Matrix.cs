using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public class Matrix<T>: IContainer where T: IContainer
    {
        private List<T> _positionList;

        List<T> PositionList
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
    }
}
