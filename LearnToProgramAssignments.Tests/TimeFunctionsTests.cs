namespace LearnToProgramAssignments.Tests
{
    using Assignment1;
    using NUnit.Framework;

    [TestFixture]
    public class TimeFunctionsTests
    {
        private TimeFunctions timeFunctions = 
            new TimeFunctions(@"C:\Users\Jon-Standard\Documents\Visual Studio 2010\Projects\LearnToProgramAssignments\Assignment1\TimeFunctions.py");

        [TestCase(1800.0, 1800.0, 0.0)]
        [TestCase(1800.0, 3600.0, 1800.0)]
        [TestCase(1800.0, 2160.0, 360.0)]
        [TestCase(3600.0, 1800.0, -1800.0)]
        public void GetSecondsDifference_Test(double time1, double time2, dynamic result)
        {
            Assert.IsTrue(timeFunctions.GetSecondsDifference(time1, time2) == (double)result);
        }
    }
}