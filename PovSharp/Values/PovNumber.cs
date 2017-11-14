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

            if (other is double)
            {
                return Value == (double)other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(PovNumber num1, PovNumber num2)
        {
            if ((object)num1 == null && (object)num2 != null)
            {
                return false;
            }
            if ((object)num1 != null && (object)num2 == null)
            {
                return false;
            }
            if ((object)num1 == null && (object)num2 == null)
            {
                return true;
            }

            return num1.Value == num2.Value;
        }

        public static bool operator !=(PovNumber num1, PovNumber num2)
        {
            return !(num1 == num2);
        }

        public static bool operator ==(PovNumber num1, double num2)
        {
            if ((object)num1 == null)
            {
                return false;
            }

            return num1.Value == num2;
        }
        
        public static bool operator !=(PovNumber num1, double num2)
        {
            return !(num1 == num2);
        }

        public static PovNumber operator *(PovNumber num1, PovNumber num2)
        {
            return NumberOp("*", num1, num2, num1.Value * num2.Value);
        }
        public static PovNumber operator /(PovNumber num1, PovNumber num2)
        {
            return NumberOp("/", num1, num2, num1.Value / num2.Value);
        }
        public static PovNumber operator +(PovNumber num1, PovNumber num2)
        {
            return NumberOp("+", num1, num2, num1.Value + num2.Value);
        }
        public static PovNumber operator -(PovNumber num1, PovNumber num2)
        {
            return NumberOp("-", num1, num2, num1.Value - num2.Value);
        }
        public static PovNumber operator -(PovNumber num)
        {
            return  new PovNumber( $"-{num.Name??num.ToPovCode()}", -num.Value);
        }

        private static PovNumber NumberOp(string symbol, PovNumber num1, PovNumber num2, double newValue)
        {
            var result = new PovNumber( $"({num1.Name??num1.ToPovCode()} {symbol} {num2.Name??num2.ToPovCode()})", newValue);
            return result;
        }
    }
}
