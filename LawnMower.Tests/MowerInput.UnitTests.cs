using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LawnMower.Tests
{
    [TestClass]
    public class MowerInputUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseCompassDirection_WhenPassingNotValidCompassDirection_MustThrowException()
        {
            char ch = 'T';
            MowerInput mowerInput = new MowerInput();
            MowerInput.ParseCompassDirection(ch);
        }

        [TestMethod]
        public void ParseCompassDirection_WhenPassingValidCompassDirection()
        {
            char ch = 'N';
            MowerInput mowerInput = new MowerInput();
            CompassDirection direction = MowerInput.ParseCompassDirection(ch);
            Assert.AreEqual(CompassDirection.North, direction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseMowerCommand_WhenPassingNotAValidCommand_MustThrowException()
        {
            char ch = 'C';
            MowerInput mowerInput = new MowerInput();
            MowerInput.ParseMowerCommand(ch);
        }

        [TestMethod]
        public void ParseMowerCommand_WhenPassingValidCommand()
        {
            char ch = 'M';
            MowerInput mowerInput = new MowerInput();
            MowerCommand command = MowerInput.ParseMowerCommand(ch);
            Assert.AreEqual(MowerCommand.Move, command);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseMowerInput_WhenGridDimentionCoordinatesNotAInteger_MustThrowException()
        {
            string gridsize = "C T";
            string cmd = "";
            MowerInput mowerInput = new MowerInput();
            MowerInput.ParseMowerInput(gridsize,cmd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseMowerInput_WhenPassingNullValueForGridDimentionCoordinates_MustThrowException()
        {
            string gridsize = " ";
            string cmd = "MLR";
            MowerInput mowerInput = new MowerInput();
            MowerInput.ParseMowerInput(gridsize, cmd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseMowerInput_WWhenPassingNullValueForCommands_MustThrowException()
        {
            string gridsize = "10 10 N";
            string cmd = " ";
            MowerInput mowerInput = new MowerInput();
            MowerInput.ParseMowerInput(gridsize, cmd);
        }
    }
}
