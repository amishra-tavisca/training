using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Attributes;
using Tavisca.Reflection;
using System.IO;
using System.Reflection;

namespace Tavisca.Reflection.Host
{
    class Reflection
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(args[0]);
            var category = args[1];

            var ignoreMethods = new List<string>();
            var executableMethods = new List<string>();
           
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass && TestClass.Exists())
                {
                    foreach (MethodInfo method in (type.GetMethods()))
                    {
                        if (TestMethod.Exists())
                        {
                            if (Ignore.Exists())
                                ignoreMethods.Add(method.Name);
                            else if (string.IsNullOrEmpty(category) || TestCategory.Exists(category))
                                executableMethods.Add(method.Name);
                        }
                    }
                }
            }

            Console.WriteLine("Methods to be ignored : ");
            foreach (string string1 in ignoreMethods)
            {
                Console.WriteLine(string1);
            }

            Console.WriteLine("Methods to be executableMethods : ");
            foreach (string string1 in ignoreMethods)
            {
                Console.WriteLine(string1);
            }

        }
    }
}
