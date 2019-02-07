using ArrayPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

[TestClass]
public class _1_InputFiveToArrayTest
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

        StreamWriter standardOut = new StreamWriter(Console.OpenStandardOutput());
        standardOut.AutoFlush = true;
        Console.SetOut(standardOut);
    }

    [TestMethod]
    public void T1_InputFiveToArray_CreateFunction()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "InputFiveToArray");

        Assert.IsNotNull(methodInfo, "InputFiveToArray function does not exist.");
        Assert.IsTrue(methodInfo.IsStatic, "InputFiveToArray function needs to be static");
        Assert.IsTrue(methodInfo.IsPublic, "InputFiveToArray function needs to be public");

    }


    [TestMethod]
    public void T2_InputFiveToArray_LocalVariableCheck()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "InputFiveToArray");
        Assert.IsTrue(TestUtils.FindLocalVariable(methodInfo, typeof(string[])), "InputFiveToArray does not have string[] local variable.");
    }

    [TestMethod]
    public void T3_InputFiveToArray_FunctionReturnCheck()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "InputFiveToArray");

        Assert.IsTrue(methodInfo.ReturnType == typeof(string[]), "InputFiveToArray must return string[].");
    }



    [TestMethod]
    public void T4_InputFiveToArray_CheckReturn()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "InputFiveToArray");
        LocalVariableInfo localVariable = TestUtils.GetLocalVariableByType(methodInfo, typeof(string[]));


        string[] retVal;
        using (StringReader sr = new StringReader(string.Format("111{0}222{0}333{0}444{0}555{0}", Environment.NewLine)))
        {
            Console.SetIn(sr);

            //Program.InputFiveToArray();
            retVal = (string[])methodInfo.Invoke(null, new object[] { });


        }
        Assert.AreEqual(TestUtils.ArraysToString(new String[] { "111", "222", "333", "444", "555" }), TestUtils.ArraysToString(retVal), $"InputFiveToArray must return array with 5 input strings entered by Console.ReadLine().");
    }




    [TestMethod]
    public void T5_InputFiveToArray_CheckPrintInSequence()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "InputFiveToArray");
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            string[] retVal;
            using (StringReader sr = new StringReader(string.Format("111{0}222{0}333{0}444{0}555{0}", Environment.NewLine)))
            {
                Console.SetIn(sr);

                //retVal = Program.InputFiveToArray();
                retVal = (string[])methodInfo.Invoke(null, new object[] { });


                if (!sw.ToString().Contains("111222333444555"))
                {
                    Assert.Fail("InputFiveToArray must print all 5 entered texts in sequence.");
                }
            }
        }
    }

    [TestMethod]
    public void T6_InputFiveToArray_CheckPrintBacword()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "InputFiveToArray");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            string[] retVal;
            using (StringReader sr = new StringReader(string.Format("111{0}222{0}333{0}444{0}555{0}", Environment.NewLine)))
            {
                Console.SetIn(sr);

                //retVal = Program.InputFiveToArray();
                retVal = (string[])methodInfo.Invoke(null, new object[] { });

                if (!sw.ToString().Contains("555444333222111"))
                {
                    Assert.Fail("InputFiveToArray must print all 5 entered texts bacword.");
                }
            }
        }
    }
}
