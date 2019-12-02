using System;
using System.Linq;

namespace Day._02
{ 
    static class Program
    {
        static void Main(string[] args)
        {
            var initialState = args[0].Split(',').Select(int.Parse).ToArray();
            var expectedOutput = 19690720;
            
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine($"Finding verb and noun that generates output: {expectedOutput}");

            var input = FindInputToMatch(initialState, expectedOutput);
            
            Console.WriteLine($"Matched input: {100 * input.noun + input.verb}");
            
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }

        private static (int noun, int verb) FindInputToMatch(ReadOnlySpan<int> initialState, int output)
        {

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    var memory = new int[initialState.Length].AsSpan();

                    initialState.CopyTo(memory);

                    memory[1] = noun;
                    memory[2] = verb;

                    var computer = new IntComputer(memory);
            
                    computer.Run();

                    if (memory[0] == output)
                    {
                        return (noun, verb);
                    }
                }
            }

            throw new Exception($"No matching Noun and Verb found for output {output}");
        }
    }
}