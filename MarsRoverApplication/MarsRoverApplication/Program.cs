using MarsRover.Abstraction;
using MarsRover.Common;
using MarsRover.Domain;
using MarsRover.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarsRoverApplication
{
    class Program 
    {
        static async Task Main(string[] args)
        {
            try
            {
                var platueInformation = Console.ReadLine().Split(' ');
                var platue = new Plateu(new Position()
                {
                       XCoordinate = Convert.ToInt32(platueInformation[0]),
                       YCoordinate = Convert.ToInt32(platueInformation[1]),
                });
                Console.WriteLine("How many rovers?");
                var roverCount = Convert.ToInt32(Console.ReadLine());
                var rovers = new List<IRover>();

                while (roverCount > 0)
                {
                    Console.WriteLine("Please Enter Rover Information!");
                    var roverInformation = Console.ReadLine().Split(' ');
                    var rover = new Rover()
                    {
                        XCoordinate = Convert.ToInt32(roverInformation[0]),
                        YCoordinate = Convert.ToInt32(roverInformation[1]),
                        CardinalCompassPointType = (CardinalCompassPointType)Enum.Parse(typeof(CardinalCompassPointType),roverInformation[2]),
                        Movements = Console.ReadLine().GetMovements(),
                    };
                    rovers.Add(rover);
                    roverCount--;
                }

                var commandService = new CommandService();
                await commandService.ProcessAsync(rovers).ConfigureAwait(true);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Request successful.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
