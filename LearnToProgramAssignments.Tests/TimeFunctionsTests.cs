namespace LearnToProgramAssignments.Tests
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
        public void GetHoursDifference_Tests(double time1, double time2, double result)
        {
            Assert.IsTrue(timeFunctions.GetHoursDifference(time1, time2) == result);
        }

        [TestCase(0, 15, 0, 0.25)]
        [TestCase(2, 45, 9, 2.7525)]
        [TestCase(1, 0, 36, 1.01)]
        public void GetFloatHours_Tests(int hours, int minutes, int seconds, double result)
        {
            Assert.IsTrue(timeFunctions.GetFloatHours(hours, minutes, seconds) == result);
        }

        [TestCase(3800, 1)]
        public void GetHours_Tests(int seconds, int result)
        {
            Assert.IsTrue(timeFunctions.GetHoursFromMidnight(seconds) == result);
        }

        [TestCase(3800, 3)]
        public void GetMinutes_Tests(int seconds, int result)
        {
            Assert.IsTrue(timeFunctions.GetMinutesFromMidnight(seconds) == result);
        }

        [TestCase(3800, 20)]
        public void GetSeconds_Tests(int seconds, int result)
        {
            Assert.IsTrue(timeFunctions.GetSecondsFromMidnight(seconds) == result);
        }

        [TestCase(0, 12.0, 12.0)]
        [TestCase(1, 12.0, 11.0)]
        [TestCase(-1, 12.0, 13.0)]
        [TestCase(-11, 18.0, 5.0)]
        [TestCase(-1, 0.0, 1.0)]
        [TestCase(-1, 23.0, 0.0)]
        public void GetGetTimeToUtc_Tests(int utcOffset, double time, double result)
        {
            Assert.AreEqual(result, timeFunctions.GetTimeToUtc(utcOffset, time));
        }

        [TestCase(0, 12.0, 12.0)]
        [TestCase(1, 12.0, 13.0)]
        [TestCase(-1, 12.0, 11.0)]
        [TestCase(6, 6.0, 12.0)]
        [TestCase(-7, 6.0, 23.0)]
        [TestCase(-1, 0.0, 23.0)]
        [TestCase(-1, 23.0, 22.0)]
        [TestCase(1, 23.0, 0)]
        public void GetGetTimeFromUtc_Tests(int utcOffset, double time, double result)
        {
            Assert.AreEqual(result, timeFunctions.GetTimeFromUtc(utcOffset, time));
        }
    }
}