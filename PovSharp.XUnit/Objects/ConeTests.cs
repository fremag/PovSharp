using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class ConeTests
    {
        [Fact]
        public void TestBasic()
        {
            var cone = new Cone();
            Check.That(cone.Type).IsEqualTo("cone");
            Check.That(cone.Open).IsNull();
            Check.That(cone.BasePoint).IsEqualTo(new PovVector(0));
            Check.That(cone.CapPoint).IsEqualTo(new PovVector(0, 1, 0));
            Check.That(cone.BaseRadius).IsEqualTo(1);
            Check.That(cone.CapRadius).IsEqualTo(0);
        }

        [Fact]
        public void TestConstructor()
        {
            var cone = new Cone("MyCone") { BasePoint = new PovVector(1), CapPoint = new PovVector(2), BaseRadius = 5, CapRadius = 1, Open = Cone.OpenFlag.open };
            Check.That(cone.Type).IsEqualTo("cone");
            Check.That(cone.Name).IsEqualTo("MyCone");
            Check.That(cone.BasePoint).IsEqualTo(new PovVector(1));
            Check.That(cone.CapPoint).IsEqualTo(new PovVector(2));
            Check.That(cone.BaseRadius).IsEqualTo(5);
            Check.That(cone.CapRadius).IsEqualTo(1);
            Check.That(cone.Open).IsEqualTo(Cone.OpenFlag.open);
        }

        [Fact]
        public void TestConeOpenToPovCode()
        {
            var cone = new Cone("MyCone") { BasePoint = new PovVector(1), CapPoint = new PovVector(2), BaseRadius = 5, CapRadius = 1, Open = Cone.OpenFlag.open };
            var povCode = cone.ToPovCode();
            Check.That(povCode).IsEqualTo("cone {\n < 1, 1, 1>, 5\n < 2, 2, 2>, 1\n open\n}");
        }
        [Fact]
        public void TestConeNotOpenToPovCode()
        {
            var cone = new Cone();
            var povCode = cone.ToPovCode();
            Check.That(povCode).IsEqualTo("cone {\n < 0, 0, 0>, 1\n < 0, 1, 0>, 0\n}");
        }
    }
}