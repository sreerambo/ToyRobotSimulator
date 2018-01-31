using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobotSimulator.Business.Entities.Contracts;

namespace ToyRobotSimulator.Business.Entities.Tests
{
    [TestClass]
    public class RectangularBoardTests
    {
        private const int DefaultBoardSize = 5;

        private RectangularBoard CreateSUT()
        {
            return new RectangularBoard(DefaultBoardSize, DefaultBoardSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RectangularBoard_IsValid_NullPosition_ThrowsArgumentNullException()
        {
            //arrange
            var sut = CreateSUT();
            Position position = null;

            //act
            var result = sut.IsValid(position);

            //assert
        }

        [TestMethod]
        public void RectangularBoard_IsValid_AllValidPositions_ReturnsTrue()
        {
            //arrange
            var sut = CreateSUT();

            for (var x = 0; x < DefaultBoardSize; ++x)
            {
                for (var y = 0; y < DefaultBoardSize; ++y)
                {
                    var position = TestUtils.CreateMockPosition(x, y);

                    //act
                    var result = sut.IsValid(position.Object);

                    //assert
                    Assert.IsTrue(result, $"Test failed at position: {x}, {y}");
                }
            }   
        }

        [TestMethod]
        public void RectangularBoard_IsValid_InvalidPosition_ReturnsFalse()
        {
            //arrange
            var sut = CreateSUT();
            var position = TestUtils.CreateMockPosition(6, 6);

            //act
            var result = sut.IsValid(position.Object);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RectangularBoard_IsValid_NegativePosition_ThrowsArgumentException()
        {
            //arrange
            var sut = CreateSUT();
            var position = TestUtils.CreateMockPosition(-1, -1);

            //act
            var result = sut.IsValid(position.Object);

            //assert
        }
    }
}
