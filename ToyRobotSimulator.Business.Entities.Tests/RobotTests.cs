using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobotSimulator.Business.Entities.Contracts;
using ToyRobotSimulator.Business.Entities.Contracts.Exceptions;
using ToyRobotSimulator.Common.Contracts;
using System.Numerics;

namespace ToyRobotSimulator.Business.Entities.Tests
{
    [TestClass]
    public class RobotTests
    {
        private const int DefaultBoardSize = 5;
        private Mock<IBidirectionalMapper<Direction, Vector2>> mockDirectionVectorMapper;

        //It's tempting to just use the actual mapper implementation here but for purity this is a mock
        private Mock<IBidirectionalMapper<Direction, Vector2>> CreateMapper()
        {
            var northVector = new Vector2(0, 1);
            var southVector = new Vector2(0, -1);
            var eastVector = new Vector2(1, 0);
            var westVector = new Vector2(-1, 0);

            var mockMapper = new Mock<IBidirectionalMapper<Direction, Vector2>>();

            mockMapper.Setup(m => m.Map(Direction.North)).Returns(northVector);
            mockMapper.Setup(m => m.Map(Direction.South)).Returns(southVector);
            mockMapper.Setup(m => m.Map(Direction.East)).Returns(eastVector);
            mockMapper.Setup(m => m.Map(Direction.West)).Returns(westVector);

            mockMapper.Setup(m => m.Map(northVector)).Returns(Direction.North);
            mockMapper.Setup(m => m.Map(southVector)).Returns(Direction.South);
            mockMapper.Setup(m => m.Map(eastVector)).Returns(Direction.East);
            mockMapper.Setup(m => m.Map(westVector)).Returns(Direction.West);

            return mockMapper;
        }

        private Robot CreateSUT()
        {
            mockDirectionVectorMapper = CreateMapper();
            return new Robot(mockDirectionVectorMapper.Object);
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
            Position position = null;

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
            var position = TestUtils.CreateMockPosition(0, 0);
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

        [TestMethod]
        public void Robot_Right_FromNorth_ReturnsEast()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.North;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Right();
            var result = sut.FacingDirection;

            //assert
            Assert.IsTrue(success);
            Assert.AreEqual(Direction.East, result);
        }

        [TestMethod]
        public void Robot_Right_FromEast_ReturnsSouth()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.East;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Right();
            var result = sut.FacingDirection;

            //assert
            Assert.IsTrue(success);
            Assert.AreEqual(Direction.South, result);
        }

        [TestMethod]
        public void Robot_Right_FromSouth_ReturnsWest()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.South;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Right();
            var result = sut.FacingDirection;

            //assert
            Assert.IsTrue(success);
            Assert.AreEqual(Direction.West, result);
        }

        [TestMethod]
        public void Robot_Right_FromWest_ReturnsNorth()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.West;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Right();
            var result = sut.FacingDirection;

            //assert
            Assert.IsTrue(success);
            Assert.AreEqual(Direction.North, result);
        }

        [TestMethod]
        public void Robot_Left_FromNorth_ReturnsWest()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.North;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Left();
            var result = sut.FacingDirection;

            //assert
            Assert.IsTrue(success);
            Assert.AreEqual(Direction.West, result);
        }

        [TestMethod]
        public void Robot_Left_FromWest_ReturnsSouth()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.West;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Left();
            var result = sut.FacingDirection;

            //assert
            Assert.IsTrue(success);
            Assert.AreEqual(Direction.South, result);
        }

        [TestMethod]
        public void Robot_Left_FromSouth_ReturnsEast()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.South;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Left();
            var result = sut.FacingDirection;

            //assert
            Assert.IsTrue(success);
            Assert.AreEqual(Direction.East, result);
        }

        [TestMethod]
        public void Robot_Left_FromEast_ReturnsNorth()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            var direction = Direction.East;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Left();
            var result = sut.FacingDirection;

            //assert
            Assert.IsTrue(success);
            Assert.AreEqual(Direction.North, result);
        }

        [TestMethod]
        public void Robot_Move_ToInvalidPosition_PositionNotSet()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            board.Setup(b => b.IsValid(TestUtils.CreateMockPosition(0, -1).Object)).Returns(false);
            var direction = Direction.South;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Move();

            //assert
            Assert.IsFalse(success);
            position.VerifySet(p => p.X = It.IsAny<int>(), Times.Never);
            position.VerifySet(p => p.Y = It.IsAny<int>(), Times.Never);
        }

        [TestMethod]
        public void Robot_Move_ToValidPosition_PositionSet()
        {
            //arrange
            var sut = CreateSUT();
            var board = new Mock<IBoard>();
            var position = TestUtils.CreateMockPosition(0, 0);
            board.Setup(b => b.IsValid(position.Object)).Returns(true);
            board.Setup(b => b.IsValid(TestUtils.CreateMockPosition(0, 1).Object)).Returns(true);
            var direction = Direction.North;
            sut.Place(position.Object, direction, board.Object);

            //act
            var success = sut.Move();

            //assert
            Assert.IsTrue(success);
            position.VerifySet(p => p.X = It.IsAny<int>(), Times.Once);
            position.VerifySet(p => p.Y = It.IsAny<int>(), Times.Once);
        }
    }
}
