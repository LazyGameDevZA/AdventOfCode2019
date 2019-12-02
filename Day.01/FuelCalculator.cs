using System;

namespace Day._01
{
    public static class FuelCalculator
    {
        public static int ForWeight(int weight)
        {
            return weight / 3 - 2;
        }

        public static int ForModuleWeightWithFuelWeight(int moduleWeight)
        {
            var totalFuel = 0;
            var moduleFuel = ForWeight(moduleWeight);

            for (int i = moduleFuel; i > 0; i = ForWeight(i))
            {
                totalFuel += i;
            }
            
            return totalFuel;
        }
    }
}