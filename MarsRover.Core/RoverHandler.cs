using System.Collections.Generic;

namespace MarsRover.Core
{
    public class RoverHandler : List<IRover>
    {
        private int Width { get; set; }
        private int Height { get; set; }

        public RoverHandler(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void Add(string position, string commands)
        {
            this.Add(new Rover(Width, Height, position, commands));
        }
    }
}