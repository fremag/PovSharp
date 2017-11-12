namespace PovSharp.Core
{
    public class IncludeStatement : AbstractPovElement
    {
        public string IncludeFile {get; set;}

        public IncludeStatement()
        {
        }

        protected IncludeStatement(string name) : base(name)
        {
        }

        public override string ToPovCode() => $"#include \"{IncludeFile}\"";
    }
}