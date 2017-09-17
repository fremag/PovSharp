using Microsoft.VisualStudio.TestTools.UnitTesting;
using PovSharp.Values;

namespace PovSharp.tests.Values
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void TestName()
        {
            var n = new PovVector("x");
            Assert.AreEqual(n.Name, "x");
        }

        [TestMethod]
        public void TestConstructor1()
        {
            var v = new PovVector(5);
            Assert.IsNull(v.Name);
            Assert.AreEqual(v.X, 5);
            Assert.AreEqual(v.Y, 5);
            Assert.AreEqual(v.Z, 5);
        }
        [TestMethod]
        public void TestConstructor2()
        {
            var n = new PovVector("v", 5);
            Assert.AreEqual(n.Name, "v");
            Assert.AreEqual(n.X, 5);
            Assert.AreEqual(n.Y, 5);
            Assert.AreEqual(n.Z, 5);
        }
        [TestMethod]
        public void TestConstructor3()
        {
            var n = new PovVector("v", 1, 2, 3);
            Assert.AreEqual(n.Name, "v");
            Assert.AreEqual(n.X, 1);
            Assert.AreEqual(n.Y, 2);
            Assert.AreEqual(n.Z, 3);
        }

        [TestMethod]
        public void TestConstructor4()
        {
            var v = new PovVector(1, 2, 3);
            Assert.IsNull(v.Name);
            Assert.AreEqual(v.X, 1);
            Assert.AreEqual(v.Y, 2);
            Assert.AreEqual(v.Z, 3);
        }

        [TestMethod]
        public void TestConstructor5()
        {
            var v = new PovVector() {X = new PovNumber("myNum", 1), Y = 2, Z = 0};
            Assert.IsNull(v.Name);
            Assert.AreEqual(v.X, 1);
            Assert.AreEqual(v.Y, 2);
            Assert.AreEqual(v.Z, 0);
        }
    }
}
