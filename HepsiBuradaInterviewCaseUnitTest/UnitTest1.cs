using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HepsiBuradaInterviewCase;
using System.Collections.Generic;

namespace HepsiBuradaInterviewCaseUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RoverPosition roverPosition = new RoverPosition()
            {
                xAxis = 1,
                yAxis = 2,
                facingSide = Sides.N
            };

            char[] roverMovements = "LMLMLMLMM".ToCharArray();

            Program.matrixXAxis = 5;
            Program.matrixYAxis = 5;

            Assert.AreEqual("1 3 N", Program.RoverMovementResult(roverPosition,roverMovements));
        }

        [TestMethod]
        public void TestMethod2()
        {
            RoverPosition roverPosition = new RoverPosition()
            {
                xAxis = 3,
                yAxis = 3,
                facingSide = Sides.E
            };

            char[] roverMovements = "MMRMMRMRRM".ToCharArray();

            Program.matrixXAxis = 5;
            Program.matrixYAxis = 5;

            Assert.AreEqual("5 1 E", Program.RoverMovementResult(roverPosition, roverMovements));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Out of the area!")]
        public void TestMethod3()
        {
            RoverPosition roverPosition = new RoverPosition()
            {
                xAxis = 4,
                yAxis = 5,
                facingSide = Sides.W
            };

            char[] roverMovements = "MMRMRRMMMR".ToCharArray();

            Program.matrixXAxis = 5;
            Program.matrixYAxis = 5;

            string result = Program.RoverMovementResult(roverPosition, roverMovements);
        }
    }
}
