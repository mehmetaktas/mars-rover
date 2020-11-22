using MarsRover.Core.Constants;
using System;

namespace MarsRover.Core
{
    public class Rover : IRover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Direction Direction { get; set; }

        public Rover(int width, int height, string position, string commands)
        {
            this.Width = width;
            this.Height = height;

            this.TranslatePosition(position);

            if (!IsSetCoordinates())
                return;

            this.TranslateCommands(commands);
        }

        private void TranslatePosition(string roverPosition)
        {
            var split = roverPosition.Split(' ');
            Direction currentDirection = (Direction)Enum.Parse(typeof(Direction), split[2], true);

            this.XCoordinate = Convert.ToInt32(split[0]);
            this.YCoordinate = Convert.ToInt32(split[1]);
            this.Direction = currentDirection;
        }

        private void TranslateCommands(string roverCommands)
        {
            char[] commands = roverCommands.ToCharArray();

            foreach (char command in commands)
            {
                var currentEnum = (Commands)command;

                switch (currentEnum)
                {
                    case Commands.Move:
                        this.Move();
                        break;

                    default:
                        this.Rotate(currentEnum);
                        break;
                }
            }
        }

        private bool IsSetCoordinates()
        {
            return (this.XCoordinate >= 0) && (this.XCoordinate < Width) && (this.YCoordinate >= 0) && (this.YCoordinate < Height);
        }

        private void Move()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.YCoordinate += 1;
                    break;

                case Direction.E:
                    this.XCoordinate += 1;
                    break;

                case Direction.S:
                    this.YCoordinate -= 1;
                    break;

                case Direction.W:
                    this.XCoordinate -= 1;
                    break;
            }
        }

        private void Rotate(Commands directionCommand)
        {
            switch (directionCommand)
            {
                case Commands.Left:
                    this.TurnLeft();
                    break;

                case Commands.Right:
                    this.TurnRight();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.W;
                    break;

                case Direction.W:
                    this.Direction = Direction.S;
                    break;

                case Direction.S:
                    this.Direction = Direction.E;
                    break;

                case Direction.E:
                    this.Direction = Direction.N;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.E;
                    break;

                case Direction.E:
                    this.Direction = Direction.S;
                    break;

                case Direction.S:
                    this.Direction = Direction.W;
                    break;

                case Direction.W:
                    this.Direction = Direction.N;
                    break;
            }
        }
    }
}