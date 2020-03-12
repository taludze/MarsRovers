using MarsRover.Abstraction;

namespace MarsRover.Domain
{
    public class Position : IPosition
    {
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public void Dispose()
        {
        }

        ~Position()
        {
        }
    }
}
