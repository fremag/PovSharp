using PovSharp.Core;

namespace PovSharp.Csg
{
    public class CsgDifference : AbstractCsgObject
    {
        [PovField(0, After="\n")]
        public AbstractPovObject MainObject {get; set;}

        public CsgDifference(AbstractPovObject mainObject) 
        {
            MainObject = mainObject;
        }

        public CsgDifference(string name) : base(name)
        {
        }

        public override string Type => "difference";
    }
}