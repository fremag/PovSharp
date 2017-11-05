using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class BlobTests
    {
        [Fact]
        public void TestBasic()
        {
            var blob = new Blob();
            Check.That(blob.Type).IsEqualTo("blob");
            Check.That(blob.Hierarchy).IsNull();
            Check.That(blob.Sturm).IsNull();
            Check.That(blob.Threshold).IsNull();
        }

        [Fact]
        public void TestConstructor()
        {
            var blob = new Blob("myBlob") { Threshold = 1, Sturm = true, Hierarchy = false };
            Check.That(blob.Name).IsEqualTo("myBlob");
            Check.That(blob.Type).IsEqualTo("blob");
            Check.That(blob.Threshold).IsEqualTo(1);
            Check.That(blob.Hierarchy).IsEqualTo(false);
            Check.That(blob.Sturm).IsEqualTo(true);
        }

        [Fact]
        public void TestToPovCode()
        {
            var blob = new Blob("myBlob") { Threshold = 1, Sturm = true, Hierarchy = false };
            blob.AddSphere(new PovVector(1, 0, 0), 1, 2);
            blob.AddCylinder(new PovVector(1, 0, 0), new PovVector(0, 1, 0), 1, 2);
            var povCode = blob.ToPovCode();
            Check.That(povCode).IsEqualTo("blob {\n threshold 1\n sphere {\n < 1, 0, 0>, 1, strength 2}\ncylinder {\n < 1, 0, 0>, < 0, 1, 0>, 1, strength 2}\n}");
        }
        [Fact]
        public void TestToPovCodeWithName()
        {
            var center1 = new PovVector("c1", 1, 1, 1);
            var center2 = new PovVector("c2", -1, -1, -1);
            var threshold = new PovNumber("MyThreshold", 1);
            var strength = new PovNumber("MyStrength", 2);
            var blob = new Blob("myBlob") { Threshold = threshold};
            blob.AddSphere(center1, 1, strength);
            blob.AddCylinder(center2, new PovVector(0, 1, 0), 1, 2);
            var povCode = blob.ToPovCode();
            Check.That(povCode).IsEqualTo("blob {\n threshold MyThreshold\n sphere {\n c1, 1, strength MyStrength}\ncylinder {\n c2, < 0, 1, 0>, 1, strength 2}\n}");
        }
    }
}