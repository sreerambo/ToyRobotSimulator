using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Business.Entities.Contracts
{
    //TODO: not considering extensibility due to YAGNI - if more complex models are desired, we could model direction as a vector
    public enum Direction
    {
        North,
        South,
        East,
        West
    }
}
