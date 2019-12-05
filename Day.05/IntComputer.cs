using System;

namespace Day._05
{
    public ref struct IntComputer
    {
        private readonly Span<int> memory;
        private readonly int input;

        public IntComputer(Span<int> memory, int input)
        {
            this.memory = memory;
            this.input = input;
        }

        public int Run()
        {
            var output = 0;
            int instructionPointer = 0;
            var running = true;

            while (running)
            {
                var instructionCode = this.memory[instructionPointer] % 100;

                if (instructionCode == Instructions.Add)
                {
                    var (paramOnePointer, paramTwoPointer, resultPointer) = this.DecodeParamsWithResult(instructionPointer);
                    this.memory.ExecuteAdd(ref instructionPointer, paramOnePointer, paramTwoPointer, resultPointer);
                }
                else if (instructionCode == Instructions.Multiply)
                {
                    var (paramOnePointer, paramTwoPointer, resultPointer) = this.DecodeParamsWithResult(instructionPointer);
                    this.memory.ExecuteMultiply(ref instructionPointer, paramOnePointer, paramTwoPointer, resultPointer);
                }
                else if(instructionCode == Instructions.Input)
                {
                    this.memory.ExecuteInput(ref instructionPointer, this.input);
                }
                else if(instructionCode == Instructions.Output)
                {
                    var outputPointer = this.DecodeParam(instructionPointer);
                    this.memory.ExecuteOutput(ref instructionPointer, outputPointer, out output);
                }
                else if(instructionCode == Instructions.JumpIfTrue)
                {
                    var (paramOnePointer, paramTwoPointer) = this.DecodeParams(instructionPointer);
                    this.memory.ExecuteJumpIfTrue(ref instructionPointer, paramOnePointer, paramTwoPointer);
                }
                else if(instructionCode == Instructions.JumpIfFalse)
                {
                    var (paramOnePointer, paramTwoPointer) = this.DecodeParams(instructionPointer);
                    this.memory.ExecuteJumpIfFalse(ref instructionPointer, paramOnePointer, paramTwoPointer);
                }
                else if(instructionCode == Instructions.LessThan)
                {
                    var (paramOnePointer, paramTwoPointer, resultPointer) = this.DecodeParamsWithResult(instructionPointer);
                    this.memory.ExecuteLessThan(ref instructionPointer, paramOnePointer, paramTwoPointer, resultPointer);
                }
                else if(instructionCode == Instructions.Equals)
                {
                    var (paramOnePointer, paramTwoPointer, resultPointer) = this.DecodeParamsWithResult(instructionPointer);
                    this.memory.ExecuteEquals(ref instructionPointer, paramOnePointer, paramTwoPointer, resultPointer);
                }
                else if(instructionCode == Instructions.Halt)
                {
                    running = false;
                }
                else
                {
                    throw new Exception("Unknown instruction");
                }
            }

            return output;
        }

        private int DecodeParam(in int instructionPointer)
        {
            var paramPointer = instructionPointer + 1;

            if(this.memory[instructionPointer] % 1000 / 100 == 0)
            {
                paramPointer = this.memory[paramPointer];
            }

            return paramPointer;
        }

        private (int paramOnePointer, int paramTwoPointer) DecodeParams(in int instructionPointer)
        {
            var paramOnePointer = DecodeParam(instructionPointer);
            var paramTwoPointer = instructionPointer + 2;

            if(this.memory[instructionPointer] % 10000 / 1000 == 0)
            {
                paramTwoPointer = this.memory[paramTwoPointer];
            }

            return (paramOnePointer, paramTwoPointer);
        }

        private (int paramOnePointer, int paramTwoPointer, int resultPointer) DecodeParamsWithResult(in int instructionPointer)
        {
            var resultPointer = this.memory[instructionPointer + 3];
            var (paramOnePointer, paramTwoPointer) = DecodeParams(instructionPointer);

            return (paramOnePointer, paramTwoPointer, resultPointer);
        }
    }
}