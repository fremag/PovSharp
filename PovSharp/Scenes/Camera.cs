using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Scenes
{
    public class Camera : AbstractPovObject
    {
        public Camera() : this (null)
        {}

        public Camera(string name) : base(name)
        {}

        public override string Type => "camera";

        [PovField(0, Before = "location", After = "\n")]
        public PovVector Location { get; set; } = null; // default is null so we use Pov default value

        [PovField(1, Before = "right", After = "\n")]
        public PovVector Right { get; set; } = null;
        
        [PovField(2, Before = "up", After = "\n")]
        public PovVector Up { get; set; } = null;
        
        [PovField(3, Before = "direction", After = "\n")]
        public PovVector Direction { get; set; } = null;
        
        [PovField(4, Before = "sky", After = "\n")]
        public PovVector Sky { get; set; } = null;

        [PovField(5, Before = "look_at", After = "\n")]
        public PovVector LookAt { get; set; } = null;
    }
}