using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class SphereSweep : AbstractPovObject
    {

        public enum SphereSweepSpline { linear_spline, b_spline, cubic_spline }
        public static readonly SphereSweepSpline LinearSpline = SphereSweepSpline.linear_spline;
        public static readonly SphereSweepSpline BSpline = SphereSweepSpline.b_spline;
        public static readonly SphereSweepSpline CubicSpline = SphereSweepSpline.cubic_spline;

        public override string Type => "sphere_sweep";

        [PovField(0, After = "\n")]
        public SphereSweepSpline? SplineType { get; set; }

        [PovField(1, After = "\n")]
        public PovNumber NbSpheres => Elements.Count;

        [PovField(2, After = "\n")]
        private PovList<SphereSweepElement> Elements { get; set; } = new PovList<SphereSweepElement>("\n");

        public SphereSweep Add(PovVector center, PovNumber radius)
        {
            Elements.Add(new SphereSweepElement { Center = center, Radius = radius });
            return this;
        }

        [PovField(2, Before = "tolerance", After = "\n")]
        public PovNumber Tolerance { get; set; } = null;

        public SphereSweep()
        {
        }

        public SphereSweep(string name) : base(name)
        {
        }

        private class SphereSweepElement : AbstractPovElement
        {
            [PovField(0, After = ",")]
            internal PovVector Center { get; set; }

            [PovField(1, After = "\n")]
            internal PovNumber Radius { get; set; }

            public override string ToPovCode() => this.BuildPovCode();
        }
    }
}