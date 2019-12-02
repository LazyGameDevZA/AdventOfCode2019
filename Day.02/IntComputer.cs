using System;

namespace Day._02
{
    public ref struct IntComputer
    {
        private readonly Span<int> memory;

        public IntComputer(Span<int> memory)
        {
            this.memory = memory;
        }

        public void Run()
        {
            for (int instructionPointer = 0; memory[instructionPointer] != 99; instructionPointer += 4)
            {
                var instruction = memory[instructionPointer];
                
                if (instruction == 1)
                {
                    Instructions.ExecuteAdd(instructionPointer, memory);
                }
                else if (instruction == 2)
                {
                    Instructions.ExecuteMultiply(instructionPointer, memory);
                }
                else
                {
                    throw new Exception("Unknown instruction");
                }
            }
        }
    }
}