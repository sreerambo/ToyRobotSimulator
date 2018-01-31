using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Business.Entities.Contracts;

namespace ToyRobotSimulator.Business.Entities.Tests
{
    public static class TestUtils
    {
        public static Position CreatePosition(int x, int y)
        {
            var position = new Position()
            {
                X = x,
                Y = y
            };
            return position;
        }
    }
}
