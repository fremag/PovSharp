using System;

namespace PovSharp.Core
{
    public class PovFieldAttribute : Attribute, IComparable<PovFieldAttribute>
    {
        private int Position { get; }
        public string Before {get; set;}
        public string After {get; set;}

        public PovFieldAttribute(int position)
        {
            Position = position;
        }

        int IComparable<PovFieldAttribute>.CompareTo(PovFieldAttribute other)
        {
            return Position - other.Position;
        }
    }
}