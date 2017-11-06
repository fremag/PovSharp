using PovSharp.Core;

namespace PovSharp.Values
{
    public class Point2D : AbstractPovValue
    {
        [PovField(0, Before = "<", After = ",")]
        public PovNumber X { get; set; }
        [PovField(1, After = ">")]
        public PovNumber Y { get; set; }

        public Point2D() : base(null) { }
        public Point2D(string name, PovNumber x, PovNumber y) : base(name)
        {
            X = x;
            Y = y;
        }
        public Point2D( PovNumber x, PovNumber y) : this(null, x, y)
        { }

        public Point2D(double x, double y) : this(null, x, y) { }
        public Point2D(string name) : this(name, 0, 0) { }
        public Point2D(string name, double d) : this(name, d, d) { }
        public Point2D(double d) : this(null, d, d) { }

        public Point2D(int x, int y) : this(null, x, y)
        { }

        public override string ToPovCode() => this.BuildPovCode();
        public override string ToString() => $"{Name ?? "NoName"}: < {X}, {Y}>";

        public override bool Equals(object obj)
        {
            var other = obj as PovVector;
            if (other == null)
            {
                return false;
            }

            var b = X.Equals(other.X);
            b &= Y.Equals(other.Y);
            return b;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + X.GetHashCode();
            hash *= 23 + Y.GetHashCode();
            return hash;
        }
    }
}