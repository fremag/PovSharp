using NFluent;
using PovSharp.Values;
using Xunit;

namespace PovSharp.tests.Values
{
    public class NumberTests
    {
        [Fact]
        public void TestName()
        {
            var n = new PovNumber("x");
            Check.That(n.Name).IsEqualTo("x");
        }

        [Fact]
        public void TestValue()
        {
            var n = new PovNumber(5);
            Check.That(n.Name).IsNull();
            Check.That(n.Value).IsEqualTo(5);
        }

        [Fact]
        public void TestClone()
        {
            var n = new PovNumber(5);
            var m = n.Clone() as PovNumber;
            Check.That(m.Name).IsNull();
            Check.That(m.Value).IsEqualTo(5);
        }

        [Fact]
        public void TestDoubleOperator()
        {
            PovNumber n = 5;
            Check.That(n.Name).IsNull();
            Check.That(n.Value).IsEqualTo(5);
        }

        [Fact]
        public void TestPovCode()
        {
            PovNumber n = 5;
            Check.That(n.ToPovCode()).IsEqualTo("5");
            n = 5.2;
            Check.That(n.ToPovCode()).IsEqualTo("5.2");
        }

        [Fact]
        public void TestEquals()
        {
            PovNumber n = 5;
            Check.That(n).IsEqualTo(5);
        }
        
        [Fact]
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
