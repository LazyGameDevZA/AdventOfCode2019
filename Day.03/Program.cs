using System;

namespace Day._03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");

            var wire1 = PathParser.ParsePath(args[0]);
            var wire2 = PathParser.ParsePath(args[1]);
            
            var closestCross = ClosestCrossSectionFinder.FindClosestManhattanCross(wire1, wire2);
            
            Console.WriteLine($"Closest cross distance found: {closestCross}");

            var closestCircuitCross = ClosestCrossSectionFinder.FindClosestViaWireCross(wire1, wire2);
            
            Console.WriteLine($"Closest circuit cross distance found: {closestCircuitCross}");
            
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}