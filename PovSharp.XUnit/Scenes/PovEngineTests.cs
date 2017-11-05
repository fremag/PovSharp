using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class PovEngineTests : AbstractPovEngineTests
    {
        public PovEngineTests()
        {
            var sphere = new Sphere();
            sphere.AddModifiers(new Pigment() {Color = new PovColor(0, 0, 1)});
            scene.Declare("MySphere", sphere);
            scene.Add(sphere);
        }

        [Fact(Skip="true")]
        public void BasicSceneTest() 
        {
            scene.Name = "TestBlueSphere";
            var path = engine.Render(scene, options, false);
        }
    }
}