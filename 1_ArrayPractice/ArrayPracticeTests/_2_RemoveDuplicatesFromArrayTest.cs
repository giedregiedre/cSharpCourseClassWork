using ArrayPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

[TestClass]
public class _2_RemoveDuplicatesFromArrayTest
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
    public void T1_RemoveDuplicatesFromArray_CreateFunction()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "RemoveDuplicatesFromArray");

        Assert.IsNotNull(methodInfo, "RemoveDuplicatesFromArray function does not exist.");
        Assert.IsTrue(methodInfo.IsStatic, "RemoveDuplicatesFromArray function needs to be static");
        Assert.IsTrue(methodInfo.IsPublic, "RemoveDuplicatesFromArray function needs to be public");

    }


    [TestMethod]
    public void T2_RemoveDuplicatesFromArray_ArgumentCheck()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "RemoveDuplicatesFromArray");

        ParameterInfo[] parameters = methodInfo.GetParameters();
        int paramCount = 0;
        int strArrParamCount = 0;
        for (int i = 0; i < parameters.Length; i++)
        {
            ParameterInfo param = parameters[i];
            paramCount++;
            if (param.ParameterType == typeof(string[]))
            {
                strArrParamCount++;
            }
        }

        Assert.IsTrue(paramCount == 1, "RemoveDuplicatesFromArray function should have exactly 1 parameter.");
        Assert.IsTrue(strArrParamCount == 1, "RemoveDuplicatesFromArray function parameter should be string[]. ");

    }


    [TestMethod]
    public void T3_RemoveDuplicatesFromArray_CheckIfDublicatesRemoved()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "RemoveDuplicatesFromArray");

        string[] data = new string[] { "Mano", "batai", "Mano", "buvo", "batai", "buvo", "du", "buvo", "du", "." };

        //Program.RemoveDuplicatesFromArray(data);
        methodInfo.Invoke(null, new object[] { data });

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = i + 1; j < data.Length; j++)
            {
                if (data[i] == data[j] && data[i] != "!")
                {
                    Assert.Fail("RemoveDuplicatesFromArray should remove all dublicate strings. (exept \"!\". )");
                }
            }
        }

    }

    [TestMethod]
    public void T4_RemoveDuplicatesFromArray_CheckUnsortedOutput()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "RemoveDuplicatesFromArray");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            string[] data = new string[] { "Mano", "batai", "Mano", "buvo", "batai", "buvo", "du", "buvo", "du", "." };
            //Program.RemoveDuplicatesFromArray(data);
            methodInfo.Invoke(null, new object[] { data });


            if (!sw.ToString().Contains("Mano batai ! buvo ! ! du ! ! ."))
            {
                Assert.Fail("RemoveDuplicatesFromArray should print : \"Mano batai ! buvo ! ! du ! ! .\"");
            }
        }
    }


    [TestMethod]
    public void T5_RemoveDuplicatesFromArray_CheckSortedOutput()
    {
        MethodInfo methodInfo = TestUtils.GetMethod(programType, "RemoveDuplicatesFromArray");

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            string[] data = new string[] { "Mano", "batai", "Mano", "buvo", "batai", "buvo", "du", "buvo", "du", "." };
            //Program.RemoveDuplicatesFromArray(data);
            methodInfo.Invoke(null, new object[] { data });


            if (!sw.ToString().Contains("Mano batai buvo du . ! ! ! ! !"))
            {
                Assert.Fail("RemoveDuplicatesFromArray should print after sorting : \"Mano batai buvo du . ! ! ! ! !\"");
            }
        }
    }


}
