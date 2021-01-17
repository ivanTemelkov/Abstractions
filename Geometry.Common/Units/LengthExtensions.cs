using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Common.Units
{
    public static class LengthExtensions
    {
        public static Length FromMillimeters(this int value) => Length.Millimeter * value;
        public static Length FromMillimeters(this double value) => Length.Millimeter * value;


        public static Length FromCentimeters(this int value) => Length.Centimeter * value;
        public static Length FromCentimeters(this double value) => Length.Centimeter * value;


        public static Length FromMeters(this int value) => Length.Meter * value;
        public static Length FromMeters(this double value) => Length.Meter * value;


        public static Length FromInches(this int value) => Length.Inch * value;
        public static Length FromInches(this double value) => Length.Inch * value;

        public static Length FromFeet(this int value) => Length.Foot * value;
        public static Length FromFeet(this double value) => Length.Foot * value;

    }
}
