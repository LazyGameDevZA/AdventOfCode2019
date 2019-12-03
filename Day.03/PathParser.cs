using System;
using System.Collections.Generic;

namespace Day._03
{
    public static class PathParser
    {
        public static Int2[] ParsePath(string path)
        {
            var currentPosition = default(Int2);
            var pathItems = path.Split(',');
            var wire = new List<Int2>(pathItems.Length * 1000);

            for(int i = 0; i < pathItems.Length; i++)
            {
                var pathItem = pathItems[i];

                var direction = ParsesDirection(pathItem[0]);
                var distance = int.Parse(pathItem.Substring(1));

                for(int j = 0; j < distance; j++)
                {
                    currentPosition += direction;
                    wire.Add(currentPosition);
                }
            }

            return wire.ToArray();
        }

        private static Int2 ParsesDirection(char direction)
        {
            switch(direction)
            {
                case 'U':
                    return Int2.Up;
                case 'D':
                    return Int2.Down;
                case 'L':
                    return Int2.Left;
                case 'R':
                    return Int2.Right;
                default:
                    throw new Exception("Unknown direction parsed");
            }
        }
    }
}