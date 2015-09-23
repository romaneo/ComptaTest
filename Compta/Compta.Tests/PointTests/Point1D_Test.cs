using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Compta.Core.Models.Point;

namespace Compta.Tests
{
    [TestClass]
    public class Point1D_Test
    {
        [TestMethod]
        public void Create1DPoint_WithDefaultValue()
        {
            var point = new Point1D<int>();
            Assert.IsNotNull(point);
            Assert.AreEqual(point.X, 0);
        }

        [TestMethod]
        public void Create1DPoint_WithUserValue()
        {
            var point = new Point1D<int>(97);
            Assert.AreEqual(point.X, 97);
        }
    }
}
