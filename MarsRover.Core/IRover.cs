using MarsRover.Core.Constants;

namespace MarsRover.Core
{
    public interface IRover
    {
        Direction Direction { get; set; }
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
    }
}