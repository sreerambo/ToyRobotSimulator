using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Business.Entities.Contracts
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
    }
}
