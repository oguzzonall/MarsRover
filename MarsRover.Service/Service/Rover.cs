using MarsRover.Core.Enums;
using MarsRover.Domain.Model;
using MarsRover.Service.IService;
using System;
using System.Collections.Generic;

namespace MarsRover.Service.Service
{
    public class Rover : IRover
    {
        public Coordinate Move(List<int> MaxLimits, string Moves, Coordinate StartCoordinate)
        {
            foreach (var move in Moves)
            {
                switch (move)
                {
                    case 'M':
                        MoveInTheSameDirection(StartCoordinate);
                        break;
                    case 'L':
                        TurnLeft90Degrees(StartCoordinate);
                        break;
                    case 'R':
                        TurnRight90Degrees(StartCoordinate);
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }

                MaxLimitsControl(MaxLimits, StartCoordinate);
            }

            return StartCoordinate;
        }

        public Coordinate TurnRight90Degrees(Coordinate StartCoordinate)
        {
            switch (StartCoordinate.Direction)
            {
                case Directions.N:
                    StartCoordinate.Direction = Directions.E;
                    break;
                case Directions.S:
                    StartCoordinate.Direction = Directions.W;
                    break;
                case Directions.E:
                    StartCoordinate.Direction = Directions.S;
                    break;
                case Directions.W:
                    StartCoordinate.Direction = Directions.N;
                    break;
                default:
                    break;
            }
            return StartCoordinate;
        }

        public Coordinate TurnLeft90Degrees(Coordinate StartCoordinate)
        {
            switch (StartCoordinate.Direction)
            {
                case Directions.N:
                    StartCoordinate.Direction = Directions.W;
                    break;
                case Directions.S:
                    StartCoordinate.Direction = Directions.E;
                    break;
                case Directions.E:
                    StartCoordinate.Direction = Directions.N;
                    break;
                case Directions.W:
                    StartCoordinate.Direction = Directions.S;
                    break;
                default:
                    break;
            }
            return StartCoordinate;
        }

        public Coordinate MoveInTheSameDirection(Coordinate StartCoordinate)
        {
            switch (StartCoordinate.Direction)
            {
                case Directions.N:
                    StartCoordinate.Y += 1;
                    break;
                case Directions.S:
                    StartCoordinate.Y -= 1;
                    break;
                case Directions.E:
                    StartCoordinate.X += 1;
                    break;
                case Directions.W:
                    StartCoordinate.X -= 1;
                    break;
                default:
                    break;
            }
            return StartCoordinate;
        }

        public void MaxLimitsControl(List<int> MaxLimits, Coordinate StartCoordinate)
        {
            if (StartCoordinate.X < 0 || StartCoordinate.X > MaxLimits[0] || StartCoordinate.Y < 0 || StartCoordinate.Y > MaxLimits[1])
            {
                throw new Exception($"Coordinates entered were outside the maximum limit.");
            }
        }
    }
}