using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarsRover.Abstraction
{
    public interface ICommandService : IDisposable
    {
        Task ProcessAsync(List<IRover> rovers);
    }
}
