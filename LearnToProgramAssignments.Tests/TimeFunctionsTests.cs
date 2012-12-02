﻿namespace LearnToProgramAssignments.Tests
{
    using Assignment1;
    using NUnit.Framework;

    [TestFixture]
    public class TimeFunctionsTests
    {
        private TimeFunctions timeFunctions = new TimeFunctions("TimeFunctions.py");

        [TestCase(1800.0, 1800.0, 0.0)]
        [TestCase(1800.0, 3600.0, 1800.0)]
        [TestCase(1800.0, 2160.0, 360.0)]
        [TestCase(3600.0, 1800.0, -1800.0)]
        public void GetSecondsDifference_Test(double time1, double time2, double result)
        {
            Assert.IsTrue(timeFunctions.GetSecondsDifference(time1, time2) == result);
        }

        [TestCase(1800.0, 1800.0, 0.0)]
        [TestCase(1800.0, 3600.0, 0.5)]
        [TestCase(1800.0, 2160.0, 0.1)]
        [TestCase(3600.0, 1800.0, -0.5)]
        public void GetHoursDifference(double time1, double time2, double result)
        {
            Assert.IsTrue(timeFunctions.GetHoursDifference(time1, time2) == result);
        }
    }
}