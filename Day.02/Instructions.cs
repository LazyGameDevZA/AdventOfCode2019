using System;

namespace Day._02
{
    public static class Instructions
    {
        public static void ExecuteAdd(int instructionPointer, Span<int> memory)
        {
            var indexOne = memory[instructionPointer + 1];
            var indexTwo = memory[instructionPointer + 2];
            var resultIndex = memory[instructionPointer + 3];
            
            var valueOne = memory[indexOne];
            var valueTwo = memory[indexTwo];
            var result = valueOne + valueTwo;

            memory[resultIndex] = result;
        }

        public static void ExecuteMultiply(int instructionPointer, Span<int> memory)
        {
            var indexOne = memory[instructionPointer + 1];
            var indexTwo = memory[instructionPointer + 2];
            var resultIndex = memory[instructionPointer + 3];
            
            var valueOne = memory[indexOne];
            var valueTwo = memory[indexTwo];
            var result = valueOne * valueTwo;

            memory[resultIndex] = result;
        }
    }
}