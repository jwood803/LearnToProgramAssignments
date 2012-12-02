namespace Assignment1
{
    using System;
    using IronPython.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            var timeFuncs = new TimeFunctions("TimeFunctions.py");

            Console.WriteLine("seconds_difference with arguments: {0}, {1} returns {2}", 1800.0, 1800.0, timeFuncs.GetSecondsDifference(1800.0, 1800.0));

            Console.ReadLine();
        }
    }
}