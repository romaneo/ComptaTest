using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public class Container<T>: IContainer where T: IContainer
    {
        private List<T> _matrixList;

        List<T> MatrixList
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
    }
}
