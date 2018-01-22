using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Business.Entities.Contracts
{
    public interface IRobotState : IPosition
    {
        Direction FacingDirection { get; set; }

        /// <summary>
        /// Returns the current x and y positions of the robot as well as the direction it is facing as a formatted string.
        /// </summary>
        /// <returns>Formatted string with X position, Y position and direction that the Robot is facing.</returns>
        string Report();
    }
}
