using PovSharp.Csg;
using PovSharp.Objects;
using PovSharp.Core;
using PovSharp.Values;
using System;
using PovSharp.Transformations;

namespace PovSharp.Demos.Droid
{
    public class DroidHead : CsgUnion
    {
        const double neckH = 0.13;
        const double skullH = 0.6;
        const double skullR = 0.5;
        public DroidHead()
        {
            double yBottomSkull = 2*skullR-skullH;
            double rBottomSkull = Math.Sqrt( Math.Pow(skullR,2) - Math.Pow(skullH-skullR, 2) );

            var skull = new CsgDifference(
                new Sphere() { Center = _V(0, skullR, 0) , Radius = skullR })
                .Add(new Box() { Corner1 = _V(-1), Corner2 = _V(1, yBottomSkull, 1) });

            var neck = new CsgDifference(
                new Cone() {
                    BaseRadius = rBottomSkull, 
                    BasePoint = _V(0, yBottomSkull, 0), 
                    CapPoint = _V(0, yBottomSkull-0.5, 0) })
                .Add(new Box() { Corner1 = _V(-1,  yBottomSkull-neckH, -1), Corner2 = _V(1, -1, 1) })
                ;

            Add(skull);
            Add(neck);
            this.Translate(_V(0, -yBottomSkull+neckH ,0));
        }

        public double Heigth => skullH+neckH;
    }
}