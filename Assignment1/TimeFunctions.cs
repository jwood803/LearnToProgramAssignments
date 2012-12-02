// -----------------------------------------------------------------------
// <copyright file="TimeFunctions.cs" company="">
// 
// </copyright>
// -----------------------------------------------------------------------
namespace Assignment1
{
    using System;
    using IronPython.Hosting;

    /// <summary>
    /// 
    /// </summary>
    public class TimeFunctions
    {
        public TimeFunctions ()
	    {}

        public TimeFunctions(string scriptPath)
        {
            this.ScriptPath = scriptPath;
        }

        public string ScriptPath { get; set; }

        public dynamic GetSecondsDifference(double time1, double time2)
        {
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var scriptSource = engine.CreateScriptSourceFromFile(this.ScriptPath);

            var compiled = scriptSource.Compile();

            compiled.Execute(scope);

            dynamic f_Seconds_Difference = scope.GetVariable("seconds_difference");

            return engine.Operations.Invoke(f_Seconds_Difference, time1, time2);
        }
    }
}