using PovSharp.Values;

namespace PovSharp.Values
{
    public class PovValueHelpers
    {
        public static readonly PovVector _X = new PovVector(1, 0, 0);
        public static readonly PovVector _Y = new PovVector(0, 1, 0);
        public static readonly PovVector _Z = new PovVector(0, 0, 1);

        public static readonly PovColor _Red = new PovColor("Red", 1, 0, 0);
        public static readonly PovColor _Green = new PovColor("Green", 0, 1, 0);
        public static readonly PovColor _Blue = new PovColor("Blue", 0, 0, 1);
        public static readonly PovColor _Yellow = new PovColor("Yellow", 1, 1, 0);
        public static readonly PovColor _Cyan = new PovColor("Cyan", 0, 1, 1);
        public static readonly PovColor _Magenta = new PovColor("Magenta", 1, 0, 1);
        public static readonly PovColor _White = new PovColor("White", 1, 1, 1);
        public static readonly PovColor _Black = new PovColor("Black", 0, 0, 0);

        public PovVector _V(double d) => new PovVector(d);

        public PovVector _V(double x, double y, double z) => new PovVector(x, y, z);
        public PovNumber _N(double d) => new PovNumber(d);

        public PovColor _RGB(PovNumber red, PovNumber green, PovNumber blue) => new PovColor(red, green, blue);
    }
}
