using MarsRover.Core;
using MarsRover.Core.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Tests
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod]
        public void RoversTest()
        {
            RoverHandler rovers = new RoverHandler(5, 5)
            {
                { "1 2 N", "LMLMLMLMM" },
                { "3 3 E", "MMRMMRMRRM" }
            };

            Assert.IsTrue(rovers.Count == 2);
            Assert.IsNotNull(rovers[0]);
            Assert.IsNotNull(rovers[1]);
        }

        [TestMethod]
        public void RoversTestCoordinates()
        {
            RoverHandler rovers = new RoverHandler(5, 5)
            {
                { "1 2 N", "LMLMLMLMM" },
                { "3 3 E", "MMRMMRMRRM" }
            };

            IRover roverOne = rovers[0];
            IRover roverTwo = rovers[1];

            Assert.IsTrue(roverOne.XCoordinate == 1);
            Assert.IsTrue(roverOne.YCoordinate == 3);
            Assert.IsTrue(roverOne.Direction == Direction.N);

            Assert.IsTrue(roverTwo.XCoordinate == 5);
            Assert.IsTrue(roverTwo.YCoordinate == 1);
            Assert.IsTrue(roverTwo.Direction == Direction.E);
        }
    }
}