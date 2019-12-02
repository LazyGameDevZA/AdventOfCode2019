using System;
using System.Linq;

namespace Day._01
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var moduleWeights = new int[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                moduleWeights[i] = int.Parse(args[i]);
            }

            var total = moduleWeights.Select(FuelCalculator.ForModuleWeightWithFuelWeight).Sum();
            Console.WriteLine(total);
        }
    }
}