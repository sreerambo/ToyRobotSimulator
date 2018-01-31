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
        private static Vector2 NorthVector = new Vector2(0, 1);
        private static Vector2 SouthVector = new Vector2(0, -1);
        private static Vector2 EastVector = new Vector2(1, 0);
        private static Vector2 WestVector = new Vector2(-1, 0);

        public Direction Map(Vector2 toMap)
        {
            if (toMap.Equals(NorthVector))
            {
                return Direction.North;
            }
            else if (toMap.Equals(SouthVector))
            {
                return Direction.South;
            }
            else if (toMap.Equals(EastVector))
            {
                return Direction.East;
            }
            else if (toMap.Equals(WestVector))
            {
                return Direction.West;
            }
            else
            {
                throw new ArgumentException("Vector couldn't be mapped", nameof(toMap));
            }    
        }

        public Vector2 Map(Direction toMap)
        {
            switch(toMap)
            {
                case Direction.North:
                    return NorthVector;
                case Direction.South:
                    return SouthVector;
                case Direction.East:
                    return EastVector;
                case Direction.West:
                    return WestVector;
                default:
                    throw new ArgumentException("Direction couldn't be mapped", nameof(toMap));
            }
        }
    }
}
