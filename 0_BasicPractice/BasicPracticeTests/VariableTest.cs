using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BasicPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicPracticeTests
{
    [TestClass]
    public class VariableTest
    {

        private Program program;
        private Type programType;

        [TestInitialize]
        public void TestInit()
        {
            program = new Program();
            programType = typeof(Program);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            program = null;
            programType = null;
        }


        //----------------------------

        [TestMethod]
        public void AVariableTest_CreateFunction()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "PracticeVariables");

            Assert.IsNotNull(methodInfo, "PracticeVariables function does not exist.");
            Assert.IsTrue(methodInfo.IsStatic, "PracticeVariables function needs to be static");

        }

        [TestMethod]
        public void VariableTest_CreateIntVariable()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "PracticeVariables");
            Assert.IsTrue(Utils.FindLocalVariable(methodInfo, typeof(int)), "PracticeVariables does not have int local variable.");
        }

        [TestMethod]
        public void VariableTest_CreateFloatVariable()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "PracticeVariables");
            Assert.IsTrue(Utils.FindLocalVariable(methodInfo, typeof(float)), "PracticeVariables does not have float local variable.");
        }

        [TestMethod]
        public void VariableTest_CreateStringVariable()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "PracticeVariables");
            Assert.IsTrue(Utils.FindLocalVariable(methodInfo, typeof(string)), "PracticeVariables does not have string local variable.");
        }

        [TestMethod]
        public void VariableTest_CreateBoolVariable()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "PracticeVariables");
            Assert.IsTrue(Utils.FindLocalVariable(methodInfo, typeof(bool)), "PracticeVariables does not have bool local variable.");
        }

    }
}
