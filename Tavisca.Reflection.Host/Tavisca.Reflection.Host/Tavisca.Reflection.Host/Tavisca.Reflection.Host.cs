using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Tavisca.Reflection.Attributes;
using Tavisca.Reflection.TestFixture;

namespace Tavisca.Reflection.Host
{
    class Reflection
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(args[0]);
            Console.WriteLine("enter category ");
            var category = Console.ReadLine();
           // private int _testClass,_ignore;


            var ignoreMethods = new List<string>();
            var executableMethods = new List<string>();

            foreach (Type type in assembly.GetTypes())
            {

                Console.WriteLine(type);
                if (type.IsClass && TestClass.Exists(type))
                {
                   
                    foreach (MethodInfo method in (type.GetMethods()))
                    {
                       
                        if (TestMethod.Exists(method))
                        {

                            if (Ignore.Exists(method))
                            {
                                ignoreMethods.Add(method.Name);
                               
                            }
                            else if (string.IsNullOrEmpty(category) || TestCategory.Exists(method, category))
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
            foreach (string string1 in executableMethods)
            {
                Console.WriteLine(string1);
            }

        }
    }
}
