using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Scenes
{
    public class BlobSceneTests : AbstractPovEngineTests
    {
        public BlobSceneTests()
        {
            var blob = new Blob();
            blob.AddModifiers(new Pigment() {Color = new PovColor(0, 0, 1)});
            scene.Add(blob);
            blob.AddSphere(_X, 1, 2);
            blob.AddSphere(_Y, 1, 2);
            blob.AddSphere(_Z, 1, 2);
        }

        [Fact(Skip="true")]
        public void BasicSceneTest() 
        {
            scene.Name = "TestBlob";
            var path = engine.Render(scene, options, false);
        }
    }
}