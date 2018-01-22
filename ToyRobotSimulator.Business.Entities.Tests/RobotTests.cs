using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobotSimulator.Business.Entities.Contracts;
using ToyRobotSimulator.Business.Entities.Contracts.Exceptions;

namespace ToyRobotSimulator.Business.Entities.Tests
{
    [TestClass]
    public class RobotTests
    {
        private const int DefaultBoardSize = 5;

        private Robot CreateSUT()
        {
            return new Robot();
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void Robot_Left_WhenNotPlacedFirst_ThrowsRobotNotPlacedException()
        {
            //arrange
            var sut = CreateSUT();

            //act
            var result = sut.Left();

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void Robot_Right_WhenNotPlacedFirst_ThrowsRobotNotPlacedException()
        {
            //arrange
            var sut = CreateSUT();

            //act
            var result = sut.Right();

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void Robot_Move_WhenNotPlacedFirst_ThrowsRobotNotPlacedException()
        {
            //arrange
            var sut = CreateSUT();

            //act
            var result = sut.Right();

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(RobotNotPlacedException))]
        public void Robot_Report_WhenNotPlacedFirst_ThrowsRobotNotPlacedException()
        {
            //arrange
            var sut = CreateSUT();

            //act
            var result = sut.Right();

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Robot_Place_NullBoard_ThrowsArgumentNullException()
        {
            //arrange
            var sut = CreateSUT();
            IBoard board = null;
            var position = TestUtils.CreateMockPosition(0, 0);
            
            //act
            var result = sut.Place(position.Object, Direction.North, board);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Robot_Place_NullPosition_ThrowsArgumentNullException()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            IPosition position = null;

            //act
            var result = sut.Place(position, Direction.North, board.Object);

            //assert
        }

        [TestMethod]
        public void Robot_Place_ValidPositionAndBoard_ReturnsTrue()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0,0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);

            //act
            var result = sut.Place(position.Object, Direction.North, board.Object);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Robot_GetPosition_ValidPositionAndBoard_ReturnsPosition()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            sut.Place(position.Object, Direction.North, board.Object);

            //act
            var result = sut.Position;

            //assert
            Assert.AreEqual(position.Object.X, result.X);
            Assert.AreEqual(position.Object.Y, result.Y);
        }

        [TestMethod]
        public void Robot_GetFacingDirection_ValidPositionAndBoard_ReturnsFacingDirection()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.West;
            sut.Place(position.Object, direction, board.Object);

            //act
            var result = sut.FacingDirection;

            //assert
            Assert.AreEqual(direction, result);
        }
    }
}
