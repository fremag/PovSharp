using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PovSharp.Values;

namespace PovSharp.tests.Values
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod]
        public void TestName()
        {
            var n = new PovNumber("x");
            Check.That(n.Name).IsEqualTo("x");
        }

        [TestMethod]
        public void TestValue()
        {
            var n = new PovNumber(5);
            Check.That(n.Name).IsNull();
            Check.That(n.Value).IsEqualTo(5);
        }

        [TestMethod]
        public void TestClone()
        {
            var n = new PovNumber(5);
            var m = n.Clone() as PovNumber;
            Check.That(m.Name).IsNull();
            Check.That(m.Value).IsEqualTo(5);
        }

        [TestMethod]
        public void TestDoubleOperator()
        {
            PovNumber n = 5;
            Check.That(n.Name).IsNull();
            Check.That(n.Value).IsEqualTo(5);
        }

        [TestMethod]
        public void TestPovCode()
        {
            PovNumber n = 5;
            Check.That(n.ToPovCode()).IsEqualTo("5");
            n = 5.2;
            Check.That(n.ToPovCode()).IsEqualTo("5.2");
        }

        [TestMethod]
        public void TestEquals()
        {
            PovNumber n = 5;
            Check.That(n).IsEqualTo(5);
        }
        [TestMethod]
        public void TestEquals2()
        {
            PovNumber n = 5;
            Check.That(n.Equals(5.0)).IsTrue();
            Check.That(n.Equals(5)).IsTrue();
            Check.That(n.Equals(new PovNumber("test", 5))).IsTrue();
            Check.That(n.Equals(new PovNumber("test", 6))).IsFalse();
        }
    }
}
