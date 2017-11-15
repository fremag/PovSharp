using NFluent;
using PovSharp.Core;
using PovSharp.Lights;
using PovSharp.Objects;
using PovSharp.Scenes;
using PovSharp.Textures;
using PovSharp.Values;
using Xunit;

namespace PovSharp.XUnit.Core
{
    public class PovCommentTests
    {
        [Fact]
        public void BasicCommentTest() 
        {
            PovComment comment = new PovComment() {Text = "Some comment"};
            Check.That(comment.ToPovCode()).IsEqualTo("/* Some comment */");
        }
         [Fact]
        public void SceneWithCommentTest() 
        {
            PovComment comment1 = new PovComment() {Text = "Some comment"};
            PovComment comment2 = new PovComment() {Text = "Some comment again"};
            PovScene scene = new PovScene();
            scene.Add(comment1);
            scene.Add(new Camera() {Location = new PovVector(7), LookAt = new PovVector(0)});
            scene.Add(new Light());

            var sphere = new Sphere();
            sphere.AddModifiers(new Pigment() {Color = new PovColor(1)});
            scene.Declare("MySphere", sphere);
            scene.Add(comment2);
            scene.Add(sphere);
            string povCode = string.Join("\n", scene.ToPovCode());
            var myScene = @"#include ""colors.inc""
/* Some comment */
camera {
 location < 7, 7, 7>
 look_at < 0, 0, 0>
}
light_source {
 < 5, 5, 5>, rgb < 1, 1, 1>
}
#declare MySphere = sphere {
 < 0, 0, 0>, 1

pigment {
 color rgb < 1, 1, 1>
}
};
/* Some comment again */
MySphere";
            Check.That(povCode).IsEqualTo(myScene.Replace("\r", string.Empty));
            
        }
   }
}