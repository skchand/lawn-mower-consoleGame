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

        internal MowerInput ProcessCommands(MowerInput mower)
        {
            ValidatePosition(mower);
            ValidateCommands(mower);
            foreach (var command in mower.Commands)
            {

                ProcessNextPosition(mower, command);

                ValidatePosition(mower);

            }

            return mower;
        }

        internal void ProcessNextPosition(MowerInput mower, MowerCommand command)
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

        internal void ValidatePosition(MowerInput mower)
        {

            if (mower.X < 0 ||
                mower.X > gridX ||
                mower.Y < 0 ||
                mower.Y > gridY)
            {
                throw new ArgumentException("Invalid Grid Coordinates");
            }
        }
        internal void ValidateCommands(MowerInput mower)
        {
            if (mower.Commands == null || mower.Commands.Count == 0)
            {
                throw new ArgumentNullException("Commands set to null");
            }
        }
    }
}
