using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using ToyRobotSimulator.Business.Entities.Contracts;
using ToyRobotSimulator.Common.Contracts;

namespace ToyRobotSimulator.Business.Entities.Utils
{
    public class DirectionVectorMapper : IBidirectionalMapper<Direction, Vector2>
    {
        public Direction Map(Vector2 toMap)
        {
            throw new NotImplementedException();
        }

        public Vector2 Map(Direction toMap)
        {
            throw new NotImplementedException();
        }
    }
}
