using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LawnMower.Tests
{
    [TestClass]
    public class LawnDimensionUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void gridDimension_WhenGridCoordinatesNotAInteger_MustThrowException()
        {
            string gridsize = "C T";
            LawnDimension lawnDimension = new LawnDimension();
            LawnDimension.gridDimension(gridsize);
        }

        [TestMethod]
        public void gridDimension_WhenPassingValidGridXCoordinate()
        {
            string gridsize = "1 2";
            var gridX = 1;

            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension = LawnDimension.gridDimension(gridsize);

            Assert.AreEqual(gridX, lawnDimension.GridX);
        }

        [TestMethod]
        public void gridDimension_WhenPassingValidGridYCoordinate()
        {
            string gridsize = "1 2";
            var gridY = 2;

            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension = LawnDimension.gridDimension(gridsize);

            Assert.AreEqual(gridY, lawnDimension.GridY);
        }
    }
}
