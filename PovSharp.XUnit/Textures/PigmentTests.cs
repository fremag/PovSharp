using NFluent;
using PovSharp.Core;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Textures
{
    public class PigmentTests
    {
        [Fact]
        public void TestPigment()
        {
            var pigment = new Pigment();
            Check.That(pigment.Name).IsNull();
            var c = new PovColor(0, 0, 0);
            Check.That(pigment.Color).IsEqualTo(c);
        }

        [Fact]
        public void TestPigment2()
        {
            var c = new PovColor("White", 1, 1, 1);
            var pigment = new Pigment("myPigment", c);
            Check.That(pigment.Name).IsEqualTo("myPigment");
            Check.That(pigment.Color).IsEqualTo(c);
        }
        [Fact]
        public void TestPigmentPovCode()
        {
            var c = new PovColor("White", 1, 1, 1);
            var pigment = new Pigment("myPigment", c);
            var povCode = pigment.ToPovCode();
            Check.That(povCode).IsEqualTo("pigment {\n color White\n}");
        }
        [Fact]
        public void TestDeclarePigmentPovCode()
        {
            var c = new PovColor("White", 1, 1, 1);
            var pigment = new Pigment(c);
            var dec = new DeclareElement("myPigment", pigment); 
            var povCode = dec.ToPovCode();
            Check.That(povCode).IsEqualTo("#declare myPigment = pigment {\n color White\n};");
        }

    }
}