using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Geometry.Common.Units
{
    public static class MetricSystem
    {
        public static T Exa<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, 18));
        }

        public static T Peta<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, 15));
        }

        public static T Tera<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, 12));
        }

        public static T Giga<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, 9));
        }

        public static T Mega<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, 6));
        }

        public static T Kilo<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, 3));
        }

        public static T Hecto<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, 2));
        }

        public static T Deca<T>(T value) where T : IScalable<T>
        {
            return value.Scale(10);
        }

        public static T Deci<T>(T value) where T : IScalable<T>
        {
            return value.Scale(0.1);
        }

        public static T Centi<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, -2));
        }

        public static T Milli<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, -3));
        }

        public static T Micro<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, -6));
        }

        public static T Nano<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, -9));
        }

        public static T Pico<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, -12));
        }

        public static T Femo<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, -15));
        }

        public static T Atto<T>(T value) where T : IScalable<T>
        {
            return value.Scale(Math.Pow(10, -18));
        }
    }

    public class Length : IEquatable<Length>, IComparable<Length>, IScalable<Length>
    {
        private double Millimeters { get; }

        private Length(double millimeters)
        {
            Millimeters = millimeters;
        }

        public static Length Zero =>
            new Length(0);

        public static Length Millimeter => new Length(1);

        public static Length Centimeter => new Length(10);

        public static Length Meter => Centimeter * 100;

        public static Length Inch = new Length(25.4);

        public static Length Foot = new Length(304.8);

        public Length Add(Length other) =>
            new Length(Millimeters + other.Millimeters);

        public Length Scale(double factor) =>
            new Length(Millimeters * factor);

        public Length Max(Length other) =>
            Millimeters >= other.Millimeters ? this : other;

        public static Length operator +(Length a, Length b) =>
            new Length(a.Millimeters + b.Millimeters);

        public static Length operator -(Length a, Length b) =>
            a.Millimeters >= b.Millimeters ?
            new Length(a.Millimeters - b.Millimeters) :
            Zero;

        public static Length operator *(Length length, double factor) =>
            new Length(length.Millimeters * factor);

        public static Length operator /(Length length, double factor) =>
            new Length(length.Millimeters / factor);

        public static Length operator *(double factor, Length length) =>
            length * factor;

        public static Area operator *(Length a, Length b) =>
            new Area(a, b);

        public double ToMillimeters() => Millimeters;
        public double ToCentimeters() => Millimeters / 10.0;
        public double ToMeters() => Millimeters / 1000.0;

        public double ToInch() => Millimeters / 25.4;
        public double ToFoot() => Millimeters / 304.8;

        public override string ToString() =>
            ToString(GetUserFriendlyScale(Millimeters));

        public string ToString(LengthUoM unit)
        {
            return unit switch
            {
                LengthUoM.Unitless => $"{Millimeters:0.0} ul",
                LengthUoM.Millimeter => $"{Millimeters:0.0} mm",
                LengthUoM.Centimeter => $"{Millimeters / 10.0:0.00} cm",
                LengthUoM.Meter => $"{Millimeters / 1000.0:0.000} m",
                _ => throw new InvalidOperationException($"Unknown {nameof(LengthUoM)} value: {unit}"),
            };
        }

        public static string ToString(string separator, params Length[] lengths) =>
            ToString(separator, lengths, GetGreatestScale(lengths));

        private static string ToString(string separator, IEnumerable<Length> lengths, (double factor, string unit) scale) =>
            ToString(separator, lengths, scale.factor, scale.unit);

        private static string ToString(string separator, IEnumerable<Length> lengths, double factor, string unit) =>
            $"{ToString(separator, lengths, factor)} {unit}";

        private static string ToString(string separator, IEnumerable<Length> lengths, double factor) =>
            string.Join(separator, lengths.Select(length => $"{length.Millimeters * factor:##.###}").ToArray());

        private static (double factor, string unit) GetGreatestScale(IEnumerable<Length> lengths) =>
            GetGreatestScale(lengths.Select(length => length.Millimeters));

        private static (double factor, string unit) GetGreatestScale(IEnumerable<double> millimeters) =>
            GetUserFriendlyScales(millimeters)
                .Aggregate((a, b) => a.factor >= b.factor ? a : b);

        private static IEnumerable<(double factor, string unit)> GetUserFriendlyScales(IEnumerable<double> millimeters) =>
            millimeters.Select(GetUserFriendlyScale);

        private static (double factor, string unit) GetUserFriendlyScale(double millimeters) =>
            millimeters > 800 ? (1.0 / 1000, "m")
            : millimeters > 80 ? (1.0 / 10, "cm")
            : (1, "mm");

        private string ToString((double factor, string unit) scale) =>
            ToString(scale.factor, scale.unit);

        private string ToString(double factor, string unit) =>
            factor <= 1.0 / 1000 ?
            $"{Millimeters * factor:0.000} {unit}" :
            factor <= 1.0 / 100 ?
            $"{Millimeters * factor:0.00} {unit}" :
            $"{Millimeters * factor:0.0} {unit}";

        public override bool Equals(object obj)
        {
            return Equals(obj as Length);
        }

        public bool Equals(Length other)
        {
            return other != null &&
                   Millimeters == other.Millimeters;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Millimeters);
        }

        public int CompareTo(Length other)
        {
            return Millimeters.CompareTo(other.Millimeters);
        }
    }
}
