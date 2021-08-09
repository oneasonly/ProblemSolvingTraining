using System;
using System.Diagnostics;

namespace Week3Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine($"==================");
                int incNum = new Random().Next();
                IsGetSumFromSquares(incNum);
                Console.ReadKey();
            }
        }

        public static bool IsGetSumFromSquares(int incNum)
        {
            Console.WriteLine($"Income value = {incNum};");
            int max = (int) Math.Sqrt(incNum);
            Console.WriteLine($"max = {max};");
            for (int i = 0; i <= max; i++)
            {
                int square1 = i*i;
                if (IsFound(square1, max, incNum)) return true;
            }
            Console.WriteLine($"Fail");
            return false;
        }
        public static bool IsFound(int square1, int max, int incNum)
        {
            for (int n = 1; n <= max; n++)
            {
                int sum = n * n + square1;
                if (sum > incNum) break;
                if (sum == incNum)
                {
                    Console.WriteLine($"Success: square1={square1}; n2={n};");
                    return true;
                }
                //Console.WriteLine($"square1={square1}; n2={n};");
            }
            return false;
        }
    }
}
