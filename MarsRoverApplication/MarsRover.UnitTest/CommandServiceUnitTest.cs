using MarsRover.Abstraction;
using MarsRover.Common;
using MarsRover.Domain;
using MarsRover.Service;
using Xunit;

namespace MarsRover.UnitTest
{
    public class CommandServiceUnitTest
    {
        [Fact]
        public void Test()
        {
            var commandService =  new CommandService();
            var firstRover = commandService.GetRoverLastPositionOnPlateu(new Rover()
            {
                XCoordinate = 1,
                YCoordinate = 2,
                CardinalCompassPointType = CardinalCompassPointType.N,
                Movements = "LMLMLMLMM".GetMovements(),
            });

            var expectedFirstRover = new Rover()
            {
                XCoordinate = 1,
                YCoordinate = 3,
                CardinalCompassPointType = CardinalCompassPointType.N,
                Movements = "LMLMLMLMM".GetMovements(),
            };

            Assert.Equal(expectedFirstRover.XCoordinate, firstRover.XCoordinate);
            Assert.Equal(expectedFirstRover.YCoordinate, firstRover.YCoordinate);
            Assert.Equal(expectedFirstRover.CardinalCompassPointType, firstRover.CardinalCompassPointType);

            var secondRover = commandService.GetRoverLastPositionOnPlateu(new Rover()
            {
                XCoordinate = 3,
                YCoordinate = 3,
                CardinalCompassPointType = CardinalCompassPointType.E,
                Movements = "MMRMMRMRRM".GetMovements(),
            });

            var expectedSecondRover = new Rover()
            {
                XCoordinate = 5,
                YCoordinate = 1,
                CardinalCompassPointType = CardinalCompassPointType.E,
                Movements = "MMRMMRMRRM".GetMovements(),
            };

            Assert.Equal(expectedSecondRover.XCoordinate, secondRover.XCoordinate);
            Assert.Equal(expectedSecondRover.YCoordinate, secondRover.YCoordinate);
            Assert.Equal(expectedSecondRover.CardinalCompassPointType, secondRover.CardinalCompassPointType);

        }
    }
}
