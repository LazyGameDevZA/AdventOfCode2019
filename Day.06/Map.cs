using System;
using System.Collections.Generic;
using System.Linq;

namespace Day._06
{
    public class Map
    {
        private readonly Dictionary<string, string> orbitalMap;

        private Map()
        {
            this.orbitalMap = new Dictionary<string, string>();
        }

        public static Map Parse(string[] map)
        {
            var parsedMap = new Map();

            foreach(var orbit in map)
            {
                var bodies = orbit.Split(')');
                parsedMap.orbitalMap.Add(bodies[1], bodies[0]);
            }

            return parsedMap;
        }

        public int CalculateOrbitsFor(string body)
        {
            return CalculatePathToCenterOfMass(body).Count;
            var counter = 0;

            var current = body;
            while(orbitalMap.ContainsKey(current))
            {
                var target = orbitalMap[current];
                counter++;
                current = target;
            }
            
            return counter;
        }

        public int CalculateChecksum()
        {
            var orbitCount = 0;

            foreach(var body in this.orbitalMap.Keys)
            {
                var bodyCount = this.CalculateOrbitsFor(body);

                orbitCount += bodyCount;
            }

            return orbitCount;
        }

        public int CalculateOrbitalTransfersRequired(string @from, string to)
        {
            var fromPath = CalculatePathToCenterOfMass(@from);
            var toPath = CalculatePathToCenterOfMass(to);
            
            fromPath.Reverse();
            toPath.Reverse();

            for(int i = 0; i < Math.Min(fromPath.Count, toPath.Count); i++)
            {
                if(fromPath[i] == toPath[i])
                {
                    continue;
                }

                return fromPath.Count - i + toPath.Count - i;
            }
            
            throw new Exception($"No Path found from {@from} to {to}");
        }

        private List<string> CalculatePathToCenterOfMass(string fromBody)
        {
            var path = new List<string>();
            string target = fromBody;

            while(this.orbitalMap.ContainsKey(target))
            {
                target = orbitalMap[target];
                path.Add(target);
            }

            return path;
        }
    }
}
