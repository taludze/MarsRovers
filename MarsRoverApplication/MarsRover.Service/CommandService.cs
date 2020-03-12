using MarsRover.Abstraction;
using MarsRover.Common;
using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarsRover.Service
{
    public class CommandService : ICommandService
    {

        public Task ProcessAsync(List<IRover> rovers)
        {
            return Task.Run(() =>
                rovers.ForEach(rover =>
                {
                    this.GetRoverLastPositionOnPlateu(rover);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"{rover.XCoordinate} {rover.YCoordinate} {rover.CardinalCompassPointType}");
                }));
        }

        public IRover GetRoverLastPositionOnPlateu(IRover rover)
        {
            rover.Movements.ForEach(movement =>
            {
                this.GetRoverLastPositionByMovementType(rover, movement);
            });
            return rover;
        }

        private IRover GetRoverLastPositionByMovementType(IRover rover, MovementType movementType)
        {
            if (movementType == MovementType.M)
            {
                (rover.XCoordinate, rover.YCoordinate, rover.CardinalCompassPointType) = this.GetPositionByMove(rover.XCoordinate, rover.YCoordinate, rover.CardinalCompassPointType);
            }
            else
            {
                var turnType = movementType == MovementType.L ? TurnType.Left : TurnType.Right;
                rover.CardinalCompassPointType = this.GetDirectionTypeRotate(rover.CardinalCompassPointType, turnType);
            }

            return rover;
        }


        private (int xCoordinate, int yCoordinate, CardinalCompassPointType direction) GetPositionByMove(int xCoordinate, int yCoordinate, CardinalCompassPointType direction)
        {
            switch (direction)
            {
                case CardinalCompassPointType.N:
                    yCoordinate++;
                    break;
                case CardinalCompassPointType.E:
                    xCoordinate++;
                    break;
                case CardinalCompassPointType.S:
                    yCoordinate--;
                    break;
                case CardinalCompassPointType.W:
                    xCoordinate--;
                    break;
                default:
                    break;
            }
            return (xCoordinate, yCoordinate, direction);
        }

        private CardinalCompassPointType GetDirectionTypeRotate(CardinalCompassPointType directionType, TurnType turnType)
        {
            if (turnType == TurnType.Left)
            {
                directionType = GetCardinalCompassPointByTurnLeft(directionType);
            }
            else if (turnType == TurnType.Right)
            {
                directionType = GetCardinalCompassPointByTurnRight(directionType);
            }
            else
            {
                throw new ArgumentException($"{turnType} Turn type is not find");
            }

            return directionType;
        }

        private static CardinalCompassPointType GetCardinalCompassPointByTurnLeft(CardinalCompassPointType cardinalCompassPointType)
        {
            switch (cardinalCompassPointType)
            {
                case CardinalCompassPointType.N:
                    cardinalCompassPointType = CardinalCompassPointType.W;
                    break;
                case CardinalCompassPointType.E:
                    cardinalCompassPointType = CardinalCompassPointType.N;
                    break;
                case CardinalCompassPointType.S:
                    cardinalCompassPointType = CardinalCompassPointType.E;
                    break;
                case CardinalCompassPointType.W:
                    cardinalCompassPointType = CardinalCompassPointType.S;
                    break;
                default:
                    throw new ArgumentException($"{cardinalCompassPointType} cardinal compass point is not defined.");
            }

            return cardinalCompassPointType;
        }

        private static CardinalCompassPointType GetCardinalCompassPointByTurnRight(CardinalCompassPointType cardinalCompassPointType)
        {
            switch (cardinalCompassPointType)
            {
                case CardinalCompassPointType.N:
                    cardinalCompassPointType = CardinalCompassPointType.E;
                    break;
                case CardinalCompassPointType.E:
                    cardinalCompassPointType = CardinalCompassPointType.S;
                    break;
                case CardinalCompassPointType.S:
                    cardinalCompassPointType = CardinalCompassPointType.W;
                    break;
                case CardinalCompassPointType.W:
                    cardinalCompassPointType = CardinalCompassPointType.N;
                    break;
                default:
                    throw new ArgumentException($"{cardinalCompassPointType} cardinal compass point is not defined.");
            }

            return cardinalCompassPointType;
        }

        public void Dispose()
        {
        }

        ~CommandService()
        {
        }
    }
}
