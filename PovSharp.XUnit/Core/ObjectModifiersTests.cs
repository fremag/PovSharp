using NFluent;
using PovSharp.Objects;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Core
{
    public class ObjectModifiersTests
    {
        [Fact]
        public void TestSphereWithPigment()
        {
            var sphere = new Sphere();
            var whiteCol = new PovColor(1, 1, 1);
            var pigment = new Pigment(whiteCol);

            sphere.AddModifiers(pigment);
            var povCode = sphere.ToPovCode();
            Check.That(povCode).IsEqualTo("sphere {\n < 0, 0, 0>, 1\n\npigment {\n color rgb < 1, 1, 1>\n}}");
        }
        
        [Fact]
        public void TestBoxWithPigment()
        {
            var box = new Box();
            var whiteCol = new PovColor(1, 1, 1);
            var pigment = new Pigment(whiteCol);

            box.AddModifiers(pigment);
            var povCode = box.ToPovCode();
            Check.That(povCode).IsEqualTo("box {\n < 0, 0, 0>, < 1, 1, 1>\n\npigment {\n color rgb < 1, 1, 1>\n}}");
        }
    }
}