using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Business.Entities.Contracts
{
    public interface IBoard
    {
        bool IsValid(IPosition position);
    }
}
