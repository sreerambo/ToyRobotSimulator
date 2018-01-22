using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Business.Entities.Contracts
{
    public interface IBoard
    {
        /// <summary>
        /// Returns true if the position passed in is a valid position on this board.
        /// </summary>
        /// <param name="position">Position to be tested</param>
        /// <returns></returns>
        bool IsValid(IPosition position);
    }
}
