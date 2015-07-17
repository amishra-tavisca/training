using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Tavisca.Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClass : System.Attribute
    {
        public TestClass()
        {

        }

        public static bool Exists(Type type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestClass)
                {
                    return true;
                }
            }
            return false;
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true)]
    public class TestMethod : System.Attribute
    {
        public TestMethod()
        {

        }
        public static bool Exists(MethodInfo type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestMethod)
                {
                    return true;
                }
            }
            return false;
        }
    }


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true)]
    public class Ignore : System.Attribute
    {
        public Ignore()
        {

        }
        public static bool Exists(MethodInfo type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is Ignore)
                {
                    return true;
                }
            }
            return false;
        }

    }


    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = true)]
    public class TestCategory : System.Attribute
    {
        static private string _category;

        public TestCategory(string category)
        {
            _category = category;
        }
        public static string Category
        {
            get
            {
                return _category;
            }
        }
        public static bool Exists(MethodInfo type,string category)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is TestCategory)
                {
                    if(category.Equals(Category))
                    return true;
                }
            }
            return false;
        }


    }
}
