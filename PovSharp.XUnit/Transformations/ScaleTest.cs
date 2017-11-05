using NFluent;
using PovSharp.Transformations;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Transformations
{
    public class ScaleTests
    {
        [Fact]
        public void TestScale()
        {
            var scale = new Scale(new PovVector(45, 90, 180));
            Check.That(scale.Name).IsNull();
            Check.That(scale.Vector).IsNotNull();
            Check.That(scale.Vector.X).IsEqualTo(45);
            Check.That(scale.Vector.Y).IsEqualTo(90);
            Check.That(scale.Vector.Z).IsEqualTo(180);
        }
        [Fact]
        public void TestScalePovCode()
        {
            var scale = new Scale(new PovVector(45, 90, 180));
            var povCode = scale.ToPovCode();
            Check.That(povCode).IsEqualTo("scale < 45, 90, 180>\n");
        }
        [Fact]
        public void TestScalePovCode2()
        {
            var scale = new Scale(new PovVector("myScaleVector", 45, 90, 180));
            var povCode = scale.ToPovCode();
            Check.That(povCode).IsEqualTo("scale myScaleVector\n");
        }
        [Fact]
        public void TestScalePovCode3()
        {
            var scale = new Scale(new PovVector { X = new PovNumber("myNumber", 45), Y = 90, Z = 180 });
            var povCode = scale.ToPovCode();
            Check.That(povCode).IsEqualTo("scale < myNumber, 90, 180>\n");
        }
    }
}