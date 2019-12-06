using System;

namespace Day._06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            var map = Map.Parse(args);

            var checksum = map.CalculateChecksum();
            
            Console.WriteLine($"Checksum: {checksum}");

            var transfers = map.CalculateOrbitalTransfersRequired("YOU", "SAN");
            
            Console.WriteLine($"Transfers required: {transfers}");
            
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}
