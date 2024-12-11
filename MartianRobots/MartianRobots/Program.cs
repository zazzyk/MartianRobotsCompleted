using MartianRobots.Extensions;
using MartianRobots.Models;

class Program
{
    static void Main(string[] args)
    {
        // Read Mars grid dimensions
        var marsDimensions = Console.ReadLine()?.Split();
        if (marsDimensions == null || marsDimensions.Length != 2)
        {
            Console.WriteLine("Invalid Mars dimensions input. Exiting program.");
            return;
        }

        if (!int.TryParse(marsDimensions[0], out int marsMaxX) ||
            !int.TryParse(marsDimensions[1], out int marsMaxY))
        {
            Console.WriteLine("Mars dimensions must be integers. Exiting program.");
            return;
        }

        var mars = new Mars(marsMaxX, marsMaxY);

        var line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line))
        {
            Console.WriteLine("Invalid robot position input. Exiting program.");
            return;
        }

        // Parse robot initial position
        var positionInput = line.Split();
        if (positionInput.Length != 3 ||
            !int.TryParse(positionInput[0], out int x) ||
            !int.TryParse(positionInput[1], out int y) ||
            positionInput[2].Length != 1)
        {
            Console.WriteLine("Invalid robot position input. Exiting program.");
            return;
        }

        char orientation = positionInput[2][0];
        var robot = new Robot(x, y, orientation);

        // Parse instructions
        var instructions = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(instructions))
        {
            Console.WriteLine("Invalid robot instructions input. Exiting program.");
            return;
        }

        foreach (char instruction in instructions)
        {
            robot.ExecuteInstruction(instruction, mars);
            if (robot.IsLost)
            {
                break;
            };
        }

        // Output final position
        var result = $"RESULT: {robot.X} {robot.Y} {robot.Orientation}";
        if (robot.IsLost)
        {
            result = $"RESULT: {robot.X} {robot.Y} {robot.Orientation} LOST";
        }

        Console.WriteLine(result);
    }
}
