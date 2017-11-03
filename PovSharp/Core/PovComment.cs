namespace PovSharp.Core
{
    public class PovComment : AbstractPovElement
    {
        public string Text {get; set;}
        protected PovComment(string name) : base(name)
        {
        }

        public PovComment() : base(null)
        {
        }

        public override string ToPovCode()
        {
            return $"/* {Text} */";
        }
    }
}