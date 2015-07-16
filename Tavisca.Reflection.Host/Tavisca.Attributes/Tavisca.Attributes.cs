using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tavisca.Attributes
{
      [AttributeUsage(AttributeTargets.Class)] 
        public class TestClass:System.Attribute
        {
            public TestClass()
            {
            
            }
                    
            public static bool Exists()
            {
                return (true);
            }
        }


        [AttributeUsage(AttributeTargets.Method|AttributeTargets.Constructor, AllowMultiple = true)]
        public class TestMethod : System.Attribute
        {
             public TestMethod()
            {
            
            }
            public static bool Exists()
            {
                return (true);
            }

        }


        [AttributeUsage(AttributeTargets.Method|AttributeTargets.Constructor, AllowMultiple = true)]
        public class Ignore : System.Attribute
        {
             public Ignore()
            {
            
            }
            public static bool Exists()
            {
                return (true);
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
            public static bool Exists(string category)
            {
                if (Category.Equals(category))
                    return (true);
                return (false);
            }


        }
}
