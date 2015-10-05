using Compta.Core.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Models.NewContainers
{
   /// <summary>
    /// Represents a container of indexed collection of matrix
   /// </summary>
    public class Container: IContainer, IEnumerable<Matrix>
    {
        List<Matrix> _matrixList;
        int position = -1;

        /// <summary>
        /// Initialize a new instance of the Container
        /// </summary>
        /// <param name="matrices">List of matrices</param>
        public Container(List<Matrix> matrices)
        {

            #region Check Each container in a containers collection contains the same number of matrices

            if (Limits.MatrixCountInContainer < 0)
                Limits.MatrixCountInContainer = matrices.Count;

            if (Limits.MatrixCountInContainer >= 0 && Limits.MatrixCountInContainer != matrices.Count)
                throw new Exception("Each container in a containers collection contains the same number of matrices");

            #endregion

            #region Check Type of each indexed matrix will be the same across containers

            //fill dicttionary[index, type] if it is a first conteiner
            if (Limits.MatrixCountInContainer > 0 && Limits.IndexedMatrixType == null)
            {
                Limits.IndexedMatrixType = new Dictionary<int, Type>();

                for (int i = 0; i < matrices.Count; i++)
                {
                    Limits.IndexedMatrixType.Add(i, matrices[i].GetElementType());
                }
            }

            //Check that all indexed matrix are same type using dicttionary[index, type]
            if (Limits.MatrixCountInContainer > 0 && Limits.IndexedMatrixType != null)
            {
                for (int i = 0; i < matrices.Count; i++)
                {
                    Type type = matrices[i].GetElementType();
                    if (type != Limits.IndexedMatrixType[i])
                        throw new Exception("Type of each indexed matrix will be the same across containers");

                }
            }

            #endregion

            #region Check The number of data points at each XYZ position will be the same across equivalent matrix indexes across containers.

            //fill dictionary[index, pointCount]
            if (Limits.Indexed3DMatrixPointCount == null || Limits.Indexed3DMatrixPointCount.Count < matrices.Count)
            {
                Limits.Indexed3DMatrixPointCount = new Dictionary<int, int>();

                for (int i = 0; i < matrices.Count; i++)
                {
                    Limits.Indexed3DMatrixPointCount.Add(i, matrices[i].GetItems[0].Count);
                }
            }

            //check number of data points on equivalent  matrix indexes across container
            if (Limits.Indexed3DMatrixPointCount != null && Limits.Indexed3DMatrixPointCount.Count >= matrices.Count)
            {
                for (int i = 0; i < matrices.Count; i++)
                {
                    if (Limits.Indexed3DMatrixPointCount[i] != matrices[i].GetItems[0].Count)
                        throw new Exception("The number of data points at each XYZ position will be the same across equivalent matrix indexes across containers.");
                }
            }

            #endregion


            _matrixList = matrices;
        }

        /// <summary>
        /// Returns a collection of items from the Container
        /// </summary>
        public List<Matrix> GetItems
        {
            get
            {
                return _matrixList;
            }
        }

        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
         IEnumerator<Matrix> IEnumerable<Matrix>.GetEnumerator()
        {
            return _matrixList.Cast<Matrix>().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            position++;
            return (position < _matrixList.Count());
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            position = 0;
        }

        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        public object Current
        {
            get { return _matrixList[position]; }
        }

        /// <summary>
        /// Gets the element at the specified index
        /// </summary>
        /// <param name="i">index of the element</param>
        /// <returns></returns>
        public Matrix this[int i]
        {
            get
            {
                return _matrixList[i];
            }
        }

        #endregion

        #region IContainer

        /// <summary>
        /// Returns the type of inner element by index 
        /// </summary>
        /// <param name="index">Index of the element</param>
        /// <returns></returns>
        public Type GetElementType(int index = 0)
        {
            return _matrixList[index].GetType();
        }
        
        /// <summary>
        /// Returns an array of types of inner items
        /// </summary>
        /// <returns></returns>
        public Type[] GetElementTypes()
        {
            return _matrixList.Select(x => x.GetType()).ToArray();
        }

        /// <summary>
        /// Gets the numbers of elements actually contained in container
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get
            {
                return _matrixList.Count;
            }
        }
        #endregion

    }
}
