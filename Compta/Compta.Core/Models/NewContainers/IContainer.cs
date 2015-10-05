using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
    /// <summary>
    /// Base interface for different types of container
    /// </summary>
    public interface IContainer : IEnumerable, IEnumerator
    {
        /// <summary>
        /// Returns the type of inner element by index 
        /// </summary>
        /// <param name="index">Index of the element</param>
        /// <returns></returns>
        Type GetElementType(int index = 0);

        /// <summary>
        /// Returns an array of types of inner items
        /// </summary>
        /// <returns></returns>
        Type[] GetElementTypes();

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        int Count { get; }
    }
}
