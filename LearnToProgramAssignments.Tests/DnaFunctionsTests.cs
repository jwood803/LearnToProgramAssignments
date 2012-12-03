// -----------------------------------------------------------------------
// <copyright file="DnaFunctionsTests.cs" company="">
// 
// </copyright>
// -----------------------------------------------------------------------
namespace LearnToProgramAssignments.Tests
{
    using Assignment2;
    using NUnit.Framework;

    /// <summary>
    /// Tests for methods in the DnaFunctions class
    /// </summary>
    [TestFixture]
    public class DnaFunctionsTests
    {
        private DnaFunctions dnaFunctions = new DnaFunctions("DnaFunctions.py");

        [TestCase("ATCGAT", 6)]
        [TestCase("ATCG", 4)]
        public void GetLength_Tests(string dna, int result)
        {
            Assert.AreEqual(result, dnaFunctions.GetDnaLength(dna));
        }

        [TestCase("ATCG", "AT", true)]
        [TestCase("ATCG", "ATCGGA", false)]
        public void IsLonger_Tests(string dna1, string dna2, bool result)
        {
            Assert.AreEqual(result, dnaFunctions.IsLonger(dna1, dna2));
        }

        [TestCase("ATCGGC", "G", 2)]
        [TestCase("ATCTA", "G", 0)]
        public void GetCountNucleotide_Tests(string dna, string nucleotide, int result)
        {
            Assert.AreEqual(result, dnaFunctions.GetNucleotideCount(dna, nucleotide));
        }

        [TestCase("ATCGGC", "GG", true)]
        [TestCase("ATCGGC", "GT", false)]
        public void HasNucleotideSequence_Tests(string dna1, string dna2, bool result)
        {
            Assert.AreEqual(result, dnaFunctions.HasNucleotideSequence(dna1, dna2));
        }

        [TestCase("ATCGGC", true)]
        [TestCase("ATCGGSC", false)]
        public void IsValidDnaSequence_Tests(string dna, bool result)
        {
            Assert.AreEqual(result, dnaFunctions.IsValidDnaSequence(dna));
        }

        [TestCase("CCGG", "AT", 2, "CCATGG")]
        [TestCase("CCGG", "AT", 1, "CATCGG")]
        public void InsertSequence_Tests(string dna, string input, int index, string result)
        {
            Assert.AreEqual(result, dnaFunctions.InsertSequence(dna, input, index));
        }

        [TestCase("A", "T")]
        [TestCase("G", "C")]
        [TestCase("C", "G")]
        public void GetNucleotideCompliment_Tests(string nucleotide, string result)
        {
            Assert.AreEqual(result, dnaFunctions.GetNucleotideCompliment(nucleotide));
        }
    }
}