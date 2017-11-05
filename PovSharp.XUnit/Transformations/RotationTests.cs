using NFluent;
using PovSharp.Transformations;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Transformations
{
    public class RotationTests
    {
        [Fact]
        public void TestRotation()
        {
            var rotation = new Rotation(new PovVector(45, 90, 180));
            Check.That(rotation.Name).IsNull();
            Check.That(rotation.Vector).IsNotNull();
            Check.That(rotation.Vector.X).IsEqualTo(45);
            Check.That(rotation.Vector.Y).IsEqualTo(90);
            Check.That(rotation.Vector.Z).IsEqualTo(180);
        }
        [Fact]
        public void TestRotationPovCode()
        {
            var rotation = new Rotation(new PovVector(45, 90, 180));
            var povCode = rotation.ToPovCode();
            Check.That( povCode).IsEqualTo("rotate < 45, 90, 180>\n");
        }
        [Fact]
        public void TestRotationPovCode2()
        {
            var rotation = new Rotation(new PovVector("myRotationVector", 45, 90, 180));
            var povCode = rotation.ToPovCode();
            Check.That( povCode).IsEqualTo("rotate myRotationVector\n");
        }
        [Fact]
        public void TestRotationPovCode3()
        {
            var rotation = new Rotation(new PovVector{X = new PovNumber("myNumber", 45), Y= 90, Z=180});
            var povCode = rotation.ToPovCode();
            Check.That( povCode).IsEqualTo("rotate < myNumber, 90, 180>\n");
        }
    }
}