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
    }
}
