using System;
using System.Drawing;
using PovSharp.Demos.Droid;
using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;

namespace PovSharp.Demos
{
    class Program : PovValueHelpers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello New World!");
            PovScene scene = new PovScene() { Name = "Droid" };

            PovEngine engine = new PovEngine(@"c:\Program Files\POV-Ray\v3.7\bin\pvengine64.exe", @"e:\tmp");
            PovEngineOptions options = new PovEngineOptions() { Height = 480, Width = 640, PreviewStartSize = 32, PreviewEndSize = 16, PauseWhenDone = true };

            var mainPigment = new Pigment(_White);
            var decoPigmentMinor = new Pigment(_Gray20);
            var decoPigmentMajor = new Pigment(_Orange);

            var droid = new DroidObject(mainPigment, decoPigmentMajor, decoPigmentMinor);
            droid.AddModifiers(new Pigment(new PovColor(1, 0, 0)));

            scene.Add(new Camera() { Location = _V(0, 0.20, 2), LookAt = new PovVector(0, 0.25, 0) })
            .Add(new Light())
            .Add(new Plane().AddModifiers(new Pigment(_Green)))
            .Add(new Sphere() { Center = _V(0, droid.Head.Heigth+0.1,0), Radius=0.1 }.AddModifiers(new Pigment(_Blue)))
;
            scene.Add(droid);
            var path = engine.Render(scene, options, false);
        }
    }
}
