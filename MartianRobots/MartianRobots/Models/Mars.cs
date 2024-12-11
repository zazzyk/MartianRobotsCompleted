using System.Collections.Generic;

namespace MartianRobots.Models
{
    /// <summary>
    /// Mars is a rectangular grid.(x,y)
    /// </summary>
    public class Mars
    {
        /// <summary>
        /// Gets or sets the max x of the coordinate of Mars, set by the input 
        /// </summary>
        public int MaxXCooridnate { get; set; }

        /// <summary>
        /// Gets or sets the max y coordinate of Mars, set by the input
        /// </summary>
        public int MaxYCoordiante { get; set; }

        /// <summary>
        /// Gets or sets a lists of scents, which are coordiantes that robots have been "lost".
        /// <see cref="Robot.IsLost"/>
        /// </summary>
        public HashSet<(int, int)> Scents { get; } = [];

        public Mars(int maxX,  int maxY)
        {
            MaxXCooridnate = maxX;
            MaxYCoordiante = maxY;
            Scents = new HashSet<(int, int)>();
        }

        /// <summary>
        /// Calculates whether the robot has gone out of the bounds of Mars
        /// </summary>
        /// <param name="x">X coordinate to check</param>
        /// <param name="y">Y coordinate to check</param>
        /// <returns></returns>
        public bool IsOutOfBounds(int x, int y)
        {
            return x < 0 || x > MaxXCooridnate || y < 0 || y > MaxYCoordiante;
        }

        /// <summary>
        /// If a robot is lost (has gone out of bounds of Mars),
        /// this adds the coorindate it was lost to leave as a scent for other robots.
        /// </summary>
        /// <param name="x">X coordinate of Mars</param>
        /// <param name="y">Y cooridinate of Mars</param>
        public void LeaveScent(int x, int y)
        {
            Scents.Add((x, y));
        }

        /// <summary>
        /// Checks whethere the coorindates has a Scent.
        /// If the cooridnates have a scent, the robot will not move there.
        /// </summary>
        /// <param name="x">X coordinate to check</param>
        /// <param name="y">Y coordinate to check</param>
        /// <returns></returns>
        public bool HasScent(int x, int y)
        {
            return Scents.Contains((x, y));
        }
    }
}
