using NFluent;
using PovSharp.Core;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Values
{
    public class ColorTests
    {
        [Fact]
        public void TestPovColor()
        {
            var c = new PovColor();
            Check.That(c.Name).IsNull();
            Check.That(c.Red).IsEqualTo(0);
            Check.That(c.Green).IsEqualTo(0);
            Check.That(c.Blue).IsEqualTo(0);
        }
        [Fact]
        public void TestPovColor2()
        {
            var c = new PovColor("myColor", 0, 1, 2);
            Check.That(c.Name).IsEqualTo("myColor");
            Check.That(c.Red).IsEqualTo(0);
            Check.That(c.Green).IsEqualTo(1);
            Check.That(c.Blue).IsEqualTo(2);

        }
        [Fact]
        public void TestPovColor3()
        {
            var red = new PovNumber("myRedComp", 0);
            var c = new PovColor("myColor") { Red = red, Green = 1.0 / 2, Blue = 1.0 / 4 };
            Check.That(c.Name).IsEqualTo("myColor");
            Check.That(c.Red).IsEqualTo(0);
            Check.That(c.Green).IsEqualTo(0.5);
            Check.That(c.Blue).IsEqualTo(0.25);
        }
        [Fact]
        public void TestPovColor4()
        {
            var rgb = new PovVector("rgb", 0.1, 0.2, 0.3);
            var c = new PovColor("myColor", rgb);
            Check.That(c.Name).IsEqualTo("myColor");
            Check.That(c.Red).IsEqualTo(0.1);
            Check.That(c.Green).IsEqualTo(0.2);
            Check.That(c.Blue).IsEqualTo(0.3);
        }

        [Fact]
        public void TestPovCode1()
        {
            var c = new PovColor();
            Check.That(c.ToPovCode()).IsEqualTo("rgb < 0, 0, 0>");
        }
        [Fact]
        public void TestPovCode2()
        {
            var c = new PovColor() {Red = 1, Green = 0, Blue = 0};
            Check.That(c.ToPovCode()).IsEqualTo("rgb < 1, 0, 0>");
        }
        [Fact]
        public void TestPovCode3()
        {
            var c = new PovColor(1, 1, 0);
            Check.That(c.ToPovCode()).IsEqualTo("rgb < 1, 1, 0>");
        }
        [Fact]
        public void TestPovCode4()
        {
            var c = new PovColor("Black");
            Check.That(c.ToPovCode()).IsEqualTo("rgb < 0, 0, 0>");
        }
        [Fact]
        public void TestPovCode5()
        {
            var c = new PovColor("White");
            var dec = new DeclareElement("myColor", c);
            Check.That(dec.ToPovCode()).IsEqualTo("#declare myColor = White;");
        }
    }
}