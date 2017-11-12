using System;
using PovSharp.Demos.Droid;
using PovSharp.Lights;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;

namespace PovSharp.Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello New World!");
            PovScene scene = new PovScene() { Name = "Droid" };

            PovEngine engine = new PovEngine(@"c:\Program Files\POV-Ray\v3.7\bin\pvengine64.exe", @"e:\tmp");
            PovEngineOptions options = new PovEngineOptions() { Height = 480, Width = 640, PreviewStartSize = 32, PreviewEndSize = 16, PauseWhenDone = true };

            scene.Add(new Camera() { Location = new PovVector(7), LookAt = new PovVector(0) });
            scene.Add(new Light());

            scene.Add(new DroidObject().AddModifiers(new Pigment(new PovColor(1, 0,0))));
            var path = engine.Render(scene, options, false);
        }
    }
}
