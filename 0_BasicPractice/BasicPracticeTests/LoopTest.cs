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
    public class LoopTest
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
        public void ALoopTest_CreateFunction()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "SumNumbersInRange");

            Assert.IsNotNull(methodInfo, "SumNumbersInRange function does not exist.");
            Assert.IsTrue(methodInfo.IsStatic, "SumNumbersInRange function needs to be static");
        }

        [TestMethod]
        public void LoopTest_FunctionFromArgumentCheck()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "SumNumbersInRange");

            ParameterInfo param = Utils.GetMethodParam(methodInfo, "from");

            Assert.IsNotNull(param, "SumNumbersInRange function needs parameter named from");

            Assert.IsTrue(param.ParameterType == typeof(int), "SumNumbersInRange parameter from needs to be int.");
        }

        [TestMethod]
        public void LoopTest_FunctionToArgumentCheck()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "SumNumbersInRange");

            ParameterInfo param = Utils.GetMethodParam(methodInfo, "to");

            Assert.IsNotNull(param, "SumNumbersInRange function needs parameter named to");

            Assert.IsTrue(param.ParameterType == typeof(int), "SumNumbersInRange parameter to needs to be int.");
        }

        [TestMethod]
        public void LoopTest_FunctionReturnCheck()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "SumNumbersInRange");

            Assert.IsTrue(methodInfo.ReturnType == typeof(int), "SumNumbersInRange must return int.");
        }

        [TestMethod]
        public void LoopTest_FunctionReturnSumCheck1()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "SumNumbersInRange");
            Assert.AreEqual(45, (int)methodInfo.Invoke(null, new object[] { 5, 10 }), "SumNumbersInRange sum from 5 to 10 should return 45.");
        }

        [TestMethod]
        public void LoopTest_FunctionReturnSumCheck2()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "SumNumbersInRange");
            Assert.AreEqual(0, (int)methodInfo.Invoke(null, new object[] { -100, 100 }), "SumNumbersInRange sum from -100 to 100 should return 0.");
        }

        [TestMethod]
        public void LoopTest_FunctionReturnSumCheck3()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "SumNumbersInRange");
            Assert.AreEqual(-123, (int)methodInfo.Invoke(null, new object[] { 1, -1 }), "SumNumbersInRange should return -123 if from bigger then to.");
        }



    }
}
