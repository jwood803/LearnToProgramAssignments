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
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Functions to call the Python script with arguments and return the result
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
            Debug.Assert(time1 > 0, "time1 > 0");
            Debug.Assert(time2 > 0, "time2 > 0");

            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Seconds_Difference = scope.GetVariable("seconds_difference");

            return (double)engine.Operations.Invoke(f_Seconds_Difference, time1, time2);
        }

        public double GetHoursDifference(double time1, double time2)
        {
            Debug.Assert(time1 > 0, "time1 > 0");
            Debug.Assert(time2 > 0, "time2 > 0");

            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Hours_Difference = scope.GetVariable("hours_difference");

            return (double)engine.Operations.Invoke(f_Hours_Difference, time1, time2);
        }

        public double GetFloatHours(int hours, int minutes, int secods)
        {
            Debug.Assert(hours >= 0, "hours > 0");
            Debug.Assert(minutes >= 0, "minutes > 0");
            Debug.Assert(secods >= 0, "secods > 0");

            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Get_Float_Hours = scope.GetVariable("to_float_hours");

            return (double)engine.Operations.Invoke(f_Get_Float_Hours, hours, minutes, secods);
        }

        public int GetHoursFromMidnight(int seconds)
        {
            Contract.Requires(seconds >= 0);

            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Get_Hours = scope.GetVariable("get_hours");

            return (int)engine.Operations.Invoke(f_Get_Hours, seconds);
        }

        public int GetMinutesFromMidnight(int seconds)
        {
            Contract.Requires(seconds >= 0);

            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Get_Minutes = scope.GetVariable("get_minutes");

            return (int)engine.Operations.Invoke(f_Get_Minutes, seconds);
        }

        public int GetSecondsFromMidnight(int seconds)
        {
            Contract.Requires(seconds >= 0);

            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Get_Seconds = scope.GetVariable("get_seconds");

            return (int)engine.Operations.Invoke(f_Get_Seconds, seconds);
        }

        public double GetTimeToUtc(int utcTimeZone, double time)
        {
            Contract.Requires(utcTimeZone >= 0);
            Contract.Requires(time >= 0);

            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Get_Time_To_Utc = scope.GetVariable("time_to_utc");

            return (double)engine.Operations.Invoke(f_Get_Time_To_Utc, utcTimeZone, time);
        }

        public double GetTimeFromUtc(int utcOffset, double time)
        {
            Contract.Requires(utcOffset >= 0);
            Contract.Requires(time >= 0);

            var engine = CreatePythonEngineWithSourceFile();

            var scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic f_Get_Time_From_Utc = scope.GetVariable("time_from_utc");

            return (double)engine.Operations.Invoke(f_Get_Time_From_Utc, utcOffset, time);
        }

        private ScriptEngine CreatePythonEngineWithSourceFile()
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(this.ScriptPath), "this.ScriptPath is null or empty");

            var engine = Python.CreateEngine();
            scriptSource = engine.CreateScriptSourceFromFile(this.ScriptPath);
            compiledCode = scriptSource.Compile();
            return engine;
        }
    }
}