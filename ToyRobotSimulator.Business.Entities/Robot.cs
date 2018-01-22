using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Business.Entities.Contracts;
using ToyRobotSimulator.Business.Entities.Contracts.Exceptions;

namespace ToyRobotSimulator.Business.Entities
{
    public class Robot : IRobot
    {
        public IPosition Position { get; private set; }
        public Direction FacingDirection { get; private set; }

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
            if (position == null) throw new ArgumentNullException(nameof(position));
            if (board == null) throw new ArgumentNullException(nameof(board));

            if (board.IsValid(position))
            {
                this.Position = position;
                this.FacingDirection = direction;
                return true;
            }
            return false;
        }

        public string Report()
        {
            if (board == null) throw new RobotNotPlacedException();
            return string.Empty;
        }
    }
}
