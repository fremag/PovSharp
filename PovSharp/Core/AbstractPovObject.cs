namespace PovSharp.Core
{
    public abstract  class AbstractPovObject : AbstractPovElement
    {
        public abstract string Type {get;}
        protected AbstractPovObject(string name) : base(name)
        {
        }
        
        public override string ToPovCode() => $"{Type} {{\n {this.BuildPovCode()}}}";

    }
}