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
    }
}
