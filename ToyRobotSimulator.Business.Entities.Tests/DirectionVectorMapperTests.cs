using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using ToyRobotSimulator.Business.Entities.Contracts;
using ToyRobotSimulator.Business.Entities.Utils;

namespace ToyRobotSimulator.Business.Entities.Tests
{
    [TestClass]
    public class DirectionVectorMapperTests
    {
        private DirectionVectorMapper CreateSUT()
        {
            return new DirectionVectorMapper();
        }

        [TestMethod]
        public void DirectionMapper_MapToVector_North_ReturnsUnitVector()
        {
            //arrange
            var sut = CreateSUT();
            Direction direction = Direction.North;

            //act
            var result = sut.Map(direction);

            //assert
            Assert.AreEqual(new Vector2(0, 1), result);
        }

        [TestMethod]
        public void DirectionMapper_MapToVector_South_ReturnsUnitVector()
        {
            //arrange
            var sut = CreateSUT();
            Direction direction = Direction.South;

            //act
            var result = sut.Map(direction);

            //assert
            Assert.AreEqual(new Vector2(0, -1), result);
        }

        [TestMethod]
        public void DirectionMapper_MapToVector_East_ReturnsUnitVector()
        {
            //arrange
            var sut = CreateSUT();
            Direction direction = Direction.East;

            //act
            var result = sut.Map(direction);

            //assert
            Assert.AreEqual(new Vector2(1, 0), result);
        }

        [TestMethod]
        public void DirectionMapper_MapToVector_West_ReturnsUnitVector()
        {
            //arrange
            var sut = CreateSUT();
            Direction direction = Direction.West;

            //act
            var result = sut.Map(direction);

            //assert
            Assert.AreEqual(new Vector2(-1, 0), result);
        }

        [TestMethod]
        public void DirectionMapper_VectorToMap_NegativeOneZeroVector_ReturnsWest()
        {
            //arrange
            var sut = CreateSUT();
            var directionVector = new Vector2(-1, 0);

            //act
            var result = sut.Map(directionVector);

            //assert
            Assert.AreEqual(Direction.West, result);
        }

        [TestMethod]
        public void DirectionMapper_VectorToMap_OneZeroVector_ReturnsEast()
        {
            //arrange
            var sut = CreateSUT();
            var directionVector = new Vector2(1, 0);

            //act
            var result = sut.Map(directionVector);

            //assert
            Assert.AreEqual(Direction.East, result);
        }

        [TestMethod]
        public void DirectionMapper_VectorToMap_ZeroNegativeOneVector_ReturnsSouth()
        {
            //arrange
            var sut = CreateSUT();
            var directionVector = new Vector2(0, -1);

            //act
            var result = sut.Map(directionVector);

            //assert
            Assert.AreEqual(Direction.South, result);
        }

        [TestMethod]
        public void DirectionMapper_VectorToMap_ZeroOneVector_ReturnsNorth()
        {
            //arrange
            var sut = CreateSUT();
            var directionVector = new Vector2(0, 1);

            //act
            var result = sut.Map(directionVector);

            //assert
            Assert.AreEqual(Direction.North, result);
        }
    }
}
