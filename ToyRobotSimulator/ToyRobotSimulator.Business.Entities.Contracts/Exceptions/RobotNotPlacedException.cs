using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Business.Entities.Contracts.Exceptions
{
    /// <summary>
    /// Should be thrown if a command cannot be completed due to the robot not being placed
    /// </summary>
    public class RobotNotPlacedException : Exception
    {
    }
}
