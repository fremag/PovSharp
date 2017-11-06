using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Cylinder : AbstractPovObject
    {
        public override string Type => "cylinder";
        [PovField(0, After = ",")]
        public PovVector BasePoint { get; set; } = new PovVector(0);

        [PovField(1, After = ",")]
        public PovVector CapPoint { get; set; } = new PovVector(0, 1, 0);

        [PovField(2, After = "\n")]
        public PovNumber Radius { get; set; } = new PovNumber(1);

        [PovField(4, After = "\n")]
        public OpenFlag? Open { get; set; }

        public Cylinder()
        {
        }

        public Cylinder(string name) : base(name)
        {
        }
    }
}