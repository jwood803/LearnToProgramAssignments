// -----------------------------------------------------------------------
// <copyright file="WordSearchGameFunctionsTests.cs" company="">
// 
// </copyright>
// -----------------------------------------------------------------------
namespace LearnToProgramAssignments.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Assignment3;
    using IronPython.Runtime;

    /// <summary>
    /// Tests for the WordSearchGameFunctions class
    /// </summary>
    [TestFixture]
    public class WordSearchGameFunctionsTests
    {
        private WordSearchGameFunctions gameFunctions = new WordSearchGameFunctions("WordSearchGameFunctions.py");

        //[TestCase(new List, "TO")]
        public void IsWordValid_Tests(string[] wordList, string word, bool result)
        {
            //TestHelper.ExpectException<Exception>(() => gameFunctions.IsValidWord(wordList, word), "Exception should happen");
            //Assert.AreEqual(result, gameFunctions.IsValidWord(wordList, word));
        }
    }
}