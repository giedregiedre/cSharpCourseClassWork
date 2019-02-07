using ArrayPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

[TestClass]
public class _3_ArrayReferenceTestTest
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
    public void T1_ArrayReferenceTest_CreateFunction()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ArrayReferenceTest");

        Assert.IsNotNull(methodInfo, "ArrayReferenceTest function does not exist.");
        Assert.IsTrue(methodInfo.IsStatic, "ArrayReferenceTest function needs to be static");
        Assert.IsTrue(methodInfo.IsPublic, "ArrayReferenceTest function needs to be public");
    }


    [TestMethod]
    public void T2_ArrayReferenceTest_LocalVariableCheck()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ArrayReferenceTest");
        Assert.IsTrue(TestUtils.FindLocalVariable(methodInfo, typeof(int[])), "ArrayReferenceTest does not have int[] local variable.");
    }

    [TestMethod]
    public void T3_ArrayReferenceTest_CheckOrigitalOutput()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ArrayReferenceTest");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            //Program.ArrayReferenceTest();
            methodInfo.Invoke(null, new object[] { });



            if (!sw.ToString().Contains("1 2 3 4 5"))
            {
                Assert.Fail("ArrayReferenceTest should print : \"1 2 3 4 5\"");
            }
        }
    }


    [TestMethod]
    public void T4_ArrayReferenceTest_SpoilArray_CreateFunction()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "SpoilArray");

        Assert.IsNotNull(methodInfo, "SpoilArray function does not exist.");
        Assert.IsTrue(methodInfo.IsStatic, "SpoilArray function needs to be static");
        Assert.IsTrue(methodInfo.IsPublic, "SpoilArray function needs to be public");

    }


    [TestMethod]
    public void T5_ArrayReferenceTest_SpoilArray_ArgumentCheck()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "SpoilArray");

        ParameterInfo[] parameters = methodInfo.GetParameters();
        int paramCount = 0;
        int strArrParamCount = 0;
        for (int i = 0; i < parameters.Length; i++)
        {
            ParameterInfo param = parameters[i];
            paramCount++;
            if (param.ParameterType == typeof(int[]))
            {
                strArrParamCount++;
            }
        }

        Assert.IsTrue(paramCount == 1, "SpoilArray function should have exactly 1 parameter.");
        Assert.IsTrue(strArrParamCount == 1, "SpoilArray function parameter should be int[]. ");

    }

    [TestMethod]
    public void T6_ArrayReferenceTest_CheckDamagedOutput()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ArrayReferenceTest");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            //Program.ArrayReferenceTest();
            methodInfo.Invoke(null, new object[] { });


            string outuput = sw.ToString();

            bool containsDamaged = outuput.Contains("-1 -1 -1 -1 -1");

            string[] split = outuput.Split("1 2 3 4 5");

            if (!containsDamaged && split.Length < 3)
            {
                Assert.Fail("ArrayReferenceTest should print after array is spoiled : \"-1 -1 -1 -1 -1\" OR \"1 2 3 4 5\" twice.");
            }
        }
    }






}
