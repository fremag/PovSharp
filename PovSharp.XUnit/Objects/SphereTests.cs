using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class SphereTests
    {
        [Fact]
        public void TestBasic()
        {
            var sphere = new Sphere();
            Check.That(sphere.Type).IsEqualTo("sphere");
            Check.That(sphere.Radius).IsEqualTo(1);
            Check.That(sphere.Center).IsEqualTo(new PovVector(0));
        }
        [Fact]
        public void TestConstructor()
        {
            var sphere = new Sphere("mySphere") { Radius = 1.234, Center = new PovVector(1, 2, 3) };
            Check.That(sphere.Type).IsEqualTo("sphere");
            Check.That(sphere.Name).IsEqualTo("mySphere");
            Check.That(sphere.Radius).IsEqualTo(1.234);
            Check.That(sphere.Center).IsEqualTo(new PovVector(1, 2, 3));
        }

        [Fact]
        public void TestToPovCode()
        {
            var sphere = new Sphere("mySphere") { Radius = 1.234, Center = new PovVector(1, 2, 3) };
            var povCode = sphere.ToPovCode();
            Check.That(povCode).IsEqualTo("sphere {\n < 1, 2, 3>, 1.234\n}");
        }
        [Fact]
        public void TestToPovCodeWithName()
        {
            var radius = new PovNumber("r",  1.234);
            var center = new PovVector("center", 1, 2, 3);
            var sphere = new Sphere("mySphere") { Radius = radius, Center = center};
            var povCode = sphere.ToPovCode();
            Check.That(povCode).IsEqualTo("sphere {\n center, r\n}");
        }
    }
}