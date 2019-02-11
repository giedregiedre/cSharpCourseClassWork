using ArrayPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

[TestClass]
public class _4_ParamsTestingTest
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
    public void T1_ParamsTesting_CreateFunction()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ParamsTesting");

        Assert.IsNotNull(methodInfo, "ParamsTesting function does not exist.");
        Assert.IsTrue(methodInfo.IsStatic, "ParamsTesting function needs to be static");
        Assert.IsTrue(methodInfo.IsPublic, "ParamsTesting function needs to be public");
    }


    [TestMethod]
    public void T2_ParamsTesting_ArgumentCheck()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ParamsTesting");

        ParameterInfo[] parameters = methodInfo.GetParameters();
        int paramCount = 0;
        int intParamCount = 0;
        int floatArrParamCount = 0;
        int strArrParamCount = 0;

        for (int i = 0; i < parameters.Length; i++)
        {
            ParameterInfo param = parameters[i];
            paramCount++;
            if (param.ParameterType == typeof(int))
            {
                intParamCount++;
            }
            if (param.ParameterType == typeof(float[]))
            {
                floatArrParamCount++;
            }
            if (param.ParameterType == typeof(string[]))
            {
                strArrParamCount++;
            }

        }

        Assert.IsTrue(paramCount == 3, "ParamsTesting function should have exactly 3 parameter.");
        Assert.IsTrue(intParamCount == 1, "ParamsTesting function parameter should have int parameter. ");
        Assert.IsTrue(floatArrParamCount == 1, "ParamsTesting function parameter should have float[] parameter. ");
        Assert.IsTrue(strArrParamCount == 1, "ParamsTesting function parameter should have string[] parameter. ");

    }

    [TestMethod]
    public void T3_ParamsTesting_CheckIntPrint()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ParamsTesting");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            //Program.ParamsTesting();
            methodInfo.Invoke(null, new object[] { 12345678, new float[] { 1.2f, 3.4f, 5.6f } , new string[]{ "Labas", "rytas", "-", "mano", "saule!" } });

            string output = sw.ToString();
            if (!output.Contains("12345678"))
            {
                Assert.Fail("ParamsTesting should print int parameter.");
            }
        }
    }

    [TestMethod]
    public void T4_ParamsTesting_CheckFloatArrPrint()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ParamsTesting");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            //Program.ParamsTesting();
            methodInfo.Invoke(null, new object[] { 12345678, new float[] { 1.2f, 3.4f, 5.6f }, new string[] { "Labas", "rytas", "-", "mano", "saule!" } });

            if (!sw.ToString().Contains("1.2 3.4 5.6"))
            {
                Assert.Fail("ParamsTesting should print int parameter.");
            }
        }
    }

    [TestMethod]
    public void T5_ParamsTesting_CheckParamStringArrPrint()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "ParamsTesting");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            //Program.ParamsTesting();
            methodInfo.Invoke(null, new object[] { 12345678, new float[] { 1.2f, 3.4f, 5.6f }, new string[] { "Labas", "rytas", "-", "mano", "saule!" } });

            if (!sw.ToString().Contains("Labas rytas - mano saule!"))
            {
                Assert.Fail("ParamsTesting should print int parameter.");
            }
        }
    }






}
