using System.ComponentModel.DataAnnotations;
using MartianRobots.Models;

namespace MartianRobots.Extensions
{
    public static class RobotExtensions
    {
        public static void TurnLeft(this Robot robot)
        {
            robot.UpdateOrientation(robot.Orientation switch
            {
                'N' => 'W',
                'E' => 'N',
                'S' => 'E',
                'W' => 'S',
                _ => throw new ArgumentException("Invalid orientation")
            });
        }


        public static void TurnRight(this Robot robot)
        {
            robot.UpdateOrientation(robot.Orientation switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N',
                _ => throw new ArgumentException("Invalid orientation")
            });
        }

        public static void MoveForward(this Robot robot, Mars mars)
        {
            if (robot.IsLost)
            {
                return;
            }

            int newX = robot.X;
            int newY = robot.Y;

            switch (robot.Orientation)
            {
                case 'N': newY++; 
                    break;
                case 'E': newX++;
                    break;
                case 'S': newY--; 
                    break;
                case 'W': newX--; 
                    break;
            }

            // Check if a scent exists at the current position and intended direction
            if (mars.HasScent(newX, newY) || mars.HasScent(robot.X, robot.Y))
            {
                // If there's a scent, ignore the move
                return;
            }

            // Check if the next position is out of bounds
            if (mars.IsOutOfBounds(newX, newY))
            {
                mars.LeaveScent(newX, newY);
                robot.IsLost = true;
                return;
            }

            robot.UpdateCoordinates(newX, newY);
        }

        public static void ExecuteInstruction(this Robot robot, char instruction, Mars mars)
        {
            switch (instruction)
            {
                case 'L': robot.TurnLeft(); 
                    break;
                case 'R': robot.TurnRight(); 
                    break;
                case 'F': robot.MoveForward(mars); 
                    break;
                default: throw new ArgumentException("Invalid instruction");
            }
        }
    }
}
