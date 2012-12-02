// -----------------------------------------------------------------------
// <copyright file="TimeFunctions.cs" company="">
// 
// </copyright>
// -----------------------------------------------------------------------
namespace Assignment1
{
    using System;
    using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

    /// <summary>
    /// 
    /// </summary>
    public class TimeFunctions
    {
        ScriptSource scriptSource;
        CompiledCode compiledCode;

        public TimeFunctions ()
	    {}

        public TimeFunctions(string scriptPath)
        {
            this.ScriptPath = scriptPath;
        }

        public string ScriptPath { get; set; }

        public double GetSecondsDifference(double time1, double time2)
        {
            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Seconds_Difference = scope.GetVariable("seconds_difference");

            return (double)engine.Operations.Invoke(f_Seconds_Difference, time1, time2);
        }

        public double GetHoursDifference(double time1, double time2)
        {
            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Hours_Difference = scope.GetVariable("hours_difference");

            return (double)engine.Operations.Invoke(f_Hours_Difference, time1, time2);
        }

        private ScriptEngine CreatePythonEngineWithSourceFile()
        {
            var engine = Python.CreateEngine();
            scriptSource = engine.CreateScriptSourceFromFile(this.ScriptPath);
            compiledCode = scriptSource.Compile();
            return engine;
        }
    }
}