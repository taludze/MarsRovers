using System;

namespace MarsRover.Abstraction
{
    public interface IPosition : IDisposable
    {
        int XCoordinate { get; set; }

        int YCoordinate { get; set; }
    }
}
