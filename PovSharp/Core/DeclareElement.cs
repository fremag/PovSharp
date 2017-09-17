namespace PovSharp.Core
{
    public class DeclareElement : AbstractPovElement
    {
        public AbstractPovElement PovElement { get; set; }
        public string End { get; set; }

        public DeclareElement(string name, AbstractPovElement povElement, string end ) : base(name)
        {
            PovElement = povElement;
            End = end;
        }

        public override string ToPovCode() => $"#declare {Name} = {PovElement.ToPovCode()}{End}";
    }
}