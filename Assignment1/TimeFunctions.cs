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
	using System.Diagnostics.Contracts;

	/// <summary>
	/// Functions to call the Python script with arguments and return the result
	/// </summary>
	public class TimeFunctions
	{
		ScriptSource scriptSource;
		CompiledCode compiledCode;

		public TimeFunctions()
		{
			//TODO: Default script path
		}

		public TimeFunctions(string scriptPath)
		{
			this.ScriptPath = scriptPath;
		}

		public string ScriptPath { get; set; }

		public double GetSecondsDifference(double time1, double time2)
		{
            Contract.Requires(time1 >= 0);
            Contract.Requires(time2 >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= double.MinValue);

			var engine = CreatePythonEngineWithSourceFile();

			var scope = engine.CreateScope();

			compiledCode.Execute(scope);

			dynamic f_Seconds_Difference = scope.GetVariable("seconds_difference");

			return (double)engine.Operations.Invoke(f_Seconds_Difference, time1, time2);
		}

		public double GetHoursDifference(double time1, double time2)
		{
            Contract.Requires(time1 >= 0);
            Contract.Requires(time2 >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= double.MinValue);

			var engine = CreatePythonEngineWithSourceFile();

			var scope = engine.CreateScope();

			compiledCode.Execute(scope);

			dynamic f_Hours_Difference = scope.GetVariable("hours_difference");

			return (double)engine.Operations.Invoke(f_Hours_Difference, time1, time2);
		}

		public double GetFloatHours(int hours, int minutes, int secods)
		{
            Contract.Requires(hours >= 0);
            Contract.Requires(minutes >= 0);
            Contract.Requires(secods >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= 0);

			var engine = CreatePythonEngineWithSourceFile();
			var scope = engine.CreateScope();

			compiledCode.Execute(scope);

			dynamic f_Get_Float_Hours = scope.GetVariable("to_float_hours");

			return (double)engine.Operations.Invoke(f_Get_Float_Hours, hours, minutes, secods);
		}

		public int GetHoursFromMidnight(int seconds)
		{
			Contract.Requires(seconds >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

			var engine = CreatePythonEngineWithSourceFile();
			var scope = engine.CreateScope();

			compiledCode.Execute(scope);

			dynamic f_Get_Hours = scope.GetVariable("get_hours");

			return (int)engine.Operations.Invoke(f_Get_Hours, seconds);
		}

		public int GetMinutesFromMidnight(int seconds)
		{
			Contract.Requires(seconds >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

			var engine = CreatePythonEngineWithSourceFile();
			var scope = engine.CreateScope();

			compiledCode.Execute(scope);

			dynamic f_Get_Minutes = scope.GetVariable("get_minutes");

			return (int)engine.Operations.Invoke(f_Get_Minutes, seconds);
		}

		public int GetSecondsFromMidnight(int seconds)
		{
			Contract.Requires(seconds >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

			var engine = CreatePythonEngineWithSourceFile();
			var scope = engine.CreateScope();

			compiledCode.Execute(scope);

			dynamic f_Get_Seconds = scope.GetVariable("get_seconds");

			return (int)engine.Operations.Invoke(f_Get_Seconds, seconds);
		}

		public double GetTimeToUtc(int utcTimeZone, double time)
		{
			Contract.Requires(utcTimeZone >= int.MinValue);
			Contract.Requires(time >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= double.MinValue);

			var engine = CreatePythonEngineWithSourceFile();
			var scope = engine.CreateScope();

			compiledCode.Execute(scope);

			dynamic f_Get_Time_To_Utc = scope.GetVariable("time_to_utc");

			return (double)engine.Operations.Invoke(f_Get_Time_To_Utc, utcTimeZone, time);
		}

		public double GetTimeFromUtc(int utcOffset, double time)
		{
			Contract.Requires(utcOffset >= int.MinValue);
			Contract.Requires(time >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= double.MinValue);

			var engine = CreatePythonEngineWithSourceFile();
			var scope = engine.CreateScope();

			compiledCode.Execute(scope);

			dynamic f_Get_Time_From_Utc = scope.GetVariable("time_from_utc");

			return (double)engine.Operations.Invoke(f_Get_Time_From_Utc, utcOffset, time);
		}

		private ScriptEngine CreatePythonEngineWithSourceFile()
		{
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));

			var engine = Python.CreateEngine();
			scriptSource = engine.CreateScriptSourceFromFile(this.ScriptPath);
			compiledCode = scriptSource.Compile();
			return engine;
		}
	}
}