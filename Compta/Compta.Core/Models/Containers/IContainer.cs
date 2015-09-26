﻿using Compta.Core.Models.Point;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.Containers
{
    public interface IContainer : IEnumerator, IEnumerable
    {
        //List<IContainer> GetItems
        //{ get; } 
    }
}
