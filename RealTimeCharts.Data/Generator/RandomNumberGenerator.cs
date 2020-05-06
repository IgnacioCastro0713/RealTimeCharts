using System;

namespace RealTimeCharts.Data.Generator
{
    public class RandomNumberGenerator
    {
        private static readonly Random Rnd = new Random();

        public static int RandomScalingFactor() => Rnd.Next(100);

        public static int RandomColorFactor() => Rnd.Next(255);
    }
}