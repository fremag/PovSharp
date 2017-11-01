using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class PovEngineTests
    {
        PovScene scene;
        PovEngine engine = new PovEngine(@"c:\Program Files\POV-Ray\v3.7\bin\pvengine64.exe", @"e:\tmp");

        public PovEngineTests()
        {
            scene = new PovScene();
            scene.Add(element: new Camera() {Location = new PovVector(7), LookAt = new PovVector(0)});
            scene.Add(new Light());
            var sphere = new Sphere();
            sphere.AddModifiers(new Pigment() {Color = new PovColor(0, 0, 1)});
            scene.Declare("MySphere", sphere);
            scene.Add(sphere);
        }

        [Fact(Skip="true")]
        public void BasicSceneTest() 
        {
            scene.Name = "Test";
            PovEngineOptions options = new PovEngineOptions() {Height=480, Width=640, PreviewStartSize=32, PreviewEndSize=16, PauseWhenDone=true};
            var path = engine.Render(scene, options);
        }
    }
}