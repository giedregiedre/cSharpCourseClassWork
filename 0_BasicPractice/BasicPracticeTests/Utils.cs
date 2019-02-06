using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasicPracticeTests
{
    static class Utils
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
    }
}
