using NFluent;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Values
{
    public class NumberMathOperatorTests
    {
        PovNumber n1 = new PovNumber("one", 1);
        PovNumber n2 = new PovNumber("two", 2);
        PovNumber n3 = 3;

        [Fact]
        public void AdditionNumberNumberTest()
        {
            var n = n1 + n2;
            Check.That(n.Name).IsEqualTo("(one + two)");
            Check.That(n.Value).IsEqualTo(3);
            n = n2 + n1;
            Check.That(n.Name).IsEqualTo("(two + one)");
            Check.That(n.Value).IsEqualTo(3);
            n = n1 + n3;
            Check.That(n.Name).IsEqualTo("(one + 3)");
            Check.That(n.Value).IsEqualTo(4);
        }
        [Fact]
        public void AdditionNumberDoubleTest()
        {
            var n = n1 + 2.345;
            Check.That(n.Name).IsEqualTo("(one + 2.345)");
            Check.That(n.Value).IsEqualTo(3.345);
            n = 2.345 + n1;
            Check.That(n.Name).IsEqualTo("(2.345 + one)");
            Check.That(n.Value).IsEqualTo(3.345);
        }
        [Fact]
        public void MultiplicationNumberNumberTest()
        {
            var n = n1 * n2;
            Check.That(n.Name).IsEqualTo("(one * two)");
            Check.That(n.Value).IsEqualTo(2);
            n = n2 * n1;
            Check.That(n.Name).IsEqualTo("(two * one)");
            Check.That(n.Value).IsEqualTo(2);
            n = n1 * n3;
            Check.That(n.Name).IsEqualTo("(one * 3)");
            Check.That(n.Value).IsEqualTo(3);
        }
        [Fact]
        public void MultiplicationNumberDoubleTest()
        {
            var n = n1 * 2.345;
            Check.That(n.Name).IsEqualTo("(one * 2.345)");
            Check.That(n.Value).IsEqualTo(2.345);
            n = 2.345 * n1;
            Check.That(n.Name).IsEqualTo("(2.345 * one)");
            Check.That(n.Value).IsEqualTo(2.345);
        }
        [Fact]
        public void DivisionNumberNumberTest()
        {
            var n = n1 / n2;
            Check.That(n.Name).IsEqualTo("(one / two)");
            Check.That(n.Value).IsEqualTo(0.5);
            n = n2 / n1;
            Check.That(n.Name).IsEqualTo("(two / one)");
            Check.That(n.Value).IsEqualTo(2);
            n = n1 / n3;
            Check.That(n.Name).IsEqualTo("(one / 3)");
            Check.That(n.Value).IsEqualTo(1.0/3);
        }
        [Fact]
        public void DivisionNumberDoubleTest()
        {
            var n = n1 / 2.345;
            Check.That(n.Name).IsEqualTo("(one / 2.345)");
            Check.That(n.Value).IsEqualTo(1/2.345);
            n = 2.345 / n1;
            Check.That(n.Name).IsEqualTo("(2.345 / one)");
            Check.That(n.Value).IsEqualTo(2.345);
        }
        [Fact]
        public void SoustractionNumberNumberTest()
        {
            var n = n1 - n2;
            Check.That(n.Name).IsEqualTo("(one - two)");
            Check.That(n.Value).IsEqualTo(-1);
            n = n2 - n1;
            Check.That(n.Name).IsEqualTo("(two - one)");
            Check.That(n.Value).IsEqualTo(1);
            n = n1 - n3;
            Check.That(n.Name).IsEqualTo("(one - 3)");
            Check.That(n.Value).IsEqualTo(1.0-3);
        }
        [Fact]
        public void SoustractionNumberDoubleTest()
        {
            var n = n1 - 2.345;
            Check.That(n.Name).IsEqualTo("(one - 2.345)");
            Check.That(n.Value).IsEqualTo(1-2.345);
            n = 2.345 - n1;
            Check.That(n.Name).IsEqualTo("(2.345 - one)");
            Check.That(n.Value).IsEqualTo(2.345-1);
        }
        [Fact]
        public void MinusNumberTest()
        {
            var n = -n1;
            Check.That(n.Name).IsEqualTo("-one");
            Check.That(n.Value).IsEqualTo(-1);
            n =  -n3;
            Check.That(n.Name).IsEqualTo("-3");
            Check.That(n.Value).IsEqualTo(-3);
        }
    }
}
