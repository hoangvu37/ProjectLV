using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LV.Common
{
    public class DynamicAssembly
    {
        public static object RunFunction(Type type, string methodName, object[] parameterForTheMethod)
        {
            object returnObject = null;
            MethodInfo mi = null;
            //ConstructorInfo ci = null;
            object responder = null;
            System.Type[] objectTypes;
            int count = 0;
            //ci = type.GetConstructor(Type.EmptyTypes);
            if (parameterForTheMethod != null)
            {
                objectTypes = new System.Type[parameterForTheMethod.GetUpperBound(0) + 1];
                foreach (object objectParameter in parameterForTheMethod)
                {
                    if (objectParameter != null)
                        objectTypes[count] = objectParameter.GetType();
                    count++;
                }

                //Get the reference of the method
                mi = type.GetMethod(methodName, objectTypes);
            }
            else
                mi = type.GetMethod(methodName);

            //responder = ci.Invoke(null);

            if (parameterForTheMethod != null)
                returnObject = mi.Invoke(responder, parameterForTheMethod);
            else
                returnObject = responder;

            return returnObject;
        }

        public static object Process(string AssemblyPath, string AssemblyName, string className, string methodName, object[] parameterForTheMethod)
        {
            return Process(AssemblyPath,AssemblyName, className, methodName, parameterForTheMethod, null);
        }

        public static object Process(string AssemblyPath, string AssemblyName, string className, string methodName, object[] parameterForTheMethod, params Type[] oGenericType)
        {
            object returnObject = null;
            MethodInfo mi = null;
            ConstructorInfo ci = null;
            object responder = null;
            Type type = null;
            System.Type[] objectTypes;
            int count = 0;
            try
            {
                //Load the assembly and get it's information
                type = System.Reflection.Assembly.LoadFrom(AssemblyPath+AssemblyName + ".dll").GetType(AssemblyName + "." + className);

                if (oGenericType == null)
                    ci = type.GetConstructor(Type.EmptyTypes);
                else
                    ci = type.GetConstructor(oGenericType);

                //Get the Passed parameter types to find the method type
                if (parameterForTheMethod != null)
                {
                    objectTypes = new System.Type[parameterForTheMethod.GetUpperBound(0) + 1];
                    foreach (object objectParameter in parameterForTheMethod)
                    {
                        if (objectParameter != null)
                            objectTypes[count] = objectParameter.GetType();
                        count++;
                    }

                    //Get the reference of the method
                    mi = type.GetMethod(methodName, objectTypes);
                }
                else
                    mi = type.GetMethod(methodName);
                if (ci != null)
                    responder = ci.Invoke(null);

                if (parameterForTheMethod != null)
                    returnObject = mi.Invoke(responder, parameterForTheMethod);
                else
                    returnObject = responder;
            }
            catch 
            { }
            finally
            {
                mi = null;
                ci = null;
                responder = null;
                type = null;
                objectTypes = null;
            }

            //Return the value as a generic object
            return returnObject;

        }

        public static object InvokeGenericMethodWithTargetType(Type oGenericType, Type oTargetType, string sMethodName, params object[] oParamList)
        {
            List<Type> paramaterType = new List<Type>();
            foreach (var item in oParamList)
            {
                paramaterType.Add(item.GetType());
            }

            MethodInfo method = oTargetType.GetMethod(sMethodName, paramaterType.ToArray());
            MethodInfo mg = method.MakeGenericMethod(oGenericType);
            object oTargetObj = null;
            if (!mg.IsStatic)
                oTargetObj = Activator.CreateInstance(oTargetType);
            return mg.Invoke(oTargetObj, oParamList);
        }

        public static object InvokeGenericMethod(Type oGenericType, object oTargetObj, string sMethodName, params object[] oParamList)
        {
            Type oTargetType = oTargetObj.GetType();
            MethodInfo method = oTargetType.GetMethod(sMethodName);
            MethodInfo mg = method.MakeGenericMethod(oGenericType);
            return mg.Invoke(oTargetObj, oParamList);
        }

        /// <summary>
        /// Gọi phương thức Generic bất đồng bộ. Lưu ý phương thức Generic phải trả về dạng Task &lt;object[]&gt;
        /// </summary>
        /// <param name="oGenericType">Kiểu Generic</param>
        /// <param name="oTargetObj">Đối tượng</param>
        /// <param name="sMethodName">Tên phương thức</param>
        /// <param name="oParamList">Danh sách tham số</param>
        /// <returns></returns>
        public static async Task<object> InvokeGenericMethodAsync(Type oGenericType, object oTargetObj, string sMethodName, params object[] oParamList)
        {
            Type oTargetType = oTargetObj.GetType();
            MethodInfo method = oTargetType.GetMethod(sMethodName);
            MethodInfo mg = method.MakeGenericMethod(oGenericType);
            var task = (Task<object[]>)mg.Invoke(oTargetObj, oParamList) ;
            var obj = await task;
            return obj;
        }

        public static async Task<object> InvokeGenericMethodObjAsync(Type oGenericType, object oTargetObj, string sMethodName, params object[] oParamList)
        {
            Type oTargetType = oTargetObj.GetType();
            MethodInfo method = oTargetType.GetMethod(sMethodName);
            MethodInfo mg = method.MakeGenericMethod(oGenericType);
            var task = (Task<object>)mg.Invoke(oTargetObj, oParamList);
            var obj = await task;
            return obj;
        }

       
        public static object InvokeGenericMethodWithTypes(Type oGenericType, object oTargetObj, string sMethodName, Type[] oParamType, params object[] oParamList)
        {
            Type oTargetType = oTargetObj.GetType();
            MethodInfo method = oTargetType.GetMethod(sMethodName, oParamType);
            MethodInfo mg = method.MakeGenericMethod(oGenericType);
            return mg.Invoke(oTargetObj, oParamList);
        }

        public static object InvokeGenericMethodOverLoaded(Type oGenericType, object oTargetObj, string sMethodName, params dynamic[] oParamList)
        {
            Type oTargetType = oTargetObj.GetType();
            List<MethodInfo> methods = oTargetType.GetMethods().Where(x => x.Name == sMethodName).ToList();
            MethodInfo method = null;
            if (oGenericType == null)
            {
                if (oParamList == null || oParamList.Count() == 0)
                    method = methods.Where(x => !x.IsGenericMethod && x.GetParameters().Count() == 0).First();
                else
                {
                    return oTargetObj.GetType().InvokeMember(
                             sMethodName,
                             BindingFlags.InvokeMethod | BindingFlags.Public |
                                 BindingFlags.Static,
                             null,
                             oTargetObj,
                            oParamList);
                 //   method = methods.Where(x => !x.IsGenericMethod && x.GetParameters().SequenceEqual(oParamList)).First();
                }
                return method.Invoke(oTargetObj, oParamList);
            }
            else
            {
                if (oParamList == null || oParamList.Count() == 0)
                    method = methods.Where(x => x.IsGenericMethod && x.GetParameters().Count() == 0).First();
                else
                    method = methods.Where(x => x.IsGenericMethod && x.GetParameters().SequenceEqual(oParamList)).First();
            }

            MethodInfo mg = method.MakeGenericMethod(oGenericType);
            return mg.Invoke(oTargetObj, oParamList);
        }
    }
}
