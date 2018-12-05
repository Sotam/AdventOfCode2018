using System;

namespace AdventOfCode2018
{
    using System.Diagnostics;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //var day1 = new Day1();
            //var day1SolveA = day1.SolveA();
            //Console.WriteLine($"{nameof(Day1.SolveA)} is {day1SolveA} in {stopwatch.ElapsedMilliseconds} msec");

            //var day1SolveB = day1.SolveB();
            //Console.WriteLine($"{nameof(Day1.SolveB)} is {day1SolveB} in {stopwatch.ElapsedMilliseconds} msec");

            var day2 = new Day2();
            //var day2SolveA = day2.SolveA();
            //Console.WriteLine($"{nameof(Day2.SolveA)} is {day2SolveA} in {stopwatch.ElapsedMilliseconds} msec");

            var day2SolveB = day2.SolveB();
            Console.WriteLine($"{nameof(Day2.SolveB)} is {day2SolveB} in {stopwatch.ElapsedMilliseconds} msec");

            Console.ReadLine();
        }
    }
}
