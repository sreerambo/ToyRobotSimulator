using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Business.Entities.Contracts;

namespace ToyRobotSimulator.Business.Entities.Tests
{
    public static class TestUtils
    {
        public static Mock<Position> CreateMockPosition(int x, int y)
        {
            var position = new Mock<Position>();
            position.Setup(p => p.X).Returns(x);
            position.Setup(p => p.Y).Returns(y);
            return position;
        }
    }
}
