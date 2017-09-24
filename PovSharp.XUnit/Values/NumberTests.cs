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

        [Fact]
        public void TestEqualsOperator1()
        {
            PovNumber n1 = 5;
            PovNumber n2 = 5;
            Check.That(n1 == n2).IsTrue();
        }
        
        [Fact]
        public void TestEqualsOperator2()
        {
            PovNumber n1 = 5;
            PovNumber n2 = 4;
            Check.That(n1 == n2).IsFalse();
        }
        [Fact]
        public void TestEqualsOperatorWithDouble1()
        {
            PovNumber n1 = 5;
            Check.That(n1 == 5).IsTrue();
        }
        [Fact]
        public void TestEqualsOperatorWithDouble2()
        {
            PovNumber n1 = null;
            Check.That(n1 == 5).IsFalse();
        }
        [Fact]
        public void TestEqualsOperatorWithNullValues()
        {
            PovNumber n1 = 5;
            PovNumber n2 = null;
            Check.That(n1 == null).IsFalse();
            Check.That(n1 == n2).IsFalse();
            Check.That(null == n1).IsFalse();
            Check.That(n2 == n1).IsFalse();
            Check.That(n2 == null).IsTrue();
            Check.That(null == n2).IsTrue();
        }
        
        [Fact]
        public void TestNotEqualsOperator1()
        {
            PovNumber n1 = 5;
            PovNumber n2 = 5;
            Check.That(n1 != n2).IsFalse();
        }
        
        [Fact]
        public void TestNotEqualsOperator2()
        {
            PovNumber n1 = 5;
            PovNumber n2 = 4;
            Check.That(n1 != n2).IsTrue();
        }
    }
}
