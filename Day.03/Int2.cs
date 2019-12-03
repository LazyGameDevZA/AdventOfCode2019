using System;

namespace Day._03
{
    public readonly struct Int2
    {
        public static readonly Int2 Up = new  Int2(0, 1);
        public static readonly Int2 Down = new  Int2(0, -1);
        public static readonly Int2 Left = new  Int2(-1, 0);
        public static readonly Int2 Right = new  Int2(1, 0);
        public static readonly Int2 Zero = default;
        
        public readonly int X;
        public readonly int Y;

        public int ManhattanDistanceMagnitude => Math.Abs(X) + Math.Abs(Y);

        public Int2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Int2 operator *(Int2 value, int scalar)
        {
            return new Int2(value.X * scalar, value.Y * scalar);
        }

        public static Int2 operator -(Int2 left, Int2 right)
        {
            return new Int2(left.X - right.X, left.Y - right.Y);
        }

        public static Int2 operator +(Int2 left, Int2 right)
        {
            return new Int2(left.X + right.X, left.Y + right.Y);
        }
    }
}