using System;
using System.Collections.Generic;
using System.Linq;

namespace Week5Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                int k = Convert.ToInt32(input);
                var x = FindUniqueLine(k, new List<int> { 1, 2, 3, 4, 5, 6 });
                Console.WriteLine($"K={k}; {x.SubArray} = {x.Sum} ([{x.CurrIndex + 1}] + {x.AmountNeighbors})");
            }
        }

        public static Result FindUniqueLine(int k, List<int> input)
        {
            if (input is null) return default(Result);

            int maxSum = 0;
            int AmountNeighbors = 0;            
            var result = default(Result);
            while (AmountNeighbors < input.Count)
            {
                int curIndex = 0;
                while (curIndex + AmountNeighbors < input.Count)
                {
                    int tempSum = 0;
                    var arr = new List<int>(AmountNeighbors+1);
                    for (int i = curIndex; i <= curIndex + AmountNeighbors; i++)
                    {
                        tempSum += input[i];
                        arr.Add(input[i]);
                    }
                    if(tempSum > maxSum)
                    {
                        if (tempSum >= k) return new Result(tempSum, curIndex, AmountNeighbors, string.Join(",", arr));
                    }
                    curIndex++;
                }
                AmountNeighbors++;
            }
            result.Sum = -1;
            return result;
        }

        public struct Result
        {
            public Result(int sum, int curIndex, int amount, string subArray)
            {
                Sum = sum;
                SubArray = subArray;
                CurrIndex = curIndex;
                AmountNeighbors = amount;
            }
            public int Sum { get; set; }
            public int CurrIndex { get; set; }
            public int AmountNeighbors { get; set; }
            public string SubArray { get; set; }
        }
    }
}
