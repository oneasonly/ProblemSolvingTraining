using System;
using System.Collections.Generic;

namespace Week5Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                var input = Console.ReadLine();
                var x = FindUniqueLine(input);
                Console.WriteLine($"{x.Length} = {x.Str}; index = {x.LastIndex}");
            }
        }

        public static Result FindUniqueLine(string input)
        {
            if (input is null) return default(Result);
            if (input.Length == 1) return new Result(1, input, 1);

            Result longest = default(Result);
            var subString = new HashSet<char>(30);
            subString.Add(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if(subString.Contains(input[i]))
                {
                    if(subString.Count > longest.Length)
                    {
                        var str = string.Join("",subString);
                        longest = new Result(subString.Count, str, i-1);
                    }
                    subString.Clear();
                }
                else
                {
                    subString.Add(input[i]);
                }
            }
            return longest;
        }

        public struct Result
        {
            public Result(int length, string str, int lastIndex)
            {
                Length = length;
                Str = str;
                LastIndex = lastIndex;
            }
            public int Length { get; set; }
            public string Str { get; set; }
            public int LastIndex { get; set; }
        }
    }
}
