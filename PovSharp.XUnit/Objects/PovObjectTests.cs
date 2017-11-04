using NFluent;
using PovSharp.Objects;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Objects
{
    public class PovObjectTests
    {
        [Fact]
         public void PovObjectTest()
         {
             var sphere = new Sphere();
             var povObj = new PovObject(sphere);
             string povCode = povObj.ToPovCode();
             Check.That(povCode).IsEqualTo("object {\n sphere {\n <0, 0, 0>, 1\n}\n}");
         }
         [Fact]
         public void PovObjectWithNameTest()
         {
             var sphere = new Sphere("MySphere");
             var povObj = new PovObject(sphere);
             string povCode = povObj.ToPovCode();
             Check.That(povCode).IsEqualTo("object {\n MySphere\n}");
         }
   }
}