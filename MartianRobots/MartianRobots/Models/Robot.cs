namespace MartianRobots.Models
{
    /// <summary>
    /// A robot on <see cref="Mars"/> that gets instructions from Earth.
    /// </summary>
    public class Robot
    {
        /// <summary>
        /// Gets or sets the X coordinate on Mars that the robot is on.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y cooridnate on Mars that the robot is on.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the compass orintation that the Robot is facing.
        /// e.g N (North), S (South), E (East), W (West)
        /// </summary>
        public char Orientation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the robot is lost. 
        /// This means that the robot has gone out of bounds of the planet Mars.
        /// </summary>
        public bool IsLost { get; set; }

        public Robot(int x, int y, char orientation)
        {
            X = x;
            Y = y; 
            Orientation = orientation;
            IsLost = false;
        }

        /// <summary>
        /// Updates the position of the robot.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public void UpdateCoordinates(int  x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Updates the direction that the robot is facing. 
        /// </summary>
        /// <param name="orientation">N, E, S, W</param>
        public void UpdateOrientation(char orientation)
        {
            Orientation = orientation;
        }
    }
}
