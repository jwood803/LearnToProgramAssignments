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
    using PythonEnine;

	/// <summary>
	/// Functions to call the Python script with arguments and return the result
	/// </summary>
	public class TimeFunctions
	{
        private PythonEngine engine;

		public TimeFunctions()
		{
			//TODO: Default script path
		}

		public TimeFunctions(string scriptPath)
		{
			this.ScriptPath = scriptPath;
            engine = new PythonEngine(this.ScriptPath);
		}

		public string ScriptPath { get; set; }

		public double GetSecondsDifference(double time1, double time2)
		{
            Contract.Requires(time1 >= 0);
            Contract.Requires(time2 >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= double.MinValue);

            return (double)engine.InvokeMethodWithParameters("seconds_difference", time1, time2);
        }

		public double GetHoursDifference(double time1, double time2)
		{
            Contract.Requires(time1 >= 0);
            Contract.Requires(time2 >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= double.MinValue);

            return (double)engine.InvokeMethodWithParameters("hours_difference", time1, time2);
        }

		public double GetFloatHours(int hours, int minutes, int seconds)
		{
            Contract.Requires(hours >= 0);
            Contract.Requires(minutes >= 0);
            Contract.Requires(seconds >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= 0);

            return (double)engine.InvokeMethodWithParameters("to_float_hours", hours, minutes, seconds);
        }

		public int GetHoursFromMidnight(int seconds)
		{
			Contract.Requires(seconds >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

            return (int)engine.InvokeMethodWithParameters("get_hours", seconds);
        }

		public int GetMinutesFromMidnight(int seconds)
		{
			Contract.Requires(seconds >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

            return (int)engine.InvokeMethodWithParameters("get_minutes", seconds);
        }

		public int GetSecondsFromMidnight(int seconds)
		{
			Contract.Requires(seconds >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<int>() >= 0);

            return (int)engine.InvokeMethodWithParameters("get_seconds", seconds);
        }

		public double GetTimeToUtc(int utcTimeZone, double time)
		{
			Contract.Requires(utcTimeZone >= int.MinValue);
			Contract.Requires(time >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= double.MinValue);

            return (int)engine.InvokeMethodWithParameters("time_to_utc", utcTimeZone, time);
        }

		public double GetTimeFromUtc(int utcOffset, double time)
		{
			Contract.Requires(utcOffset >= int.MinValue);
			Contract.Requires(time >= 0);
            Contract.Requires(!string.IsNullOrWhiteSpace(this.ScriptPath));
            Contract.Ensures(Contract.Result<double>() >= double.MinValue);

            return (int)engine.InvokeMethodWithParameters("time_from_utc", utcOffset, time);
        }
	}
}