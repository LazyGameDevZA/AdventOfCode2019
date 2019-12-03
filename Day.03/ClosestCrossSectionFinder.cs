using System;
using System.Collections.Generic;
using System.Linq;

namespace Day._03
{
    public static class ClosestCrossSectionFinder
    {
        public static int FindClosestManhattanCross(Int2[] wire1, Int2[] wire2)
        {
            return wire1.Intersect(wire2)
                .Select(x =>
                        {
                            var subtractionResult = Int2.Zero - x;
                            return subtractionResult.ManhattanDistanceMagnitude;
                        })
                .Min();
        }

        public static int FindClosestViaWireCross(Int2[] wire1, Int2[] wire2)
        {
            var wireOneSteps = new Dictionary<Int2, int>();
            var wireTwoSteps = new Dictionary<Int2, int>();

            var stepCount = 0;
            foreach(var position in wire1)
            {
                stepCount++;
                if(wireOneSteps.ContainsKey(position))
                {
                    continue;
                }

                wireOneSteps.Add(position, stepCount);
            }

            stepCount = 0;
            foreach(var position in wire2)
            {
                stepCount++;
                if(wireTwoSteps.ContainsKey(position))
                {
                    continue;
                }

                wireTwoSteps.Add(position, stepCount);
            }

            return wire1.Intersect(wire2)
                .Select(x =>
                        {
                            var stepsOne = wireOneSteps[x];
                            var stepsTwo = wireTwoSteps[x];
                            return stepsOne + stepsTwo;
                        })
                .Min();
        }
    }
}
