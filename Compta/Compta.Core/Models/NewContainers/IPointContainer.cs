using System.Collections;

namespace Pmc.Core.Models.NewContainers
{
    public interface IPointContainer: IEnumerable
    {
        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        int Count { get; }
    }
}
