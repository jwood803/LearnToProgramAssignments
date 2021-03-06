﻿namespace Assignment3
{
    using System.Diagnostics.Contracts;
    using PythonEnine;

    public class WordSearchGameFunctions
    {
        private PythonEngine engine;

        public WordSearchGameFunctions()
        {
            //TODO: Default script path 
        }

        public WordSearchGameFunctions(string scriptPath)
        {
            this.ScriptPath = scriptPath;
            engine = new PythonEngine(this.ScriptPath);
        }

        public string ScriptPath { get; set; }

        public bool IsValidWord(System.Collections.Generic.List<string> wordList, string word)
        {
            Contract.Requires(wordList != null);
            Contract.Requires(!string.IsNullOrWhiteSpace(word));
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

            return (bool)engine.InvokeMethodWithParameters("is_valid_word", wordList, word);
        }

    }
}