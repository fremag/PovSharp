using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class TorusTests
    {
        [Fact]
        public void TestBasic()
        {
            var torus = new Torus();
            Check.That(torus.Type).IsEqualTo("torus");
            Check.That(torus.MinorRadius).IsEqualTo(0.5);
            Check.That(torus.MajorRadius).IsEqualTo(1);
        }

        [Fact]
        public void TestConstructor()
        {
            var torus = new Torus("MyTorus") { MajorRadius = 5, MinorRadius = 3};
            Check.That(torus.Type).IsEqualTo("torus");
            Check.That(torus.Name).IsEqualTo("MyTorus");
            Check.That(torus.MajorRadius).IsEqualTo(5);
            Check.That(torus.MinorRadius).IsEqualTo(3);
        }

        [Fact]
        public void TestTorusToPovCode()
        {
            var torus = new Torus("MyTorus") { MajorRadius = 5, MinorRadius = 3};
            var povCode = torus.ToPovCode();
            Check.That(povCode).IsEqualTo("torus {\n 5, 3\n}");
        }
    }
}