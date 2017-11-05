using NFluent;
using PovSharp.Core;
using PovSharp.Scenes;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class CameraTests
    {
        [Fact]
        public void TestCamera1()
        {
            Camera cam = new Camera();
            Check.That(cam.Name).IsNull();
            Check.That(cam.Location).IsNull();
            Check.That(cam.Right).IsNull();
            Check.That(cam.Up).IsNull();
            Check.That(cam.Direction).IsNull();
            Check.That(cam.Sky).IsNull();
            Check.That(cam.LookAt).IsNull();
        }

        [Fact]
        public void TestCamera2()
        {
            PovVector v0 = new PovVector(0);
            PovVector v1 = new PovVector(1);
            
            Camera cam = new Camera("myCam") {Location=v1, LookAt=v0};
            Check.That(cam.Name).IsEqualTo("myCam");
            Check.That(cam.Location).IsEqualTo(v1);
            Check.That(cam.LookAt).IsEqualTo(v0);
        }

        [Fact]
        public void TestPovCodeCamera()
        {
            PovVector v0 = new PovVector("myLocation");
            PovVector v1 = new PovVector(0);
            
            var cam = new Camera("myCam") {Location=v0, LookAt=v1};
            var povCode = cam.ToPovCode();
            Check.That(povCode).IsEqualTo("camera {\n location myLocation\n look_at < 0, 0, 0>\n}");
        }

        [Fact]
        public void TestPovDeclareCamera()
        {
            PovVector v0 = new PovVector("myLocation");
            PovVector v1 = new PovVector(0);
            
            var cam = new Camera {Location=v0, LookAt=v1};
            var decl = new DeclareElement("myCam", cam, ";"); 
            var povCode = decl.ToPovCode();
            Check.That(povCode).IsEqualTo("#declare myCam = camera {\n location myLocation\n look_at < 0, 0, 0>\n};");
        }
    }
}