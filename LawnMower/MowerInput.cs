using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower
{

    public enum MowerCommand { Move, Left, Right };
    public enum CompassDirection { North, South, East, West };

    public class MowerInput
    {
        public int GridX { get; set; }
        public int GridY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public CompassDirection Direction { get; set; }
        public List<MowerCommand> Commands { get; set; }

        public MowerInput ParseMowerInput(string gridDimensionsAndStartingDirection, string commands, string gridSize)
        {
            MowerInput moverInput = new MowerInput();
            int temp;
            string[] gridcoordinates = gridSize.Split(' ');
          
            if (int.TryParse(gridcoordinates[0], out temp))
            {
                moverInput.GridX = temp;
            }

            if (int.TryParse(gridcoordinates[1], out temp))
            {
                moverInput.GridY = temp;
            }
          
            string[] data = gridDimensionsAndStartingDirection.Split(' ');
            if (int.TryParse(data[0], out temp))
            {
                moverInput.X = temp;
            }

            if (int.TryParse(data[1], out temp))
            {
                moverInput.Y = temp;
            }

            string cdirection = data[2];
            char cc;
            cc = cdirection.ToCharArray()[0];
            moverInput.Direction = ParseCompassDirection(cc);

            List<MowerCommand> mowerCommands = new List<MowerCommand>();

            var chars = commands.ToCharArray();
            foreach (char c in chars)
            {
                MowerCommand Commands = ParseMowerCommand(c);
                mowerCommands.Add(Commands);
            }
            moverInput.Commands = mowerCommands;

            return moverInput;
        }

        private MowerCommand ParseMowerCommand(char command)
        {
            switch (command)
            {
                case 'M':
                    return MowerCommand.Move;
                case 'L':
                    return MowerCommand.Left;
                case 'R':
                    return MowerCommand.Right;
                default:
                    throw new NotImplementedException();
            }
        }

        private CompassDirection ParseCompassDirection(char directionAbbreviation)
        {
            switch (directionAbbreviation)
            {
                case 'N':
                    return CompassDirection.North;
                case 'S':
                    return CompassDirection.South;
                case 'E':
                    return CompassDirection.East;
                case 'W':
                    return CompassDirection.West;
                default:
                    throw new ArgumentException("Not a valid direction");
            }
        }
    }
       
}
