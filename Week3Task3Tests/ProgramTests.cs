using NUnit.Framework;
using Week3Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Task3.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        [TestCase(617)]
        [TestCase(425)]
        [TestCase(90)]
        [TestCase(82)]
        [TestCase(5)]
        [TestCase(9)]
        public void IsGetSumFromSquaresTest_True(int arg)
        {
            var act = Program.IsGetSumFromSquares(arg);
            Assert.IsTrue(act);            
        }

        [TestCase(486)]
        [TestCase(380)]
        [TestCase(99)]
        [TestCase(69)]
        [TestCase(62)]
        public void IsGetSumFromSquaresTest_False(int arg)
        {
            var act = Program.IsGetSumFromSquares(arg);
            Assert.IsFalse(act);
        }
    }
}