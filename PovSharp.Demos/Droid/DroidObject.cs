using PovSharp.Core;
using PovSharp.Csg;
using PovSharp.Textures;
using PovSharp.Transformations;

namespace PovSharp.Demos.Droid
{
    public class DroidObject : CsgUnion
    {
        public DroidObject(Pigment mainPigment, Pigment decoPigmentMajor, Pigment decoPigmentMinor)
        {
            Head = new DroidHead(mainPigment, decoPigmentMajor, decoPigmentMinor);
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