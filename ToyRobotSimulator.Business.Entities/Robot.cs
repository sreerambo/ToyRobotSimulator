using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using ToyRobotSimulator.Business.Entities.Contracts;
using ToyRobotSimulator.Business.Entities.Contracts.Exceptions;
using ToyRobotSimulator.Business.Entities.Utils;
using ToyRobotSimulator.Common.Contracts;

namespace ToyRobotSimulator.Business.Entities
{
    public class Robot : IRobot
    {
        public Position Position { get; private set; }
        public Direction FacingDirection { get; private set; }

        private IBoard board;
        private IBidirectionalMapper<Direction, Vector2> directionVectorMapper;

        public Robot(IBidirectionalMapper<Direction, Vector2> directionVectorMapper)
        {
            this.directionVectorMapper = directionVectorMapper;
        }

        public bool Left()
        {
            if (board == null) throw new RobotNotPlacedException();

            var directionVector = directionVectorMapper.Map(FacingDirection);
            directionVector = RotateByRightAngleAntiClockwise(directionVector);
            FacingDirection = directionVectorMapper.Map(directionVector);
            return true;
        }

        public bool Right()
        {
            if (board == null) throw new RobotNotPlacedException();

            var directionVector = directionVectorMapper.Map(FacingDirection);
            directionVector = RotateByRightAngleClockwise(directionVector);
            FacingDirection = directionVectorMapper.Map(directionVector);
            return true;
        }

        //https://stackoverflow.com/a/4780141
        private Vector2 RotateByRightAngleClockwise(Vector2 vector)
        {
            return new Vector2(vector.Y, -vector.X);
        }

        private Vector2 RotateByRightAngleAntiClockwise(Vector2 vector)
        {
            return new Vector2(-vector.Y, vector.X);
        }

        public bool Move()
        {
            if (board == null) throw new RobotNotPlacedException();

            var directionVector = directionVectorMapper.Map(FacingDirection);
            var transformedPosition = Vector2.Add(new Vector2(Position.X, Position.Y), directionVector);
            //TODO: consider using Vector<,> to avoid casting
            var newPositionPoint = new Position { X = (int)transformedPosition.X, Y = (int)transformedPosition.Y };
            if (board.IsValid(newPositionPoint))
            {
                Position = newPositionPoint;
                return true;
            }
            return false;
        }

        public bool Place(Position position, Direction direction, IBoard board)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));
            if (board == null) throw new ArgumentNullException(nameof(board));

            if (board.IsValid(position))
            {
                this.board = board;
                this.Position = position;
                this.FacingDirection = direction;
                return true;
            }
            return false;
        }

        public string Report()
        {
            if (board == null) throw new RobotNotPlacedException();

            return $"Position: {Position.X},{Position.Y}{Environment.NewLine}Direction: {FacingDirection}";
        }
    }
}
