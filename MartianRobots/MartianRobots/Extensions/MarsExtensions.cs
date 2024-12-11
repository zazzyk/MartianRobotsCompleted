using MartianRobots.Models;

namespace MartianRobots.Extensions
{
    public static class MarsExtensions
    {
        /// <summary>
        /// Calculates whether the robot has gone out of the bounds of Mars
        /// </summary>
        /// <param name="x">X coordinate to check</param>
        /// <param name="y">Y coordinate to check</param>
        /// <returns></returns>
        public static bool IsOutOfBounds(this Mars mars, int x, int y)
        {
            return x < 0 || x > mars.MaxXCooridnate || y < 0 || y > mars.MaxYCoordiante;
        }

        /// <summary>
        /// If a robot is lost (has gone out of bounds of Mars),
        /// this adds the coorindate it was lost to leave as a scent for other robots.
        /// </summary>
        /// <param name="x">X coordinate of Mars</param>
        /// <param name="y">Y cooridinate of Mars</param>
        public static void LeaveScent(this Mars mars, int x, int y)
        {
            mars.Scents.Add((x, y));
        }

        /// <summary>
        /// Checks whethere the coorindates has a Scent.
        /// If the cooridnates have a scent, the robot will not move there.
        /// </summary>
        /// <param name="x">X coordinate to check</param>
        /// <param name="y">Y coordinate to check</param>
        /// <returns></returns>
        public static bool HasScent(this Mars mars, int x, int y)
        {
            return mars.Scents.Contains((x, y));
        }
    }
}
