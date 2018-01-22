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

        private Mock<IPosition> CreateMockPosition(int x, int y)
        {
            var position = new Mock<IPosition>();
            position.Setup(p => p.X).Returns(x);
            position.Setup(p => p.Y).Returns(y);
            return position;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsValid_NullPosition_ThrowsArgumentNullException()
        {
            //arrange
            var sut = CreateSUT();
            IPosition position = null;

            //act
            var result = sut.IsValid(position);

            //assert
        }

        [TestMethod]
        public void IsValid_AllValidPositions_ReturnsTrue()
        {
            //arrange
            var sut = CreateSUT();

            for (var x = 0; x < DefaultBoardSize; ++x)
            {
                for (var y = 0; y < DefaultBoardSize; ++y)
                {
                    var position = CreateMockPosition(x, y);

                    //act
                    var result = sut.IsValid(position.Object);

                    //assert
                    Assert.IsTrue(result, $"Test failed at position: {x}, {y}");
                }
            }   
        }

        [TestMethod]
        public void IsValid_InvalidPosition_ReturnsFalse()
        {
            //arrange
            var sut = CreateSUT();
            var position = CreateMockPosition(6, 6);

            //act
            var result = sut.IsValid(position.Object);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsValid_NegativePosition_ThrowsArgumentException()
        {
            //arrange
            var sut = CreateSUT();
            var position = CreateMockPosition(-1, -1);

            //act
            var result = sut.IsValid(position.Object);

            //assert
        }
    }
}
