using PovSharp.Core;

namespace PovSharp.Values
{
    public class PovNumber : AbstractPovValue
    {
        public PovNumber(string name) : base(name)
        {
        }

        public PovNumber(double value) : base(null)
        {
            Value = value;
        }

        public double Value { get; private set; }

        public override string ToPovCode() => $"{Value}";

        public static implicit operator PovNumber(double d) => new PovNumber(d);

    }
}
