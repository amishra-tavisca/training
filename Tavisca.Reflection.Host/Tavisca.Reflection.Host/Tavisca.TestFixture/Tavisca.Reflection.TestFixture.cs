using System;
using Tavisca.Reflection.Attributes;

namespace Tavisca.Reflection.TestFixture
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
        public void TestMethod5()
        {
        }

        [TestMethod]
        public void TestMethod6()
        {
        }

        [TestCategory("size")]
        [TestMethod]
        public void TestMethod7()
        {
        }

        [TestMethod]
        public void TestMethod8()
        {
        }
    }


    public class UnitTest3
    {
        [Ignore]
        [TestMethod]
        public void TestMethod9()
        {
        }

        [TestCategory("size")]
        [TestMethod]
        public void TestMethod10()
        {
        }


        public void TestMethod11()
        {
        }

        [TestCategory("shape")]
        [TestMethod]
        public void TestMethod12()
        {
        }
    }

    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod13()
        {
        }

        [TestMethod]
        public void TestMethod14()
        {
        }

        [TestMethod]
        public void TestMethod15()
        {
        }

        [TestMethod]
        [TestCategory("shape")]
        public void TestMethod16()
        {
        }
    }
}
