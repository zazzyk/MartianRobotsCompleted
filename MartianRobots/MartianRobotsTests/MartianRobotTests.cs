using FluentAssertions;
using FluentAssertions.Execution;
using MartianRobots.Extensions;
using MartianRobots.Models;

namespace MartianRobotsTests
{
    public class MartianRobotTests
    {
        [Fact]
        public void RobotTurnsLeft_ChangesPositionCorrectly()
        {
            // Arrange
            var robot = new Robot(0, 0, 'N');

            // Act
            robot.TurnLeft();

            // Assert
            robot.Orientation.Should().Be('W');
        }

        [Fact]
        public void RobotTurnsRight_ChangesPositionCorrectly()
        {
            // Arrange
            var robot = new Robot(0, 0, 'N');

            // Act
            robot.TurnRight();

            // Assert
            robot.Orientation.Should().Be('E');
        }

        [Fact]
        public void RobotGoesForward_WithinBounds_MovesForwards()
        {
            // Arrange
            var mars = new Mars(5, 3);
            var robot = new Robot(1, 1, 'N');

            // Act
            robot.MoveForward(mars);

            // Assert
            robot.X.Should().Be(1);
            robot.Y.Should().Be(2);
            robot.IsLost.Should().BeFalse();
        }

        [Fact]
        public void RobotGoesOutofBounds_IsMarkedLost()
        {
            // Arrange
            var mars = new Mars(5, 3);
            var robot = new Robot(0, 3, 'N');

            // Act
            robot.MoveForward(mars);

            // Assert
            robot.X.Should().Be(0);
            robot.Y.Should().Be(3);
            robot.IsLost.Should().BeTrue();
            mars.HasScent(0, 4).Should().BeTrue();
        }

        [Fact]
        public void RobotShouldIgnoreInstruction_WhenScentExistsAtEdge()
        {
            // Arrange
            var mars = new Mars(5, 3);
            mars.LeaveScent(0, 3);
            var robot = new Robot(0, 3, 'N');

            // Act
            robot.MoveForward(mars);

            // Assert
            robot.X.Should().Be(0);
            robot.Y.Should().Be(3);
            robot.IsLost.Should().BeFalse();
        }

        [Fact]
        public void RobotExecuteInstruction_ShouldProcessInstructionsCorrectly()
        {
            // Arrange
            var mars = new Mars(5, 3);
            var robot = new Robot(1, 1, 'E');

            // Act
            foreach (char instruction in "RFRFRFRF")
            {
                robot.ExecuteInstruction(instruction, mars);
            }

            // Assert
            robot.X.Should().Be(1);
            robot.Y.Should().Be(1);
            robot.Orientation.Should().Be('E');
            robot.IsLost.Should().BeFalse();
        }

        [Fact]
        public void GivenValidInput_CorrectOutputIsReturned()
        {
            // Arrange
            var mars = new Mars(5, 3);

            // Robot 1
            var robot1 = new Robot(1, 1, 'E');
            foreach (char instruction in "RFRFRFRF")
            {
                robot1.ExecuteInstruction(instruction, mars);
            }

            // Robot 2
            var robot2 = new Robot(3, 2, 'N');
            foreach (char instruction in "FRRFLLFFRRFLL")
            {
                robot2.ExecuteInstruction(instruction, mars);
                if (robot2.IsLost) break;
            }

            // Robot 3
            var robot3 = new Robot(0, 3, 'W');
            foreach (char instruction in "LLFFFLFLFL")
            {
                robot3.ExecuteInstruction(instruction, mars);
            }

            // Assert
            using (new AssertionScope())
            {
                robot1.X.Should().Be(1);
                robot1.Y.Should().Be(1);
                robot1.Orientation.Should().Be('E');
                robot1.IsLost.Should().BeFalse();

                robot2.X.Should().Be(3);
                robot2.Y.Should().Be(3);
                robot2.Orientation.Should().Be('N');
                robot2.IsLost.Should().BeTrue();

                robot3.X.Should().Be(2);
                robot3.Y.Should().Be(3);
                robot3.Orientation.Should().Be('S');
                robot3.IsLost.Should().BeFalse();
            }
        }
    }
}