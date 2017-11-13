using PovSharp.Csg;
using PovSharp.Objects;
using PovSharp.Core;
using PovSharp.Values;
using System;
using PovSharp.Transformations;
using PovSharp.Textures;

namespace PovSharp.Demos.Droid
{
    public class DroidHead : CsgUnion
    {
        const double hNeck = 0.13;
        const double hSkull = 0.61;
        const double rSkull = 0.5;
        const double yTopRing = 0.46;
        const double yMiddleRing = 0.38;
        const double hTopRing = 0.08;
        const double hBottomRing = 0.04;
        public double Heigth => hSkull + hNeck;
        public DroidHead(Pigment mainPigment, Pigment decoPigmentMajor, Pigment decoPigmentMinor)
        {
            double yBottomSkull = 2 * rSkull - hSkull;
            double rBottomSkull = Math.Sqrt(Math.Pow(rSkull, 2) - Math.Pow(hSkull - rSkull, 2));

            var skull = new CsgDifference(
                new Sphere() { Center = _V(0, rSkull, 0), Radius = rSkull })
                .Add(new Box() { Corner1 = _V(-1), Corner2 = _V(1, yBottomSkull, 1) });
            Local(nameof(skull), skull);

            var neck = new CsgDifference(
                new Cone()
                {
                    BaseRadius = rBottomSkull,
                    BasePoint = _V(0, yBottomSkull, 0),
                    CapPoint = _V(0, yBottomSkull - 0.5, 0)
                })
                .Add(new Box() { Corner1 = _V(-1, yBottomSkull - hNeck, -1), Corner2 = _V(1, -1, 1) })
                ;
            Local(nameof(neck), neck);

            var topRing = new Box() { Corner1 = _V(-1, 0, -1), Corner2 = _V(1, 1, 1) }.Scale(1, hTopRing, 1).Translate(0, yTopRing, 0);
            var bottomRing = new Box() { Corner1 = _V(-1, 0, -1), Corner2 = _V(1, 1, 1) }.Scale(1, hBottomRing, 1);
            var middleRing = new Box() { Corner1 = _V(-1, 0, -1), Corner2 = _V(1, 1, 1) }.Scale(1, hBottomRing, 1).Translate(0, yMiddleRing, 0);

            var minorDecoElements = new CsgUnion()
            .Add(topRing)
            .Add(bottomRing)
            .Translate(0, yBottomSkull, 0)
            ;

            var minorDeco = new CsgIntersection()
            .Add(new Sphere() { Center = _V(0, rSkull, 0), Radius = rSkull * 1.0005 })
            .Add(minorDecoElements)
            .AddModifiers(decoPigmentMinor);
            ;

            var miscDeco = new CsgUnion();
            for (int i = 0; i < 10; i++)
            {
                miscDeco.Add(new Box() { Corner1 = _V(-1, 0, -1), Corner2 = _V(1, 1, 1) }.Scale(1, hTopRing, 0.05).Rotate(0, 15 * i, 0));
            }

            miscDeco.Translate(0, hBottomRing, 0)
            ;

            var majorDecoElements = new CsgUnion()
            .Add(middleRing)
            .Add(miscDeco)
            .Translate(0, yBottomSkull, 0)
            ;
            var majorDeco = new CsgIntersection()
            .Add(new Sphere() { Center = _V(0, rSkull, 0), Radius = rSkull * 1.0005 })
            .Add(majorDecoElements)
            .AddModifiers(decoPigmentMajor);
            ;

            Add(majorDeco);
            Add(minorDeco);
            Add(skull);
            Add(neck);

            AddModifiers(mainPigment);
            this.Translate(_V(0, -yBottomSkull + hNeck, 0));
        }
    }
}