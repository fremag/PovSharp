using PovSharp.Core;
using PovSharp.Csg;
using PovSharp.Transformations;

namespace PovSharp.Demos.Droid
{
    public class DroidObject : CsgUnion
    {
        public DroidObject()
        {
            Add(
                new DroidHead().Translate(_Y)
            );
            Add(
                new DroidBody()
            );

        }
    }
    
}