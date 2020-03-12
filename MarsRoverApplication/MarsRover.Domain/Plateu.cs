using MarsRover.Abstraction;

namespace MarsRover.Domain
{
    public class Plateu : IPlateu
    {
        public IPosition Position { get; set; }

        public Plateu(IPosition position)
        {
            this.Position = position;
        }

        public void Dispose()
        {
        }

        ~Plateu()
        {
        }
    }
}
