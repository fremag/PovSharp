namespace PovSharp.Core
{
    public class DeclareElement : AbstractPovElement
    {
        public AbstractPovElement PovElement { get; set; }
        public string End { get; set; }
        public string povCode;

        public DeclareElement(string name, AbstractPovElement povElement, string end=";") : base(null)
        {
            PovElement = povElement;
            End = end;
            povCode = PovElement.Name ?? PovElement.ToPovCode();
            povElement.Name = name;
        }

        public override string ToPovCode() => $"#declare {PovElement.Name} = {povCode}{End}";
    }
}