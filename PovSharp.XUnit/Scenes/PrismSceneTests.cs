using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Transformations;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class PrismSceneTests : AbstractPovEngineTests
    {
        public PrismSceneTests()
        {
            var prism = new Prism()
            {
                Height1 = 2,
                Height2 = 3
            };
            prism.Add(0, 0).Add(6, 0).Add(6, 8).Add(0, 8).Add(0, 0)  //outer rim
                .Add(1, 1).Add(5, 1).Add(5, 7).Add(1, 7).Add(1, 1);   //inner rim    
            prism.AddModifiers(new Pigment() { Color = new PovColor(0, 0, 1) });
            prism.AddModifiers(new Scale(new PovVector(0.5, 1, 0.5)));
            scene.Add(prism);

            var plane = new Plane();
            plane.AddModifiers(new Pigment() { Color = new PovColor(1, 0, 0) });
            scene.Add(plane);
        }

        [Fact(Skip="true")]
        public void BasicSceneTest()
        {
            scene.Name = "TestPrism";
            var path = engine.Render(scene, options, false);
        }
    }
}