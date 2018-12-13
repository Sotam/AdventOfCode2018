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

            var day1 = new Day1();
            stopwatch.Reset();
            var day1SolveA = day1.SolveA();
            Console.WriteLine($"{nameof(Day1.SolveA)} is {day1SolveA} in {stopwatch.ElapsedMilliseconds} msec");

            stopwatch.Reset();
            var day1SolveB = day1.SolveB();
            Console.WriteLine($"{nameof(Day1.SolveB)} is {day1SolveB} in {stopwatch.ElapsedMilliseconds} msec");

            var day2 = new Day2();
            stopwatch.Reset();
            var day2SolveA = day2.SolveA();
            Console.WriteLine($"{nameof(Day2.SolveA)} is {day2SolveA} in {stopwatch.ElapsedMilliseconds} msec");

            stopwatch.Reset();
            var day2SolveB = day2.SolveB();
            Console.WriteLine($"{nameof(Day2.SolveB)} is {day2SolveB} in {stopwatch.ElapsedMilliseconds} msec");

            var day3 = new Day3();
            stopwatch.Reset();
            var day3SolveA = day3.SolveA();
            Console.WriteLine($"{nameof(Day3.SolveA)} is {day3SolveA} in {stopwatch.ElapsedMilliseconds} msec");

            stopwatch.Reset();
            var day3SolveB = day3.SolveB();
            Console.WriteLine($"{nameof(Day3.SolveB)} is {day3SolveB} in {stopwatch.ElapsedMilliseconds} msec");

            var day4 = new Day4();
            stopwatch.Reset();
            var day4SolveA = day4.SolveA();
            Console.WriteLine($"{nameof(Day4.SolveA)} is {day4SolveA} in {stopwatch.ElapsedMilliseconds} msec");

            stopwatch.Reset();
            var day4SolveB = day4.SolveB();
            Console.WriteLine($"{nameof(Day4.SolveB)} is {day4SolveB} in {stopwatch.ElapsedMilliseconds} msec");

            Console.ReadLine();
        }
    }
}
