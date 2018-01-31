using System;

namespace ToyRobotSimulator.Business.Entities.Contracts
{
    public interface IRobot
    {
        Position Position { get; }
        Direction FacingDirection { get; }

        /// <summary>
        /// Place the robot on the board
        /// </summary>
        /// <param name="position">Position on the board the robot should be placed at</param>
        /// <param name="direction">Direction the robot should be facing when placed</param>
        /// <param name="board">Board on which the robot should be placed.</param>
        /// <returns></returns>
        bool Place(Position position, Direction direction, IBoard board);

        /// <summary>
        /// Moves the robot one unit forward in the direction it is currently facing
        /// </summary>
        /// <returns>true if the operation was successful</returns>
        bool Move();

        /// <summary>
        /// Turn the robot in place to the left of where it is facing
        /// </summary>
        /// <returns>true if the operation was successful</returns>
        bool Left();

        /// <summary>
        /// Turn the robot in place to the right of where it is facing
        /// </summary>
        /// <returns>true if the operation was successful</returns>
        bool Right();

        /// <summary>
        /// Returns the current x and y positions of the robot as well as the direction it is facing as a formatted string.
        /// </summary>
        /// <returns>Formatted string with X position, Y position and direction that the Robot is facing.</returns>
        string Report();
    }
}
