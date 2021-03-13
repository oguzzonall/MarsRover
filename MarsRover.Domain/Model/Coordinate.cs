using MarsRover.Core.Enums;

namespace MarsRover.Domain.Model
{
    public class Coordinate
    {
        public Coordinate()
        {
            Direction = Directions.N;
            X = 0;
            Y = 0;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
    }
}