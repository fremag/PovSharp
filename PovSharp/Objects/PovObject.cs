using PovSharp.Core;

namespace PovSharp.Objects
{
    public class PovObject : AbstractPovObject
    {
        protected PovObject(string name) : base(name)
        {
        }

        public PovObject(AbstractPovObject povObject) : this((string)null)
        {
            this.Object = povObject;
        }
        [PovField(0, After="\n")]
        public AbstractPovObject Object { get; set; }

        public override string Type => "object";
    }
}