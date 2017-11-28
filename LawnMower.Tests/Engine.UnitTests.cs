using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Tests
{
    [TestClass]
    public class EngineUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessCommands_WhenMowerIsOutOfBounds_MustThrowAnException()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;

            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 100;
            mowerInput.Y = 0;

            var engine = new Engine(lawnDimension);

            engine.ProcessCommands(mowerInput);
        }

      

        [TestMethod]
        public void ValidatePosition_WhenMowerIsAtEdgeOfLowerBounds_MustNotThrowAnException()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;

            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 0;
            mowerInput.Y = 0;
            var engine = new Engine(lawnDimension);

            engine.ValidatePosition(mowerInput);
        }

        [TestMethod]
        public void ValidatePosition_WhenMowerIsAtEdgeOfOuterBounds_MustNotThrowAnException()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;

            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 10;
            mowerInput.Y = 10;
            var engine = new Engine(lawnDimension);

            engine.ValidatePosition(mowerInput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatePosition_WhenMowerIsOutOfLowerBounds_MustThrowAnException()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;

            MowerInput mowerInput = new MowerInput();
            mowerInput.X = -1;
            mowerInput.Y = -1;
            var engine = new Engine(lawnDimension);

            engine.ValidatePosition(mowerInput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatePosition_WhenMowerIsAtOutOfOuterBounds_MustThrowAnException()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;

            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 11;
            mowerInput.Y = 11;
            var engine = new Engine(lawnDimension);

            engine.ValidatePosition(mowerInput);
        }
    }
}
