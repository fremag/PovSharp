using PovSharp.Values;
using Xunit;
using NFluent;

namespace PovSharp.XUnit.Values
{
    public class Point2DTests
    {
        [Fact]
        public void TestName()
        {
            var n = new Point2D("x");
            Check.That(n.Name).IsEqualTo("x");
        }

        [Fact]
        public void TestConstructor1()
        {
            var v = new Point2D(5);
            Check.That(v.Name).IsNull();
            Check.That(v.X).IsEqualTo(5);
            Check.That(v.Y).IsEqualTo(5);
        }
        [Fact]
        public void TestConstructor2()
        {
            var n = new Point2D("v", 5);
            Check.That(n.Name).IsEqualTo("v");
            Check.That(n.X).IsEqualTo(5);
            Check.That(n.Y).IsEqualTo(5);
        }
        [Fact]
        public void TestConstructor3()
        {
            var n = new Point2D("v", 1, 2);
            Check.That(n.Name).IsEqualTo("v");
            Check.That(n.X).IsEqualTo(1);
            Check.That(n.Y).IsEqualTo(2);
        }

        [Fact]
        public void TestConstructor4()
        {
            var v = new Point2D(1, 2);
            Check.That(v.Name).IsNull();
            Check.That(v.X).IsEqualTo(1);
            Check.That(v.Y).IsEqualTo(2);
        }

        [Fact]
        public void TestConstructor5()
        {
            var v = new Point2D() {X = new PovNumber("myNum", 1), Y = 2};
            Check.That(v.Name).IsNull();
            Check.That(v.X).IsEqualTo(1);
            Check.That(v.Y).IsEqualTo(2);
        }

        [Fact]
        public void TestToPovCode1()
        {
            var v = new Point2D(5);
            var povCode = v.ToPovCode();
            Check.That(povCode).IsEqualTo("< 5, 5>");
        }

        [Fact]
        public void TestToPovCode2()
        {
            var v = new Point2D(1, 2);
            var povCode = v.ToPovCode();
            Check.That(povCode).IsEqualTo("< 1, 2>");
        }

        [Fact]
        public void TestToPovCode3()
        {
            var v = new Point2D() {X = new PovNumber("myNum", 1), Y = 2};
            var povCode = v.ToPovCode();
            Check.That(povCode).IsEqualTo("< myNum, 2>");
        }

        [Fact]
        public void TestToPovCode4()
        {
            var num = new PovNumber("myNum", 1);
            var v = new Point2D() {X = num, Y = 2};
            var povCode = v.ToPovCode();
            Check.That(povCode).IsEqualTo("< myNum, 2>");
        }
    }
}
