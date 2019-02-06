using System;
using BasicPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicPracticeTests
{
    [TestClass]
    public class ProgramTest
    {

        private Program program;

        [TestInitialize]
        public void TestInit()
        {
            program = new Program();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            program = null;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(program, "Program object must exist.");
        }
    }
}
