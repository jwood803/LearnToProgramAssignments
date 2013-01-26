// -----------------------------------------------------------------------
// <copyright file="WordSearchGameFunctionsTests.cs" company="">
// 
// </copyright>
// -----------------------------------------------------------------------
namespace LearnToProgramAssignments.Tests
{
    using System.Collections;
    using Assignment3;
    using NUnit.Framework;
    using System.Collections.Generic;

    /// <summary>
    /// Tests for the WordSearchGameFunctions class
    /// </summary>
    [TestFixture]
    public class WordSearchGameFunctionsTests
    {
        private WordSearchGameFunctions gameFunctions = new WordSearchGameFunctions("WordSearchGame.py");

        [Test]
        public void IsWordValid_Tests()
        {
            var words = new List<string>
            {
                "ANT", "BOX", "SOB", "TO"
            };

            Assert.IsTrue(gameFunctions.IsValidWord(words, "TO"));
        }
    }
}