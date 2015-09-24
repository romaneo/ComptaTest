using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public class Containers<T>: IContainer where T:IContainer
    {
        private List<T> _containersList;

        List<T> ContainersList
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
    }
}
