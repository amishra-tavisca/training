using System;
using Tavisca.Attributes;

namespace Tavisca.TestFixture
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [Ignore]
        [TestMethod]
        public void TestMethod2()
        {
        }

        [TestMethod]
        public void TestMethod3()
        {
        }

        [TestCategory("shape")]
        [TestMethod]
        
        public void TestMethod4()
        {
        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestMethod2()
        {
        }

        [TestCategory("size")]
        [TestMethod]
        public void TestMethod3()
        {
        }

        [TestMethod]
        public void TestMethod4()
        {
        }
    }

   
    public class UnitTest3
    {
        [Ignore]
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestCategory("size")]
        [TestMethod]
        public void TestMethod2()
        {
        }

       
        public void TestMethod3()
        {
        }

        [TestCategory("shape")]
        [TestMethod]
        public void TestMethod4()
        {
        }
    }

    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestMethod2()
        {
        }

        [TestMethod]
        public void TestMethod3()
        {
        }

        [TestMethod]
        [TestCategory("shape")]
        public void TestMethod4()
        {
        }
    }
}
