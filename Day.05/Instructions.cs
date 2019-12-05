using System;

namespace Day._05
{
    public static class Instructions
    {
        public const int Add = 1;
        public static void ExecuteAdd(this Span<int> memory, ref int instructionPointer, int paramOnePointer, int paramTwoPointer, int resultPointer)
        {
            var paramOne = memory[paramOnePointer];
            var paramTwo = memory[paramTwoPointer];

            memory[resultPointer] = paramOne + paramTwo;

            instructionPointer += 4;
        }


        public const int Multiply = 2;
        public static void ExecuteMultiply(this Span<int> memory, ref int instructionPointer, int paramOnePointer, int paramTwoPointer, int resultPointer)
        {
            var paramOne = memory[paramOnePointer];
            var paramTwo = memory[paramTwoPointer];

            memory[resultPointer] = paramOne * paramTwo;

            instructionPointer += 4;
        }

        public const int Input = 3;
        public static void ExecuteInput(this Span<int> memory, ref int instructionPointer, int input)
        {
            var inputPointer = memory[instructionPointer + 1];
            memory[inputPointer] = input;
            instructionPointer += 2;
        }

        public const int Output = 4;
        public static void ExecuteOutput(this Span<int> memory, ref int instructionPointer, int outputPointer, out int output)
        {
            output = memory[outputPointer];
            instructionPointer += 2;
        }

        public const int JumpIfTrue = 5;
        public static void ExecuteJumpIfTrue(this Span<int> memory, ref int instructionPointer, int paramOnePointer, int paramTwoPointer)
        {
            if(memory[paramOnePointer] != default)
            {
                instructionPointer = memory[paramTwoPointer];
                return;
            }

            instructionPointer += 3;
        }

        public const int JumpIfFalse = 6;
        public static void ExecuteJumpIfFalse(this Span<int> memory, ref int instructionPointer, int paramOnePointer, int paramTwoPointer)
        {
            if(memory[paramOnePointer] == default)
            {
                instructionPointer = memory[paramTwoPointer];
                return;
            }

            instructionPointer += 3;
        }

        public const int LessThan = 7;
        public static void ExecuteLessThan(this Span<int> memory, ref int instructionPointer, int paramOnePointer, int paramTwoPointer,
            int resultPointer)
        {
            if(memory[paramOnePointer] < memory[paramTwoPointer])
            {
                memory[resultPointer] = 1;
            }
            else
            {
                memory[resultPointer] = 0;
            }

            instructionPointer += 4;
        }

        public new const int Equals = 8;
        public static void ExecuteEquals(this Span<int> memory, ref int instructionPointer, int paramOnePointer, int paramTwoPointer,
            int resultPointer)
        {
            if(memory[paramOnePointer] == memory[paramTwoPointer])
            {
                memory[resultPointer] = 1;
            }
            else
            {
                memory[resultPointer] = 0;
            }

            instructionPointer += 4;
        }

        public const int Halt = 99;
    }
}