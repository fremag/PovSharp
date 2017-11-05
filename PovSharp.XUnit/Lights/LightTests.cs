using NFluent;
using PovSharp.Core;
using PovSharp.Lights;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Lights
{
    public class LightTests
    {
        [Fact]
        public void TestLight1()
        {
            var light = new Light();
            Check.That(light.Name).IsNull();
            Check.That(light.Location).IsEqualTo(new PovVector(5));
            Check.That(light.Color).IsEqualTo(new PovColor(1));
        }
        [Fact]
        public void TestPovCodeLight()
        {
            PovVector v0 = new PovVector("myLocation");

            var light = new Light("myLight") { Location = v0, Color = new PovColor(1) };
            var povCode = light.ToPovCode();
            Check.That(povCode).IsEqualTo("light_source {\n myLocation, rgb < 1, 1, 1>\n}");
        }
        [Fact]
        public void TestDeclareLight()
        {
            PovVector v0 = new PovVector("myLocation");

            var light = new Light() { Location = v0, Color = new PovColor(1) };
            var decl = new DeclareElement("myLight", light);
            var povCode = decl.ToPovCode();
            Check.That(povCode).IsEqualTo("#declare myLight = light_source {\n myLocation, rgb < 1, 1, 1>\n};");
        }
    }
}