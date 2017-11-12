using PovSharp.Core;
using PovSharp.Csg;
using PovSharp.Transformations;

namespace PovSharp.Demos.Droid
{
    public class DroidObject : CsgUnion
    {
        public DroidObject()
        {
            Head = new DroidHead();
            Add(
                Head
                //.Translate(_Y)
            );
            // Add(
            //     new DroidBody()
            // );

        }

        public DroidHead Head { get; }
    }
    
}