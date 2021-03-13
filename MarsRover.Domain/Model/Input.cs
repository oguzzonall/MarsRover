namespace MarsRover.Domain.Model
{
    public class Input
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public string StartDirection { get; set; }
        public string Moves { get; set; }
    }
}
