// -----------------------------------------------------------------------
// <copyright file="DnaFunctions.cs" company="">
// 
// </copyright>
// -----------------------------------------------------------------------
namespace Assignment2
{
    using System.Diagnostics.Contracts;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;

    /// <summary>
    /// Functions that call the Python functions in the DnaFunctions.py script
    /// </summary>
    public class DnaFunctions
    {
        private ScriptSource scriptSource;
        private CompiledCode compiledCode;

        public DnaFunctions()
        { 
            //TODO: Default script path 
        }

        public DnaFunctions(string scriptPath)
        {
            this.ScriptPath = scriptPath;
        }

        public string ScriptPath { get; set; }

        public int GetDnaLength(string dna)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

            var engine = CreatePythonEngineWithSourceFile();
            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Get_Length = scope.GetVariable("get_length");

            return (int)engine.Operations.Invoke(f_Get_Length, dna);
        }

        public bool IsLonger(string dna1, string dna2)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna1));
            Contract.Requires(!string.IsNullOrWhiteSpace(dna2));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

            var engine = CreatePythonEngineWithSourceFile();
            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Is_Longer = scope.GetVariable("is_longer");

            return (bool)engine.Operations.Invoke(f_Is_Longer, dna1, dna2);
        }

        public int GetNucleotideCount(string dna, string nucleotide)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna));
            Contract.Requires(!string.IsNullOrWhiteSpace(nucleotide));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

            var engine = CreatePythonEngineWithSourceFile();
            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Count_Nucleotides = scope.GetVariable("count_nucleotides");

            return (int)engine.Operations.Invoke(f_Count_Nucleotides, dna, nucleotide);
        }

        public bool HasNucleotideSequence(string dna1, string dna2)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna1));
            Contract.Requires(!string.IsNullOrWhiteSpace(dna2));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

            var engine = CreatePythonEngineWithSourceFile();
            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Contains_Sequence = scope.GetVariable("contains_sequence");

            return (bool)engine.Operations.Invoke(f_Contains_Sequence, dna1, dna2);
        }

        public bool IsValidDnaSequence(string dna)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

            var engine = CreatePythonEngineWithSourceFile();
            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Is_Valid_Sequence = scope.GetVariable("is_valid_sequence");

            return (bool)engine.Operations.Invoke(f_Is_Valid_Sequence, dna);
        }

        public string InsertSequence(string dna, string input, int index)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(dna));
            Contract.Requires(!string.IsNullOrWhiteSpace(input));
            Contract.Requires(index >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<string>() != string.Empty);

            var engine = CreatePythonEngineWithSourceFile();
            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Insert_Sequence = scope.GetVariable("insert_sequence");

            return (string)engine.Operations.Invoke(f_Insert_Sequence, dna, input, index);
        }

        public string GetNucleotideCompliment(string nucleotide)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(nucleotide));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<string>() != string.Empty);

            var engine = CreatePythonEngineWithSourceFile();
            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Get_Compliment = scope.GetVariable("get_compliment");

            return (string)engine.Operations.Invoke(f_Get_Compliment, nucleotide);
        }

        private ScriptEngine CreatePythonEngineWithSourceFile()
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

            var engine = Python.CreateEngine();
            this.scriptSource = engine.CreateScriptSourceFromFile(this.ScriptPath);
            this.compiledCode = scriptSource.Compile();
            return engine;
        }
    }
}