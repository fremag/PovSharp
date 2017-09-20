using PovSharp.Values;
using Xunit;
using NFluent;

namespace PovSharp.tests.Values
{
    public class VectorTests
    {
        [Fact]
        public void TestName()
        {
            var n = new PovVector("x");
            Check.That(n.Name).IsEqualTo("x");
        }

        [Fact]
        public void TestConstructor1()
        {
            var v = new PovVector(5);
            Check.That(v.Name).IsNull();
            Check.That(v.X).IsEqualTo(5);
            Check.That(v.Y).IsEqualTo(5);
            Check.That(v.Z).IsEqualTo(5);
        }
        [Fact]
        public void TestConstructor2()
        {
            var n = new PovVector("v", 5);
            Check.That(n.Name).IsEqualTo("v");
            Check.That(n.X).IsEqualTo(5);
            Check.That(n.Y).IsEqualTo(5);
            Check.That(n.Z).IsEqualTo(5);
        }
        [Fact]
        public void TestConstructor3()
        {
            var n = new PovVector("v", 1, 2, 3);
            Check.That(n.Name).IsEqualTo("v");
            Check.That(n.X).IsEqualTo(1);
            Check.That(n.Y).IsEqualTo(2);
            Check.That(n.Z).IsEqualTo(3);
        }

        [Fact]
        public void TestConstructor4()
        {
            var v = new PovVector(1, 2, 3);
            Check.That(v.Name).IsNull();
            Check.That(v.X).IsEqualTo(1);
            Check.That(v.Y).IsEqualTo(2);
            Check.That(v.Z).IsEqualTo(3);
        }

        [Fact]
        public void TestConstructor5()
        {
            var v = new PovVector() {X = new PovNumber("myNum", 1), Y = 2, Z = 0};
            Check.That(v.Name).IsNull();
            Check.That(v.X).IsEqualTo(1);
            Check.That(v.Y).IsEqualTo(2);
            Check.That(v.Z).IsEqualTo(0);
        }

        [Fact]
        public void TestToPovCode1()
        {
            var v = new PovVector(5);
            var povCode = v.ToPovCode();
            Check.That(povCode).IsNotEqualTo("<5, 5, 5>");
        }

        [Fact]
        public void TestToPovCode2()
        {
            var v = new PovVector(1, 2, 3);
            var povCode = v.ToPovCode();
            Check.That(povCode).IsNotEqualTo("<1, 2, 3>");
        }

        [Fact]
        public void TestToPovCode3()
        {
            var v = new PovVector() {X = new PovNumber("myNum", 1), Y = 2, Z = 0};
            var povCode = v.ToPovCode();
            Check.That(povCode).IsNotEqualTo("<myNum, 2, 0>");
        }

        [Fact]
        public void TestToPovCode4()
        {
            var num = new PovNumber("myNum", 1);
            var v = new PovVector() {X = num, Y = 2, Z = num};
            var povCode = v.ToPovCode();
            Check.That(povCode).IsNotEqualTo("<myNum, 2, myNum>");
        }
    }
}
