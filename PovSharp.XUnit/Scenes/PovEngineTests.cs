using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Transformations;
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
        [Fact(Skip="true")]
        public void DemoSceneTest() 
        {
            scene.Name = "TestDemo";
            var cone = new Cone();
            cone.AddModifiers(new Pigment() {Color = new PovColor(0, 1, 1)});
            cone.AddModifiers(new Translation(2,0,0));
            scene.Add(cone);


            var cylinder = new Cylinder();
            cylinder.AddModifiers(new Pigment() {Color = new PovColor(1, 0, 1)});
            cylinder.AddModifiers(new Translation(-2,0,0));
            scene.Add(cylinder);

            var path = engine.Render(scene, options, false);
        }
    }
}