using NUnit.Framework;
using Week3Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Task2.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        [TestCase(new int[] { 7, 0, 7, 0, 7 }, 0)]
        [TestCase(new int[] { 1, 9, 0, 2, 8, 0, 3, 7 }, 0)]
        [TestCase(new int[] { 3, 2, 6, 1, 0, 3, 1, 7, 2, 2, 0, 5, 3, 1 }, 3)]
        [TestCase(new int[] { 3, 2, 6, 4, 0, 3, 1, 7, 3, 2, 0, 5, 3, 1 }, 7)]
        [TestCase(new int[] { 1, 7, 9, 8, 9, 8}, 18)]
        [TestCase(new int[] { 1, 7, 9, 8, 9, 5,1,1,1 }, 18)]
        [TestCase(new int[] { 1, 7, 9, 8, 9, 7, 1, 0 }, 18)]
        [TestCase(new int[] { 1, 7, 9, 8, 9, 7, 0, 1, 0 }, 18)]
        [TestCase(new int[] { 1, 3, 4, 9, 2, 5, 1, 9, 3, 0, 5, 0 }, 18)]
        public void GetSumOfSeparatorsTest_True(int[] arrange, int expect)
        {
            int act = Program.GetSumOfSeparators(arrange);
            Assert.IsTrue(act == expect);
        }

        [TestCase(new int[] { 7, 0, 8, 0, 7 })]
        [TestCase(new int[] { 8, 0, 7, 0, 7 })]
        [TestCase(new int[] { 7, 0, 7, 0, 8 })]
        [TestCase(new int[] { 8, 0, 7, 0, 8 })]
        [TestCase(new int[] { 8, 0, 8, 0, 7 })]
        [TestCase(new int[] { 7, 7, 0, 7 })]
        [TestCase(new int[] { 3, 2, 6, 1, 0, 4, 1, 7, 2, 2, 0, 5, 3, 1 })]
        public void GetSumOfSeparatorsTest_False(int[] arrange)
        {
            int act = Program.GetSumOfSeparators(arrange);
            Assert.IsTrue(act == -1);
        }
    }
}