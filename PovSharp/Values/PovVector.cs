using PovSharp.Core;

namespace PovSharp.Values
{
    public class PovVector : AbstractPovValue
    {
        [PovField(0, Before = "<", After = ",")]
        public PovNumber X { get; set; }
        [PovField(1, After = ",")]
        public PovNumber Y { get; set; }
        [PovField(2, After = ">")]
        public PovNumber Z { get; set; }

        public PovVector() : base(null) { }
        public PovVector(string name, PovNumber x, PovNumber y, PovNumber z) : base(name)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public PovVector( PovNumber x, PovNumber y, PovNumber z) : this(null, x, y, z)
        { }

        public PovVector(double x, double y, double z) : this(null, x, y, z) { }
        public PovVector(string name) : this(name, 0, 0, 0) { }
        public PovVector(string name, double d) : this(name, d, d, d) { }
        public PovVector(double d) : this(null, d, d, d) { }

        public PovVector(int x, int y, int z) : base(null)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToPovCode() => this.BuildPovCode();
        public override string ToString() => $"{Name ?? "NoName"}: < {X}, {Y}, {Z}>";

        public override bool Equals(object obj)
        {
            var other = obj as PovVector;
            if (other == null)
            {
                return false;
            }

            var b = X.Equals(other.X);
            b &= Y.Equals(other.Y);
            b &= Z.Equals(other.Z);
            return b;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + X.GetHashCode();
            hash *= 23 + Y.GetHashCode();
            hash *= 23 + Z.GetHashCode();
            return hash;
        }

        public static PovVector operator *(PovVector vector, PovNumber num)
        {
            string name = $"{vector.Name??vector.ToPovCode()} * {num.Name??num.ToPovCode()}";
            return new PovVector(name, vector.X * num, vector.Y * num, vector.Z * num);
        }
        public static PovVector operator *(PovNumber num, PovVector vector)
        {
            string name = $"{num.Name??num.ToPovCode()} * {vector.Name??vector.ToPovCode()}";
            return new PovVector(name, vector.X * num, vector.Y * num, vector.Z * num);
        }
        public static PovVector operator -(PovVector vector)
        {
            string name = $"-{vector.Name??vector.ToPovCode()}";
            return new PovVector(name, -vector.X, -vector.Y, -vector.Z);
        }
        public static PovVector operator +(PovVector v1, PovVector v2)
        {
            string name = $"({v1.Name??v1.ToPovCode()} + {v2.Name??v2.ToPovCode()})";
            return new PovVector(name, v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static PovVector operator -(PovVector v1, PovVector v2)
        {
            string name = $"({v1.Name??v1.ToPovCode()} - {v2.Name??v2.ToPovCode()})";
            return new PovVector(name, v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
   }
}