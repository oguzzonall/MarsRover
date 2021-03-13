using MarsRover.Domain.Model;
using System.Collections.Generic;

namespace MarsRover.Service.IService
{
    public interface IRover
    {
        Coordinate Move(List<int> MaxLimits, string Moves, Coordinate StartCoordinate);
        Coordinate TurnRight90Degrees(Coordinate StartCoordinate);
        Coordinate TurnLeft90Degrees(Coordinate StartCoordinate);
        Coordinate MoveInTheSameDirection(Coordinate StartCoordinate);
        void MaxLimitsControl(List<int> MaxLimits, Coordinate StartCoordinate);
    }
}