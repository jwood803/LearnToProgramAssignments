// -----------------------------------------------------------------------
// <copyright file="DnaFunctions.cs" company="">
// 
// </copyright>
// -----------------------------------------------------------------------
namespace Assignment2
{
    using System.Diagnostics.Contracts;
    using PythonEnine;

    /// <summary>
    /// Functions that call the Python functions in the DnaFunctions.py script
    /// </summary>
    public class DnaFunctions
    {
        private PythonEngine engine;
        
        public DnaFunctions()
        { 
            //TODO: Default script path
        }

        public DnaFunctions(string scriptPath)
        {
            this.ScriptPath = scriptPath;
            engine = new PythonEngine(this.ScriptPath);
        }

        public string ScriptPath { get; set; }

        public int GetDnaLength(string dna)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

            return (int)engine.InvokeMethodWithParameters("get_length", dna);
        }

        public bool IsLonger(string dna1, string dna2)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna1));
            Contract.Requires(!string.IsNullOrWhiteSpace(dna2));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

            return (bool)engine.InvokeMethodWithParameters("is_longer", dna1, dna2);
        }

        public int GetNucleotideCount(string dna, string nucleotide)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna));
            Contract.Requires(!string.IsNullOrWhiteSpace(nucleotide));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

            return (int)engine.InvokeMethodWithParameters("count_nucleotides", dna, nucleotide);
        }

        public bool HasNucleotideSequence(string dna1, string dna2)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna1));
            Contract.Requires(!string.IsNullOrWhiteSpace(dna2));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

            return (bool)engine.InvokeMethodWithParameters("contains_sequence", dna1, dna2);
        }

        public bool IsValidDnaSequence(string dna)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

            return (bool)engine.InvokeMethodWithParameters("is_valid_sequence", dna);
        }

        public string InsertSequence(string dna, string input, int index)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna));
            Contract.Requires(!string.IsNullOrWhiteSpace(input));
            Contract.Requires(index >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<string>() != string.Empty);

            return (string)engine.InvokeMethodWithParameters("insert_sequence", dna, input, index);
        }

        public string GetNucleotideCompliment(string nucleotide)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(nucleotide));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<string>() != string.Empty);

            return (string)engine.InvokeMethodWithParameters("get_compliment", nucleotide);
        }

        public string GetSequenceCompliment(string sequence)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(sequence));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<string>() != string.Empty);

            return (string)engine.InvokeMethodWithParameters("get_complimentary_sequence", sequence);
        }
    }
}