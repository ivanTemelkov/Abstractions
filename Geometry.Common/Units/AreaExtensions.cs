namespace Geometry.Common.Units
{
    public static class AreaExtensions
    {
        public static Area FromSqareMillmieters(this int value) => Area.SquareMillimeter * value;
        public static Area FromSqareMillmieters(this double value) => Area.SquareMillimeter * value;

        public static Area FromSqareCentimeters(this int value) => Area.SquareCentimeter * value;
        public static Area FromSqareCentimeters(this double value) => Area.SquareCentimeter * value;

        public static Area FromSqareMeters(this int value) => Area.SquareMeter * value;
        public static Area FromSqareMeters(this double value) => Area.SquareMeter * value;

        public static Area FromSqareInches(this int value) => Area.SquareInch * value;

        public static Area FromSqareInches(this double value) => Area.SquareInch * value;


        public static Area FromSqareFeet(this int value) => Area.SquareFoot * value;
        public static Area FromSqareFeet(this double value) => Area.SquareFoot * value;

    }
}
