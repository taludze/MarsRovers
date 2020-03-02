using MarsRover.Common;
using System;
using System.Collections.Generic;

namespace MarsRover.Abstraction
{
    public interface IRover : IDisposable
    {
        int XCoordinate { get; set; }

        int YCoordinate { get; set; }

        CardinalCompassPointType CardinalCompassPointType { get; set; }

        List<MovementType> Movements { get; set; }
    }
}
