using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
    public interface IContainer : IEnumerable, IEnumerator
    {
        Type GetElemetType(int index = 0);

        Type[] GetElementTypes();

        int Count { get; }
    }
}
