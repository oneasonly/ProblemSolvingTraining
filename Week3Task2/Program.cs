using System;
using System.Linq;

namespace Week3Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"==================");
                var array = InitArray();
                var result = GetSumOfSeparators(array);
                Console.WriteLine($"Result = {result}");
                Console.ReadKey();
            }
        }

        public static int GetSumOfSeparators(int[] array)
        {
            int size = array.Length;
            int lastId = size - 1;
            for (int i = 0; i < size; i++)
            {
                int leftSum = SumArray(array, 0, i);
                for (int n = lastId; n >= 0; n--)
                {
                    if (i + 2 > n - 2) break;
                    int rightSum = SumArray(array, n, lastId);
                    if (leftSum == rightSum)
                    {
                        Console.WriteLine($"Found left & right! {array[i + 1]}[{i + 1}] & {array[n - 1]}[{lastId - (n - 1)}] = {leftSum}");
                        int middleSum = SumArray(array, i + 2, n - 2);
                        if (middleSum == leftSum)
                        {
                            int sumSeparators = array[i + 1] + array[n - 1];
                            Console.WriteLine($"{array[i + 1]}[{i + 1}] + {array[n - 1]}[{lastId - (n - 1)}]");
                            return sumSeparators;
                        }
                        ConsoleInfo(array, i, leftSum, n, middleSum);
                    }
                    if (leftSum < rightSum) break;
                }
            }
            return -1;
        }

        private static void ConsoleInfo(int[] array, int i, int leftSum, int n, int middleSum)
        {
            Console.Write($"LeftSum({leftSum}) != MiddleSum({middleSum}): ");
            //for (int z = i + 2; z <= n - 2; z++)
            //{
            //    Console.Write($"{array[z]} ");
            //}
            Console.WriteLine();
        }

        private static int SumArray(int[] array, int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        private static int[] InitArray()
        {
            //int sizeArray = new Random().Next(5, 9999);
            int sizeArray = 2222;
            var array = new int[sizeArray];
            for (int i = 0; i < sizeArray; i++)
            {
                array[i] = new Random().Next(999);
                //Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            return array;
        }
    }
}
