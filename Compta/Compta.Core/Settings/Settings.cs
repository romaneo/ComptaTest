using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compta.Core.Settings
{
    static class Limits
    {
        static Limits()
        {
            PositionCountInMatrix = -1;
            MatrixCountInContainer = -1;
            NumericalDataType = null;
            IndexedMatrixType = null;
            Indexed3DMatrixPointCount = null;
        }

        public static Dictionary<int, Type> IndexedMatrixType { get; set; }
        public static Dictionary<int, int> Indexed3DMatrixPointCount { get; set; }
        public static int PositionCountInMatrix { get; set; }
        public static int MatrixCountInContainer { get; set; }
        public static Type NumericalDataType { get; set; }

        #region Check All numerical data across all data in a Containers collection is the same C# numerical type

        /// <summary>
        /// Check all numerical data across all data in a Containers collection is the same C# numerical type
        /// </summary>
        /// <param name="type">Numerical type (e.g. integer, double, decimal)</param>
        /// <returns></returns>
        public static bool CheckNumericalData(Type type)
        {
            if (NumericalDataType == null)
                NumericalDataType = type;

            if (NumericalDataType != null && NumericalDataType != type)                
            {
                throw new Exception("All numerical data across all data in a Containers collection is the same C# numerical type");                
            }

            return true;
        }
            
        #endregion

    }
}
