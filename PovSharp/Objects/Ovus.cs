using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Ovus : AbstractPovObject
    {
        public override string Type => "ovus";
        [PovField(0, After = ",")]
        public PovNumber BottomRadius { get; set; } = new PovNumber(1);

        [PovField(3, After = "\n")]
        public PovNumber TopRadius { get; set; } = new PovNumber(0.5);

        public Ovus()
        {
        }

        public Ovus(string name) : base(name)
        {
        }
    }
}