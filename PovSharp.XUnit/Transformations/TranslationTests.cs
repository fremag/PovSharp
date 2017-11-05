using NFluent;
using PovSharp.Transformations;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Transformations
{
    public class TranslationTests
    {
        [Fact]
        public void TestTranslation()
        {
            var translation = new Translation(new PovVector(45, 90, 180));
            Check.That(translation.Name).IsNull();
            Check.That(translation.Vector).IsNotNull();
            Check.That(translation.Vector.X).IsEqualTo(45);
            Check.That(translation.Vector.Y).IsEqualTo(90);
            Check.That(translation.Vector.Z).IsEqualTo(180);
        }
        [Fact]
        public void TestTranslationPovCode()
        {
            var Translation = new Translation(new PovVector(45, 90, 180));
            var povCode = Translation.ToPovCode();
            Check.That( povCode).IsEqualTo("translate < 45, 90, 180>\n");
        }
        [Fact]
        public void TestTranslationPovCode2()
        {
            var Translation = new Translation(new PovVector("myTranslationVector", 45, 90, 180));
            var povCode = Translation.ToPovCode();
            Check.That( povCode).IsEqualTo("translate myTranslationVector\n");
        }
        [Fact]
        public void TestTranslationPovCode3()
        {
            var Translation = new Translation(new PovVector{X = new PovNumber("myNumber", 45), Y= 90, Z=180});
            var povCode = Translation.ToPovCode();
            Check.That( povCode).IsEqualTo("translate < myNumber, 90, 180>\n");
        }
    }
}