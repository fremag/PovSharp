using System;
using PovSharp.Core;

namespace PovSharp.Values
{
    public class PovNumber : AbstractPovValue, IEquatable<double>
    {
        public PovNumber(string name) : base(name)
        {
        }

        public PovNumber(double value) : base(null)
        {
            Value = value;
        }

        public PovNumber(string name, double value) : this(name)
        {
            Value = value;
        }

        public double Value { get; private set; }
        public override string ToPovCode() => $"{Value}";
        public override string ToString() => $"{Name ?? "NoName"}: {Value}";

        public static implicit operator PovNumber(double d) => new PovNumber(d);

        public bool Equals(double other)
        {
            return Value.Equals(other);
        }

        public override bool Equals(object other)
        {
            var num = other as PovNumber;
            if (num != null)
            {
                return Value == num.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
