using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Common
{
    public static class MovementExtensions
    {
        public static List<MovementType> GetMovements(this string movementText)
        {
            if (string.IsNullOrEmpty(movementText))
            {
                throw new ArgumentException("Please enter movement");
            }

            var movemements = movementText.Select(letter => letter.ToString()).ToList();

            List<string> GetMovementTypes()
            {
                return new List<string>()
                {
                   MovementType.L.GetDescription(),
                   MovementType.M.GetDescription(),
                   MovementType.R.GetDescription(),
                };
            }

            var control = movemements.Any(x => !GetMovementTypes().Contains(x)); 
            if (control)
            {
                throw new ArgumentException("Wrong movement");
            }

            var test = new List<MovementType>();
            movemements.ForEach(x=> {
                switch (x)
                {
                    case "M":
                        test.Add(MovementType.M);
                        break;
                    case "L":
                        test.Add(MovementType.L);
                        break;
                    case "R":
                        test.Add(MovementType.R);
                        break;
                    default:
                        break;
                }

            });
            return test;
        }
    }
}
