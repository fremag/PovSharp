using PovSharp.Core;
using PovSharp.Values;

namespace PovSharp.Objects
{
    public class Blob : AbstractPovObject
    {
        public override string Type => "blob";

        [PovField(0, Before = "threshold", After = "\n")]
        public PovNumber Threshold { get; set; } = null;

        [PovField(1, After = "\n")]
        private PovList<AbstractBlobElement> Elements { get; } = new PovList<AbstractBlobElement>("\n");

        [PovField(2, Before = "hierarchy", After = "\n")]
        public bool? Hierarchy { get; set; } = null;

        [PovField(3, Before = "sturm", After = "\n")]
        public bool? Sturm { get; set; } = null;

        public Blob(string name) : base(name)
        {
        }

        public Blob()
        {
        }

        public Blob AddSphere(PovVector center, PovNumber radius, PovNumber strength, params AbstractObjectModifier[] modifiers) {
            var sphere = new SphereBlobElement {Center = center, Radius = radius, Strength = strength};
            sphere.AddModifiers(modifiers);
            Elements.Add(sphere);
            return this;
        }
        public Blob AddCylinder(PovVector end1, PovVector end2,PovNumber radius, PovNumber strength, params AbstractObjectModifier[] modifiers) {
            var cylinder = new CylinderBlobElement {End1 = end1, End2 = end2, Radius = radius, Strength = strength};
            cylinder.AddModifiers(modifiers);
            Elements.Add(cylinder);
            return this;
        }

        private abstract class AbstractBlobElement : AbstractPovObject
        {
        }

        private class SphereBlobElement : AbstractBlobElement
        {
            public override string Type => "sphere";

            [PovField(0, After = ",")]
            internal PovVector Center { get; set; }
            
            [PovField(1, After = ",")]
            internal PovNumber Radius { get; set; }
            
            [PovField(2, Before="strength")]
            internal PovNumber Strength { get; set; }
        }
        private class CylinderBlobElement : AbstractBlobElement
        {
            public override string Type => "cylinder";

            [PovField(0, After = ",")]
            internal PovVector End1 { get; set; }

            [PovField(1, After = ",")]
            internal PovVector End2 { get; set; }
            
            [PovField(2, After = ",")]
            internal PovNumber Radius { get; set; }
            
            [PovField(3, Before="strength")]
            internal PovNumber Strength { get; set; }
        }
    }
}