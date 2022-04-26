using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_8 {
    public abstract class Shape : object {

        public double Side { get; set; }
        public abstract char TextIcon { get; }

        public abstract double GetArea();

        // Generic ToString function.          Avoid using class name
        public new virtual string ToString() => $"{GetType().Name} [{TextIcon}] (Side: {Side}, Area: { Math.Round(GetArea(), 3)})";
        
        // Property for binding.
        // For some reason, binding ignores overwritten ToString method and only displays class name.
        public string StringRepr { get => ToString(); }
    }

    public class Triangle : Shape {
        // Required properties
        public override char TextIcon { get; } = '▲';

        // Additional properties
        // Better only recalculate result only when neccessary, but whatever ¯\_(ツ)_/¯
        public double Altitude { get => Side * Math.Sqrt(3.0) / 2; }

        // Constructor
        public Triangle(double a) {
            Side = a;
        }

        public override double GetArea() => (Altitude * Side) / 2;

        public override string ToString() => $"{GetType().Name} [{TextIcon}] (Side: {Side}, Altitude: {  Math.Round(Altitude, 3) }, Area: { Math.Round(GetArea(), 3) })";
    }

    public class Square : Shape {
        // Required properties
        public override char TextIcon { get; } = '⬛';

        // Constructor
        public Square(double a) {
            Side = a;
        }

        public override double GetArea() => Side * Side;
    }
}