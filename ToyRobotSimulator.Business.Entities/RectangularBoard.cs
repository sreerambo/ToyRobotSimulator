using System;
using System.Drawing;
using ToyRobotSimulator.Business.Entities.Contracts;

namespace ToyRobotSimulator.Business.Entities
{
    public class RectangularBoard : IBoard
    {
        private Rectangle Bounds {get; set;}

        public RectangularBoard(int width, int height)
        {
            Bounds = new Rectangle(0, 0, width, height);
        }

        public bool IsValid(Position position)
        {
            if (position == null) throw new ArgumentNullException(nameof(position));
            if (position.X < 0 || position.Y < 0) throw new ArgumentException("Negative positions are not supported.", nameof(position));

            return Bounds.Contains(position.X, position.Y); //TODO: extension method for this?
        }
    }
}
