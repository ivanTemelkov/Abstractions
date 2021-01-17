using System;
using System.Diagnostics.CodeAnalysis;

namespace Geometry.Common.Units
{
    public class Area : IEquatable<Area>, IComparable<Area>
    {
        private double SquareMillimeters { get; }

        private Area(double squareMillimeters)
        {
            SquareMillimeters = squareMillimeters;
        }
        
        public Area(Length width, Length height)
        {
            if (width is null)
            {
                throw new ArgumentNullException(nameof(width));
            }

            if (height is null)
            {
                throw new ArgumentNullException(nameof(height));
            }

            SquareMillimeters = width.ToMillimeters() * height.ToMillimeters();
        }

        public static Area Zero => new Area(0);
        public static Area SquareMillimeter => new Area(1.FromMillimeters(), 1.FromMillimeters());
        public static Area SquareCentimeter => new Area(1.FromCentimeters(), 1.FromCentimeters());
        public static Area SquareMeter => new Area(1.FromMeters(), 1.FromMeters());

        public static Area SquareInch => new Area(1.FromInches(), 1.FromInches());

        public static Area SquareFoot => new Area(1.FromFeet(), 1.FromFeet());


        public Area Add(Area other) => new Area(SquareMillimeters + other.SquareMillimeters);

        public static Area operator +(Area a, Area b) =>
            new Area(a.SquareMillimeters + b.SquareMillimeters);

        public static Area operator -(Area a, Area b) =>
            a.SquareMillimeters >= b.SquareMillimeters ?
            new Area(a.SquareMillimeters - b.SquareMillimeters) :
            Zero;

        public static Area operator *(Area length, double factor) =>
            new Area(length.SquareMillimeters * factor);

        public static Area operator *(double factor, Area length) =>
            length * factor;

        public static Length operator /(Area a, Length b) =>
            Length.Millimeter * (a.SquareMillimeters / b.ToMillimeters());


        public string ToString(AreaUoM unit)
        {
            return unit switch
            {
                AreaUoM.Unitless => $"{SquareMillimeters:0.0} ul",
                AreaUoM.SqareMillimeter => $"{SquareMillimeters:0.0} mm^2",
                AreaUoM.SqareCentimeter => $"{SquareMillimeters/100.0:0.0} cm^2",
                AreaUoM.SqareMeter => $"{SquareMillimeters / 1000000.0:0.0} m^2",
                _ => throw new InvalidOperationException($"Unknown {nameof(AreaUoM)} value: {unit}"),
            };
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Area);
        }

        public bool Equals(Area other)
        {
            return other != null &&
                   SquareMillimeters == other.SquareMillimeters;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SquareMillimeters);
        }

        public int CompareTo(Area other)
        {
            return SquareMillimeters.CompareTo(other.SquareMillimeters);
        }
    }
}
