using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using PovSharp.Values;

namespace PovSharp.tests.Values
{
#if TOTO
    [TestFixture]
    public class NumberTests
    {
        [Test]
        public void TestName()
        {
            var n = new PovNumber("x");
            Assert.That(n.Name, Is.EqualTo("x"));
        }

        [Test]
        public void TestValue()
        {
            var n = new PovNumber(5);
            Assert.That(n.Name, Is.Null);
            Assert.That(n.Value, Is.EqualTo(5));
        }

        [Test]
        public void TestClone()
        {
            var n = new PovNumber(5);
            var m = n.Clone() as PovNumber;
            Assert.That(m.Name, Is.Null);
            Assert.That(m.Value, Is.EqualTo(5));
        }

        [Test]
        public void TestDoubleOperator()
        {
            PovNumber n = 5;
            Assert.That(n.Name, Is.Null);
            Assert.That(n.Value, Is.EqualTo(5));
        }
    }
#endif

    [TestClass]
    public class NumberMSTests
    {
        [TestMethod]
        public void TestName()
        {
            var n = new PovNumber("x");
            Assert.AreEqual(n.Name, "x");
        }

        [TestMethod]
        public void TestValue()
        {
            var n = new PovNumber(5);
            Assert.IsNull(n.Name);
            Assert.AreEqual(n.Value, 5);
        }

        [TestMethod]
        public void TestClone()
        {
            var n = new PovNumber(5);
            var m = n.Clone() as PovNumber;
            Assert.IsNull(m.Name);
            Assert.AreEqual(m.Value, 5);
        }

        [TestMethod]
        public void TestDoubleOperator()
        {
            PovNumber n = 5;
            Assert.IsNull(n.Name);
            Assert.AreEqual(n.Value, 5);
        }
    }

}
