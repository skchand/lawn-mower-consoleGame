using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower
{
    public class Engine
    {

        private int gridX { get; set; }
        private int gridY { get; set; }

        public Engine(LawnDimension gridSize)
        {
            this.gridX = gridSize.GridX;
            this.gridY = gridSize.GridY;
        }

        internal void ProcessCommands(MowerInput mower)
        {
            Console.WriteLine($"Initial Position: ({mower.X}, {mower.Y}) Direction:({mower.Direction}) ");
            ValidatePosition(mower);
            foreach (var command in mower.Commands)
            {

                ProcessNextPosition(mower, command);
                DrawFrame(mower);
                ValidatePosition(mower);
             
            }
            Console.WriteLine($"New Position: ({mower.X}, {mower.Y}) Direction:({mower.Direction}) ");
            Console.ReadLine();
        }

        private void ProcessNextPosition(MowerInput mower, MowerCommand command)
        {
            switch (mower.Direction)
            {
                case CompassDirection.North:
                    if (command == MowerCommand.Move)
                    {
                        mower.Y = mower.Y + 1;
                    }

                    else if (command == MowerCommand.Right)
                    {
                        mower.Direction = CompassDirection.East;
                    }

                    else if (command == MowerCommand.Left)
                    {
                        mower.Direction = CompassDirection.West;
                    }
                    break;

                case CompassDirection.South:
                    if (command == MowerCommand.Move)
                    {
                        mower.Y = mower.Y - 1;
                    }
                    else if (command == MowerCommand.Right)
                    {
                        mower.Direction = CompassDirection.West;
                    }

                    else if (command == MowerCommand.Left)
                    {
                        mower.Direction = CompassDirection.East;
                    }
                    break;

                case CompassDirection.East:
                    if (command == MowerCommand.Move)
                    {
                        mower.X = mower.X + 1;
                    }

                    else if (command == MowerCommand.Right)
                    {
                        mower.Direction = CompassDirection.South;
                    }

                    else if (command == MowerCommand.Left)
                    {
                        mower.Direction = CompassDirection.North;
                    }
                    break;

                case CompassDirection.West:
                    if (command == MowerCommand.Move)
                    {
                        mower.X = mower.X - 1;
                    }
                    else if (command == MowerCommand.Right)
                    {
                        mower.Direction = CompassDirection.North;
                    }

                    else if (command == MowerCommand.Left)
                    {
                        mower.Direction = CompassDirection.South;
                    }
                    break;

                default:
                    throw new ArgumentException("Not a valid direction");
            }
        }

        private void ValidatePosition(MowerInput mower)
        {
            
            if (mower.X <= 0 ||
                mower.X >= gridX ||
                mower.Y <= 0 ||
                mower.Y >= gridY)
            {
                throw new ArgumentException("Invalid Coordinates");
            }
        }

        private void DrawFrame(MowerInput mower)
        {

        }

        //    return endPosition
    }
}
