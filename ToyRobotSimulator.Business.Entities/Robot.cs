using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Business.Entities.Contracts;
using ToyRobotSimulator.Business.Entities.Contracts.Exceptions;

namespace ToyRobotSimulator.Business.Entities
{
    public class Robot : IRobot
    {
        public IPosition Position { get; set; }
        public Direction FacingDirection { get; set; }

        private IBoard board;

        public bool Left()
        {
            if (board == null) throw new RobotNotPlacedException();
            return false;
        }

        public bool Right()
        {
            if (board == null) throw new RobotNotPlacedException();
            return false;
        }

        public bool Move()
        {
            if (board == null) throw new RobotNotPlacedException();
            return false;
        }

        public bool Place(IPosition position, Direction direction, IBoard board)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            if (board == null) throw new RobotNotPlacedException();
            return string.Empty;
        }
    }
}
