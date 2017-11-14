using System.Drawing;
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
                 Body = new DroidBody(mainPigment, decoPigmentMajor, decoPigmentMinor);
            Add(
                Head
                .TranslateY(Body.Height.Value*0.97)
            );
            Add(
                Body
            );
        }

        public DroidHead Head { get; }
             public DroidBody Body {get;}
    }
    
}