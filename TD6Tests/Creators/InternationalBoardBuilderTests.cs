using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6.Tests
{
    [TestClass()]
    public class InternationalBoardBuilderTests
    {
        [TestMethod()]
        public void BuildDefaultBoardTest_CorrectCount()
        {
            IBoard board = InternationalBoardBuilder.BuildDefaultBoard();
            Assert.IsTrue(board.Count == 40);
        }
    }
}