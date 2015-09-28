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
        }

        public static int PositionCountInMatrix { get; set; }
        public static int MatrixCountInContainer { get; set; } 



    }
}
