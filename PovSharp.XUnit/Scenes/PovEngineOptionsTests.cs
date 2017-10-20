using System;
using NFluent;
using PovSharp.Core;
using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class PovEngineOptionsTests
    {
        [Fact]
        public void DefaultValuesTest() 
        {
            PovEngineOptions options = new PovEngineOptions();
            var args = options.GetPovArgs();
            Check.That(options.Width).IsEqualTo(1280);
            Check.That(options.Height).IsEqualTo(1024);
            Check.That(args).IsEmpty();
        }
        [Fact]
        public void PovArgsTest() 
        {
            PovEngineOptions options = new PovEngineOptions() {Height=480, Width=640, PreviewStartSize=32, PreviewEndSize=16};
            var args = options.GetPovArgs();
            Check.That(options.Width).IsEqualTo(640);
            Check.That(options.Height).IsEqualTo(480);
            Check.That(options.PreviewStartSize).IsEqualTo(32);
            Check.That(options.PreviewEndSize).IsEqualTo(16);
            Check.That(args.Length).IsEqualTo(3);
            Check.That(args).Contains("Height=480", "Width=640", "Preview_End_Size=16");
        }
    }
}