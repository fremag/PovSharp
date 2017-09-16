using System;

namespace PovSharp.Core
{
    public abstract class AbstractPovElement : ICloneable
    {
        public string Name { get; set; }
        public abstract string ToPovCode();

        protected AbstractPovElement(string name)
        {
            Name = name;
        }

        public virtual object Clone()
        {
            return base.MemberwiseClone();
        }
    }
}
