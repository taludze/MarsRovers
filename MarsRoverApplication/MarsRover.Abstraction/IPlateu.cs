using System;

namespace MarsRover.Abstraction
{
    public interface IPlateu : IDisposable
    {
        IPosition Position { get; set; }
    }
}
