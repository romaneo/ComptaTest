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
        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
