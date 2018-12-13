namespace AdventOfCode2018
{
    using System.Collections.Generic;

    public class Day1 : BaseDay
    {
        public override string SolveA()
        {
            var splittedInput = Helper.SplitInput(Input);

            var total = 0;
            foreach (var s in splittedInput)
            {
                var number = int.Parse(s.Substring(1));

                if (s[0] == '+')
                {
                    total += number;
                }
                else
                {
                    total += number * -1;
                }
            }

            return $"{total}";
        }

        public override string SolveB()
        {
            var splittedInput = Helper.SplitInput(Input);

            var total = 0;
            var foundFrequencies = new List<int>();
            while (true)
            {
                foreach (var s in splittedInput)
                {
                    var number = int.Parse(s.Substring(1));

                    if (s[0] == '+')
                    {
                        total += number;
                    }
                    else
                    {
                        total += number * -1;
                    }

                    if (foundFrequencies.Contains(total))
                    {
                        return $"{total}";
                    }

                    foundFrequencies.Add(total);
                }
            }
        }

        public const string Input = "-2\r\n-3\r\n+4\r\n-15\r\n-15\r\n+18\r\n-7\r\n+11\r\n-16\r\n-14\r\n+2\r\n-6\r\n+16\r\n+6\r\n+14\r\n-15\r\n+12\r\n-5\r\n+17\r\n-10\r\n-20\r\n-19\r\n-14\r\n-10\r\n+4\r\n-11\r\n+10\r\n-1\r\n+12\r\n-17\r\n-2\r\n+1\r\n-17\r\n+9\r\n+4\r\n+19\r\n+11\r\n-17\r\n+15\r\n-12\r\n+5\r\n+4\r\n-1\r\n-10\r\n-19\r\n-16\r\n-9\r\n+18\r\n+2\r\n+4\r\n-19\r\n+16\r\n+6\r\n-16\r\n-14\r\n+7\r\n-9\r\n+7\r\n+17\r\n+17\r\n-14\r\n+6\r\n-22\r\n-13\r\n-2\r\n-1\r\n-18\r\n-3\r\n+19\r\n+19\r\n+16\r\n-22\r\n+14\r\n-2\r\n-3\r\n+2\r\n-18\r\n-15\r\n-14\r\n-4\r\n-15\r\n+1\r\n-3\r\n-8\r\n+18\r\n-11\r\n+6\r\n-7\r\n+17\r\n+7\r\n-8\r\n-13\r\n-4\r\n+7\r\n-15\r\n-11\r\n+7\r\n+9\r\n-7\r\n+1\r\n-20\r\n-19\r\n-18\r\n-17\r\n-12\r\n+7\r\n-16\r\n-11\r\n-4\r\n-8\r\n-4\r\n-3\r\n-2\r\n+3\r\n-15\r\n+18\r\n+5\r\n+14\r\n+15\r\n+2\r\n-19\r\n+5\r\n-13\r\n+19\r\n+9\r\n+8\r\n+5\r\n-1\r\n-19\r\n+11\r\n+2\r\n+13\r\n-17\r\n+9\r\n-16\r\n+14\r\n+20\r\n+12\r\n+8\r\n+10\r\n+17\r\n-15\r\n-8\r\n+15\r\n+19\r\n-14\r\n-3\r\n-10\r\n+2\r\n+4\r\n-1\r\n+14\r\n-12\r\n+15\r\n-2\r\n-11\r\n-14\r\n-18\r\n+6\r\n-12\r\n+7\r\n+18\r\n+15\r\n+6\r\n+12\r\n+3\r\n-6\r\n+17\r\n+11\r\n+14\r\n+13\r\n+3\r\n+6\r\n-11\r\n-19\r\n-5\r\n+14\r\n-10\r\n-7\r\n+18\r\n-8\r\n-13\r\n-2\r\n+19\r\n-18\r\n-17\r\n+11\r\n+14\r\n+17\r\n+1\r\n+26\r\n+6\r\n+15\r\n+21\r\n-5\r\n+12\r\n+6\r\n+4\r\n+10\r\n-8\r\n+16\r\n-14\r\n+4\r\n-1\r\n+17\r\n-15\r\n-23\r\n+15\r\n+18\r\n+19\r\n+10\r\n-18\r\n-2\r\n+15\r\n+15\r\n+13\r\n+5\r\n+10\r\n-8\r\n+2\r\n-18\r\n+13\r\n+15\r\n+8\r\n-19\r\n+2\r\n-4\r\n-3\r\n+20\r\n-3\r\n+12\r\n+6\r\n+13\r\n+13\r\n-15\r\n+6\r\n-15\r\n+3\r\n+7\r\n-19\r\n+11\r\n+17\r\n+15\r\n-4\r\n-10\r\n-14\r\n-20\r\n+18\r\n-11\r\n-17\r\n+8\r\n+12\r\n+3\r\n-11\r\n+7\r\n-13\r\n-4\r\n+19\r\n-7\r\n-17\r\n+12\r\n+9\r\n+13\r\n+7\r\n-13\r\n+24\r\n-2\r\n+14\r\n-5\r\n+10\r\n-6\r\n-1\r\n-8\r\n-5\r\n-6\r\n+5\r\n+12\r\n+16\r\n+5\r\n-14\r\n+19\r\n+18\r\n-9\r\n-6\r\n-12\r\n-2\r\n+19\r\n-12\r\n-9\r\n+5\r\n-4\r\n-9\r\n-9\r\n+16\r\n-19\r\n-14\r\n-7\r\n-24\r\n-20\r\n+16\r\n+12\r\n+19\r\n+20\r\n-15\r\n+26\r\n+21\r\n-2\r\n+12\r\n+4\r\n-2\r\n+18\r\n-17\r\n-12\r\n-20\r\n+2\r\n+9\r\n+14\r\n+16\r\n+12\r\n-9\r\n+14\r\n+17\r\n-19\r\n+11\r\n+3\r\n-13\r\n-3\r\n+11\r\n-14\r\n+18\r\n+9\r\n-16\r\n-2\r\n+19\r\n+7\r\n-10\r\n-3\r\n+4\r\n+10\r\n+15\r\n+19\r\n-2\r\n-5\r\n+2\r\n+2\r\n-11\r\n+6\r\n-17\r\n-11\r\n+6\r\n-10\r\n+16\r\n+7\r\n-1\r\n-2\r\n+19\r\n+6\r\n+16\r\n-12\r\n+14\r\n-5\r\n+19\r\n-12\r\n+1\r\n-6\r\n-6\r\n-2\r\n+7\r\n+19\r\n+17\r\n-4\r\n+3\r\n+3\r\n+17\r\n+16\r\n-2\r\n-10\r\n-1\r\n-14\r\n-2\r\n-17\r\n-11\r\n+3\r\n-21\r\n+15\r\n+11\r\n+7\r\n-3\r\n-18\r\n+1\r\n-15\r\n-11\r\n+1\r\n-18\r\n+11\r\n+15\r\n-17\r\n-16\r\n-19\r\n+9\r\n-5\r\n+16\r\n-18\r\n+13\r\n+16\r\n-17\r\n-1\r\n-3\r\n-2\r\n+20\r\n+14\r\n-13\r\n-17\r\n+13\r\n+5\r\n+2\r\n+19\r\n+22\r\n-3\r\n-22\r\n+10\r\n-13\r\n+2\r\n-29\r\n-27\r\n-16\r\n+17\r\n-27\r\n+18\r\n-13\r\n-4\r\n+6\r\n-5\r\n+12\r\n-16\r\n-9\r\n+3\r\n+1\r\n+10\r\n-25\r\n-1\r\n-19\r\n+13\r\n+12\r\n+2\r\n-6\r\n-12\r\n+3\r\n+25\r\n+28\r\n-4\r\n+2\r\n+17\r\n-9\r\n+63\r\n+23\r\n-8\r\n+9\r\n-6\r\n+15\r\n-14\r\n+12\r\n+6\r\n+18\r\n-6\r\n-15\r\n+12\r\n-16\r\n-3\r\n+15\r\n+24\r\n+19\r\n-6\r\n+4\r\n-8\r\n-19\r\n+4\r\n+4\r\n-20\r\n-1\r\n+24\r\n+10\r\n-9\r\n+13\r\n+11\r\n+2\r\n+11\r\n+14\r\n-2\r\n+18\r\n-12\r\n+1\r\n-17\r\n+6\r\n+1\r\n-16\r\n+10\r\n+4\r\n+9\r\n-6\r\n+10\r\n-14\r\n-2\r\n+22\r\n+2\r\n+6\r\n+10\r\n-19\r\n-24\r\n+10\r\n+11\r\n+14\r\n+2\r\n+5\r\n+18\r\n+29\r\n+1\r\n+20\r\n+7\r\n+3\r\n-12\r\n+25\r\n-21\r\n+24\r\n+4\r\n-18\r\n+1\r\n+51\r\n+19\r\n-17\r\n-23\r\n+31\r\n-15\r\n+27\r\n+2\r\n+19\r\n-16\r\n+1\r\n+18\r\n+9\r\n+22\r\n+6\r\n+15\r\n-19\r\n+14\r\n-7\r\n+3\r\n+14\r\n-7\r\n-15\r\n+18\r\n-8\r\n-1\r\n-14\r\n-7\r\n-16\r\n+22\r\n+22\r\n-2\r\n+18\r\n+2\r\n-15\r\n-39\r\n+5\r\n+21\r\n-5\r\n-2\r\n+4\r\n+1\r\n+9\r\n-58\r\n+6\r\n-95\r\n-85\r\n-5\r\n+1\r\n+7\r\n+9\r\n+15\r\n-117\r\n-12\r\n-14\r\n-18\r\n+70\r\n+9\r\n-17\r\n+93\r\n-37\r\n-134\r\n-90\r\n+22\r\n-19\r\n-7\r\n-59\r\n+14\r\n-13\r\n-47\r\n+213\r\n+81022\r\n+9\r\n+5\r\n+4\r\n-3\r\n-16\r\n-2\r\n+4\r\n+2\r\n+5\r\n-12\r\n-9\r\n-13\r\n+2\r\n-18\r\n-18\r\n-14\r\n+7\r\n+18\r\n-19\r\n+13\r\n-1\r\n-6\r\n+9\r\n-1\r\n-18\r\n+15\r\n-14\r\n-4\r\n+12\r\n-1\r\n+5\r\n+16\r\n-7\r\n+12\r\n+6\r\n-16\r\n+13\r\n+10\r\n+3\r\n-11\r\n-13\r\n+6\r\n-7\r\n+16\r\n+3\r\n-6\r\n+19\r\n-15\r\n+14\r\n-1\r\n+19\r\n+19\r\n+13\r\n-9\r\n-3\r\n-10\r\n-14\r\n+15\r\n-9\r\n+19\r\n-6\r\n+10\r\n-7\r\n+11\r\n-1\r\n+3\r\n+2\r\n-3\r\n+8\r\n+3\r\n+13\r\n+6\r\n+3\r\n+2\r\n+18\r\n+9\r\n-17\r\n+13\r\n+15\r\n-13\r\n+9\r\n+2\r\n+19\r\n+14\r\n-13\r\n+8\r\n+18\r\n+6\r\n-4\r\n-18\r\n+1\r\n-19\r\n-1\r\n+10\r\n-5\r\n-11\r\n-10\r\n-16\r\n-4\r\n-5\r\n+3\r\n-13\r\n-19\r\n-18\r\n+16\r\n+16\r\n-5\r\n+16\r\n-10\r\n-8\r\n+9\r\n+14\r\n+1\r\n+9\r\n-3\r\n+19\r\n-12\r\n+11\r\n+12\r\n+5\r\n+19\r\n-9\r\n+4\r\n+15\r\n+19\r\n-4\r\n-10\r\n-12\r\n-18\r\n-16\r\n+13\r\n-4\r\n-16\r\n-14\r\n-15\r\n+18\r\n+1\r\n-8\r\n-7\r\n-18\r\n+3\r\n-21\r\n+9\r\n-7\r\n+8\r\n+18\r\n+2\r\n-11\r\n+6\r\n+10\r\n+9\r\n+11\r\n-21\r\n+19\r\n+4\r\n+2\r\n+7\r\n+10\r\n-16\r\n+13\r\n+9\r\n+9\r\n+16\r\n+9\r\n+13\r\n-11\r\n+16\r\n+10\r\n+14\r\n+13\r\n-5\r\n-10\r\n-16\r\n-2\r\n-2\r\n+6\r\n+19\r\n+1\r\n-16\r\n+14\r\n-13\r\n+3\r\n-5\r\n-4\r\n+12\r\n-5\r\n+22\r\n+11\r\n-5\r\n+13\r\n+4\r\n+13\r\n+19\r\n+18\r\n-13\r\n+15\r\n+19\r\n-12\r\n-11\r\n-19\r\n-12\r\n+5\r\n-19\r\n+18\r\n-19\r\n+5\r\n-13\r\n-10\r\n+15\r\n-8\r\n-2\r\n-2\r\n-11\r\n-6\r\n+5\r\n-4\r\n+21\r\n+18\r\n-5\r\n+18\r\n-11\r\n+19\r\n+12\r\n-5\r\n+4\r\n-16\r\n-10\r\n+11\r\n-16\r\n+13\r\n+11\r\n-1\r\n+15\r\n+4\r\n+13\r\n-15\r\n+14\r\n-7\r\n+19\r\n+10\r\n-8\r\n+19\r\n+4\r\n-7\r\n+19\r\n+8\r\n+14\r\n-7\r\n+3\r\n+13\r\n+19\r\n-9\r\n+4\r\n-17\r\n-19\r\n-11\r\n-11\r\n-4\r\n-16\r\n-21\r\n-5\r\n+1\r\n+16\r\n-11\r\n-15\r\n-18\r\n-13\r\n-7\r\n-13\r\n-21\r\n-18\r\n+10\r\n+14\r\n+13\r\n-7\r\n-1\r\n-4\r\n+17\r\n+20\r\n+12\r\n-24\r\n+3\r\n-8\r\n+3\r\n+10\r\n+11\r\n+11\r\n-16\r\n+13\r\n+12\r\n+19\r\n-2\r\n+7\r\n+6\r\n+5\r\n+3\r\n+10\r\n+15\r\n+2\r\n+11\r\n+14\r\n-9\r\n-1\r\n-19\r\n-16\r\n+9\r\n+17\r\n-13\r\n+4\r\n+6\r\n+2\r\n+13\r\n+16\r\n+19\r\n+12\r\n+1\r\n+18\r\n+17\r\n+19\r\n+5\r\n-8\r\n+6\r\n+10\r\n+16\r\n-9\r\n+13\r\n-8\r\n-9\r\n+5\r\n-12\r\n-7\r\n-16\r\n+4\r\n-12\r\n+18\r\n-19\r\n-7\r\n+2\r\n+2\r\n-19\r\n+10\r\n+19\r\n+9\r\n-6\r\n-18\r\n+4\r\n+18\r\n-11\r\n-13\r\n-11\r\n-16\r\n+3\r\n-4\r\n-11\r\n-2\r\n+10\r\n-14\r\n+16\r\n+14\r\n-1\r\n+2\r\n+1\r\n+4\r\n-9\r\n+17\r\n-5\r\n-14\r\n-15\r\n-13\r\n+16\r\n-8\r\n-11\r\n+2\r\n+19\r\n+23\r\n+15\r\n-13\r\n+20\r\n+3\r\n+7\r\n+9\r\n+17\r\n+10\r\n-11\r\n-19\r\n-19\r\n+9\r\n-17\r\n+12\r\n-20\r\n-22\r\n+16\r\n-9\r\n-18\r\n-10\r\n-9\r\n-81046";
    }
}
