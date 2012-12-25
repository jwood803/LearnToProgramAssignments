// -----------------------------------------------------------------------
// <copyright file="TestHelper.cs" company="">

// </copyright>
// -----------------------------------------------------------------------
namespace LearnToProgramAssignments.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Helper method for unit tests
    /// </summary>
    public class TestHelper
    {
        public static T ExpectException<T>(Action block, string message) where T : Exception
        {
            try
            {
                block();
                Assert.Fail(message);
            }
            catch (T ex)
            {
                return ex; // Tests pass if in here. Pass the exception to the caller if it needs it.
            }
            catch (Exception)
            {
                Assert.Fail("Wrong exception thrown");
            }

            Assert.Fail("No exception has been thrown");
            return null; //Should not get here
        }
    }
}