namespace Assignment1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Dynamic;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var scriptSource = engine.CreateScriptSourceFromFile(@"C:\Users\Jon-Standard\Documents\Visual Studio 2010\Projects\LearnToProgramAssignments\Assignment1\test.py");

            var compiled = scriptSource.Compile();

            compiled.Execute(scope);

            dynamic f_Add = scope.GetVariable("Add");

            dynamic results = engine.Operations.Invoke(f_Add, 2, 2);

            Console.WriteLine(results);

            Console.ReadLine();
        }
    }
}