using System;
using PovSharp.Values;

namespace PovSharp.Core
{
    public abstract class AbstractPovElement : PovValueHelpers, ICloneable
    {
        public enum OpenFlag { open }

        public enum SturmFlag { sturm }

        public enum ObjectSplineType { linear_spline, quadratic_spline, cubic_spline, bezier_spline }
        public enum SweepType { linear_sweep, conic_sweep }

        public string Name { get; set; }
        public abstract string ToPovCode();
        public AbstractPovElement()
        {

        }

        protected AbstractPovElement(string name) : this()
        {
            Name = name;
        }

        public virtual object Clone()
        {
            return base.MemberwiseClone();
        }
    }
}
