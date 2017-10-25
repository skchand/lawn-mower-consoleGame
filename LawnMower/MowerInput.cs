using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public static MowerInput ParseMowerInput(string gridDimensionsAndStartingDirection, string commands)
        {
            MowerInput parsedMoverInput = new MowerInput();
            int temp;
           
                    string[] data = gridDimensionsAndStartingDirection.Split(' ');
                    if (int.TryParse(data[0], out temp))
                    {
                       parsedMoverInput.X = temp;
                    }
                    else { throw new ArgumentException("Not an integer"); }

                    if (int.TryParse(data[1], out temp))
                    {
                      parsedMoverInput.Y = temp;
                    }
                    else { throw new ArgumentException("Not an integer"); }

                string cdirection = data[2];
                char cc;
                cc = cdirection.ToCharArray()[0];
                 parsedMoverInput.Direction = ParseCompassDirection(cc);

                List<MowerCommand> mowerCommands = new List<MowerCommand>();

                var chars = commands.ToCharArray();
                foreach (char c in chars)
                {
                    MowerCommand Commands = ParseMowerCommand(c);
                    mowerCommands.Add(Commands);
                }
                parsedMoverInput.Commands = mowerCommands;
                return parsedMoverInput;
         }

        private static MowerCommand ParseMowerCommand(char command)
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
                    throw new ArgumentException("Not a valid mover command");
            }
        }

        private static CompassDirection ParseCompassDirection(char directionAbbreviation)
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
