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
    public class ConditionTest
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
        public void AConditionTest_CreateFunction()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "CheckMarkAvarage");

            Assert.IsNotNull(methodInfo, "CheckMarkAvarage function does not exist.");
            Assert.IsTrue(methodInfo.IsStatic, "CheckMarkAvarage function needs to be static");

        }

        [TestMethod]
        public void ConditionTest_ParameterTest()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "CheckMarkAvarage");

            ParameterInfo[] parameters = methodInfo.GetParameters();
            int paramCount = 0;
            int floatParamCount = 0;
            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo param = parameters[i];
                paramCount++;
                if (param.ParameterType == typeof(float))
                {
                    floatParamCount++;
                }
            }

            Assert.IsTrue(paramCount == 3, "CheckMarkAvarage function should have exactly 3 parameters.");
            Assert.IsTrue(floatParamCount == 3, "CheckMarkAvarage function parameters should all be float. ");

        }


        [TestMethod]
        public void ConditionTest_FunctionReturnCheck()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "CheckMarkAvarage");

            Assert.IsTrue(methodInfo.ReturnType == typeof(string), "CheckMarkAvarage must return string.");
        }

        [TestMethod]
        public void ConditionTest_BadMarkTest()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "CheckMarkAvarage");

            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { 3.49f, 3.5f, 3.5f }), "CheckMarkAvarage should return 'blogai' if first of argument is < 3.5");
            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { 3.5f, 3.49f, 3.5f }), "CheckMarkAvarage should return 'blogai' if second of argument is < 3.5");
            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { 3.5f, 3.5f, 3.49f }), "CheckMarkAvarage should return 'blogai' if third of argument is < 3.5");
            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { 1f, 3.5f, 3.5f }), "CheckMarkAvarage should return 'blogai' if first of argument is < 3.5");
            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { 3.5f, 1f, 3.5f }), "CheckMarkAvarage should return 'blogai' if second of argument is < 3.5");
            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { 3.5f, 3.5f, 1f }), "CheckMarkAvarage should return 'blogai' if third of argument is < 3.5");
            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { -1f, 3.5f, 3.5f }), "CheckMarkAvarage should return 'blogai' if first of argument is < 3.5");
            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { 3.5f, -1f, 3.5f }), "CheckMarkAvarage should return 'blogai' if second of argument is < 3.5");
            Assert.AreEqual("blogai", (string)methodInfo.Invoke(null, new object[] { 3.5f, 3.5f, -1f }), "CheckMarkAvarage should return 'blogai' if third of argument is < 3.5");

        }

        [TestMethod]
        public void ConditionTest_GoodMarkTest()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "CheckMarkAvarage");

            Assert.AreEqual("Labai puiku!", (string)methodInfo.Invoke(null, new object[] { 10f, 10f, 10f }), "CheckMarkAvarage should return 'Labai puiku!' if all argument are > 8");
            Assert.AreEqual("Labai puiku!", (string)methodInfo.Invoke(null, new object[] { 9f, 9f, 9f }), "CheckMarkAvarage should return 'Labai puiku!' if all argument are > 8");
            Assert.AreEqual("Labai puiku!", (string)methodInfo.Invoke(null, new object[] { 100f, 100f, 100f }), "CheckMarkAvarage should return 'Labai puiku!' if all argument are > 8");
            Assert.AreEqual("Labai puiku!", (string)methodInfo.Invoke(null, new object[] { 1000f, 1000f, 1000f }), "CheckMarkAvarage should return 'Labai puiku!' if all argument are > 8");
            Assert.AreEqual("Labai puiku!", (string)methodInfo.Invoke(null, new object[] { 8.1f, 8.1f, 8.1f }), "CheckMarkAvarage should return 'Labai puiku!' if all argument are > 8");

        }

        [TestMethod]
        public void ConditionTest_AvalageMarkTest()
        {
            MethodInfo methodInfo = Utils.GetMethod(programType, "CheckMarkAvarage");

            Assert.AreEqual("Vidurkis:10", (string)methodInfo.Invoke(null, new object[] { 5f, 10f, 15f }), "CheckMarkAvarage should return 'Vidurkis:10' for numbers 5, 10, 15 ");
            Assert.AreEqual("Vidurkis:10", (string)methodInfo.Invoke(null, new object[] { 10f, 5f, 15f }), "CheckMarkAvarage should return 'Vidurkis:10' for numbers 10, 5, 15 ");
            Assert.AreEqual("Vidurkis:10", (string)methodInfo.Invoke(null, new object[] { 15f, 10f, 5f }), "CheckMarkAvarage should return 'Vidurkis:10' for numbers 15, 10, 5 ");

        }



    }
}
