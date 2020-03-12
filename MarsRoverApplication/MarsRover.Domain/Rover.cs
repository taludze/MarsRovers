using MarsRover.Abstraction;
using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public class Rover : IRover
    {
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public CardinalCompassPointType CardinalCompassPointType { get; set; }

        public List<MovementType> Movements { get; set; }

        public void Dispose()
        {
        }

        ~Rover()
        {
        }
    }
}
