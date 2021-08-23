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
        [TestCase(0, 7, 0, 7, 0, 7 )]
        [TestCase(0, 1, 9, 0, 2, 8, 0, 3, 7)]
        [TestCase(3, 3, 2, 6, 1, 0, 3, 1, 7, 2, 2, 0, 5, 3, 1)]
        [TestCase(7, 3, 2, 6, 4, 0, 3, 1, 7, 3, 2, 0, 5, 3, 1 )]
        [TestCase(18, 1, 7, 9, 8, 9, 8 )]
        [TestCase(18, 1, 7, 9, 8, 9, 5,1,1,1 )]
        [TestCase(18, 1, 7, 9, 8, 9, 7, 1, 0 )]
        [TestCase(18, 1, 7, 9, 8, 9, 7, 0, 1, 0 )]
        [TestCase(18, 1, 3, 4, 9, 2, 5, 1, 9, 3, 0, 5, 0 )]
        public void GetSumOfSeparatorsTest_True(int expect, params int[] arrange)
        {
            int act = Program.GetSumOfSeparators(arrange);
            Assert.IsTrue(act == expect);
        }

        [TestCase(7, 0, 8, 0, 7)]
        [TestCase(8, 0, 7, 0, 7)]
        [TestCase(7, 0, 7, 0, 8)]
        [TestCase(8, 0, 7, 0, 8)]
        [TestCase(8, 0, 8, 0, 7)]
        [TestCase(7, 7, 0, 7)]
        [TestCase(3, 2, 6, 1, 0, 4, 1, 7, 2, 2, 0, 5, 3, 1)]
        public void GetSumOfSeparatorsTest_False(params int[] arrange)
        {
            int act = Program.GetSumOfSeparators(arrange);
            Assert.IsTrue(act == -1);
        }
    }
}