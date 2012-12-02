namespace Assignment1
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var timeFuncs = new TimeFunctions("TimeFunctions.py");

            Console.WriteLine("seconds_difference with arguments: {0}, {1} returns {2}", 1800.0, 1800.0, timeFuncs.GetSecondsDifference(1800.0, 1800.0));
            Console.WriteLine("seconds_difference with arguments: {0}, {1} returns {2}", 1800.0, 2160.0, timeFuncs.GetSecondsDifference(1800.0, 2160.0));

            Console.WriteLine("hours_difference with arguments: {0}, {1} returns {2}", 1800.0, 1800.0, timeFuncs.GetHoursDifference(1800.0, 1800.0));
            Console.WriteLine("hours_difference with arguments: {0}, {1} returns {2}", 1800.0, 2160.0, timeFuncs.GetHoursDifference(1800.0, 2160.0));

            Console.WriteLine("to_float_hours with arguments: {0}, {1}, {2} returns {3}", 0, 15, 0, timeFuncs.GetFloatHours(0, 15, 0));
            Console.WriteLine("to_float_hours with arguments: {0}, {1}, {2} returns {3}", 2, 45, 9, timeFuncs.GetFloatHours(2, 45, 9));
            Console.WriteLine("to_float_hours with arguments: {0}, {1}, {2} returns {3}", 1, 0, 36, timeFuncs.GetFloatHours(1, 0, 36));

            Console.ReadLine();
        }
    }
}