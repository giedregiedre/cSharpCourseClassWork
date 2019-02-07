using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

class TestUtils
{
    //------------
    //-- help functions...
    //------------

    static public MethodInfo GetMethod(Type type, string methodName)
    {
        MethodInfo retVal = null;
        IEnumerable<MethodInfo> methodInfos = type.GetRuntimeMethods();
        foreach (MethodInfo info in methodInfos)
        {
            if (info.Name == methodName)
            {
                return info;
            }
        }
        return retVal;

    }

    static public LocalVariableInfo GetLocalVariableByType(MethodInfo methodInfo, Type type)
    {
        IList<LocalVariableInfo> localVars = methodInfo.GetMethodBody().LocalVariables;
        foreach (LocalVariableInfo local in localVars)
        {
            if (local.LocalType == type)
            {
                return local;
            }
        }
        return null;
    }

    static public bool FindLocalVariable(MethodInfo methodInfo, Type type)
    {
        IList<LocalVariableInfo> localVars = methodInfo.GetMethodBody().LocalVariables;
        foreach (LocalVariableInfo local in localVars)
        {
            if (local.LocalType == type)
            {
                return true;
            }
        }
        return false;
    }

    internal static ParameterInfo GetMethodParam(MethodInfo methodInfo, string paramName)
    {
        ParameterInfo[] parameters = methodInfo.GetParameters();
        for (int i = 0; i < parameters.Length; i++)
        {
            ParameterInfo param = parameters[i];
            if (param.Name == paramName)
            {
                return param;
            }
        }
        return null;
    }

    public static bool ArraysEqual<T>(T[] arr1, T[] arr2)
    {
        if (ReferenceEquals(arr1, arr2))
            return true;

        if (arr1 == null || arr2 == null)
            return false;

        if (arr1.Length != arr2.Length)
            return false;

        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        for (int i = 0; i < arr1.Length; i++)
        {
            if (!comparer.Equals(arr1[i], arr2[i])) return false;
        }
        return true;
    }

    public static string ArraysToString<T>(T[] arr)
    {
        string retVal = "[";

        for (int i = 0; i < arr.Length; i++)
        {
            if (retVal != "[")
            {
                retVal += ", ";
            }
            retVal += arr[i];

        }

        retVal += "]";
        return typeof(T).ToString() + retVal;
    }
}
