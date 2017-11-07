using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class OvusTests
    {
        [Fact]
        public void TestBasic()
        {
            var ovus = new Ovus();
            Check.That(ovus.Type).IsEqualTo("ovus");
            Check.That(ovus.BottomRadius).IsEqualTo(1);
            Check.That(ovus.TopRadius).IsEqualTo(0.5);
        }

        [Fact]
        public void TestConstructor()
        {
            var ovus = new Ovus("MyOvus") { BottomRadius = 5, TopRadius = 3};
            Check.That(ovus.Type).IsEqualTo("ovus");
            Check.That(ovus.Name).IsEqualTo("MyOvus");
            Check.That(ovus.BottomRadius).IsEqualTo(5);
            Check.That(ovus.TopRadius).IsEqualTo(3);
        }

        [Fact]
        public void TestOvusToPovCode()
        {
            var ovus = new Ovus("MyOvus") { BottomRadius = 5, TopRadius = 3};
            var povCode = ovus.ToPovCode();
            Check.That(povCode).IsEqualTo("ovus {\n 5, 3\n}");
        }
    }
}