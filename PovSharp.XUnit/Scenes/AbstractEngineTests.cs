using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;


namespace PovSharp.XUnit.Scenes
{
    public abstract class AbstractPovEngineTests : PovValueHelpers
    {
        protected PovScene scene;
        protected PovEngine engine = new PovEngine(@"c:\Program Files\POV-Ray\v3.7\bin\pvengine64.exe", @"e:\tmp");
        protected PovEngineOptions options = new PovEngineOptions() { Height = 480, Width = 640, PreviewStartSize = 32, PreviewEndSize = 16, PauseWhenDone = true };

        public AbstractPovEngineTests()
        {
            scene = new PovScene();
            scene.Add(element: new Camera() { Location = new PovVector(7), LookAt = new PovVector(0) });
            scene.Add(new Light());
        }
    }
}