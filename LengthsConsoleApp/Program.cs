using System;
using System.Collections.Generic;

using Geometry.Common;
using Geometry.Common.Units;

namespace LengthsConsoleApp
{
    class Program
    {
        private static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            // TestLength();
            // TestArea();

            var dim = MetricSystem.Nano(1.FromMeters());
            Console.WriteLine(MetricSystem.Nano(1.FromMeters()));


            return;

            var dim1 = Length.Inch / 25.4;
            var dim2 = 1.FromInches();

            var area = 20.FromSqareCentimeters();

            dim1 = area / dim2;

            Console.WriteLine(dim1);
        }

        private static void TestArea()
        {
            var area = 5.FromCentimeters() * 10.FromMillimeters();
            Console.WriteLine(area.ToString(AreaUoM.SqareCentimeter));

            var dim = area / 5.FromMillimeters();
            Console.WriteLine(dim.ToString());
        }

        private static void TestLength()
        {
            var dim1 = 0.0001.FromMillimeters() * 0.999;
            var dim2 = 0.00001.FromCentimeters() * 0.999;

            var dimensions = new List<Length>();

            for (int i = 0; i < 10; i++)
            {
                dimensions.Add(rnd.Next(1, 10000).FromMillimeters());
            }

            dimensions.Sort();

            foreach (var dimension in dimensions)
            {
                Console.WriteLine(dimension.ToString(LengthUoM.Millimeter).PadLeft(10));
            }
        }
    }
}
