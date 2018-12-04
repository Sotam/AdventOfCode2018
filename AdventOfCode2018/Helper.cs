namespace AdventOfCode2018
{
    using System;

    public static class Helper
    {
        public static string[] SplitInput(string input)
        {
            return input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
