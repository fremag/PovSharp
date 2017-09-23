using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Box : AbstractPovObject
    {
        public override string Type => "box";
        [PovField(0, After = ",")]
        public PovVector Corner1 { get; set; } = new PovVector(0);

        [PovField(1, After = "\n")]
        public PovVector Corner2 { get; set; } = new PovVector(1);
        public Box(string name) : base(name)
        {
        }
        public Box() : base(null)
        {
        }
    }
}