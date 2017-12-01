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
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessCommands_WhenMowerHasOutOfBoundCoordinate()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;
            List<MowerCommand> commands = new List<MowerCommand>();
            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 10;
            mowerInput.Y = 5;
            mowerInput.Direction = CompassDirection.East;
            commands.Add(MowerCommand.Move);
            commands.Add(MowerCommand.Left);
            commands.Add(MowerCommand.Right);
            mowerInput.Commands = commands;

            var engine = new Engine(lawnDimension);

            engine.ProcessCommands(mowerInput);
        }
        [TestMethod]
        public void ProcessCommands_WhenMowerHasValidInputs()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;
            List<MowerCommand> commands = new List<MowerCommand>();
            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 5;
            mowerInput.Y = 5;
            mowerInput.Direction = CompassDirection.East;
            commands.Add(MowerCommand.Move);
            commands.Add(MowerCommand.Left);
            commands.Add(MowerCommand.Right);
            mowerInput.Commands = commands;

            var engine = new Engine(lawnDimension);

            engine.ProcessCommands(mowerInput);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcessCommands_WhenMowerHasCommandsAsNullValue_MustThrowException()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;
            List<MowerCommand> commands = new List<MowerCommand>();
            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 10;
            mowerInput.Y = 5;
            mowerInput.Direction = CompassDirection.West;

            var engine = new Engine(lawnDimension);

            engine.ProcessCommands(mowerInput);
        }
        [TestMethod]
        public void ProcessCommands_WhenMowerHasMovedToWest()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;
            List<MowerCommand> commands = new List<MowerCommand>();
            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 5;
            mowerInput.Y = 5;
            mowerInput.Direction = CompassDirection.East;
            commands.Add(MowerCommand.Move);
            commands.Add(MowerCommand.Left);
            commands.Add(MowerCommand.Left);
            mowerInput.Commands = commands;

            var engine = new Engine(lawnDimension);
            var X = 6;
            var mowerOutput = engine.ProcessCommands(mowerInput);
            Assert.AreEqual(CompassDirection.West, mowerOutput.Direction);
            Assert.AreEqual(X, mowerOutput.X);
        }

        [TestMethod]
        public void ProcessCommands_WhenMowerHasMovedToNorth()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;
            List<MowerCommand> commands = new List<MowerCommand>();
            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 5;
            mowerInput.Y = 5;
            mowerInput.Direction = CompassDirection.South;
            commands.Add(MowerCommand.Move);
            commands.Add(MowerCommand.Left);
            commands.Add(MowerCommand.Move);
            commands.Add(MowerCommand.Left);
            mowerInput.Commands = commands;

            var engine = new Engine(lawnDimension);
            var X = 6;
            var Y = 4;
            var mowerOutput = engine.ProcessCommands(mowerInput);
            Assert.AreEqual(CompassDirection.North, mowerOutput.Direction);
            Assert.AreEqual(X, mowerOutput.X);
            Assert.AreEqual(Y, mowerOutput.Y);

        }

        [TestMethod]
        public void ProcessCommands_WhenMowerHasMovedToSouth()
        {
            LawnDimension lawnDimension = new LawnDimension();
            lawnDimension.GridX = 10;
            lawnDimension.GridY = 10;
            List<MowerCommand> commands = new List<MowerCommand>();
            MowerInput mowerInput = new MowerInput();
            mowerInput.X = 5;
            mowerInput.Y = 5;
            mowerInput.Direction = CompassDirection.West;
            commands.Add(MowerCommand.Move);
            commands.Add(MowerCommand.Left);
            commands.Add(MowerCommand.Move);
            mowerInput.Commands = commands;

            var engine = new Engine(lawnDimension);
            var X = 4;
            var Y = 4;
            var mowerOutput = engine.ProcessCommands(mowerInput);
            Assert.AreEqual(CompassDirection.South, mowerOutput.Direction);
            Assert.AreEqual(X, mowerOutput.X);
            Assert.AreEqual(Y, mowerOutput.Y);

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
