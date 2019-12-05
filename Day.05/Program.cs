using System;
using System.Linq;

namespace Day._05
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialState = args[0].Split(',').Select(int.Parse).ToArray();
            
            Console.WriteLine("--------------------------------------------------------------------------------------");

            var memory = new int[initialState.Length].AsSpan();

            initialState.CopyTo(memory);
            var computerOne = new IntComputer(memory, 1);

            var outputOne = computerOne.Run();
            
            Console.WriteLine($"Output for input 1: {outputOne}");

            initialState.CopyTo(memory);
            var computerFive = new IntComputer(memory, 5);

            var outputFive = computerFive.Run();
            
            Console.WriteLine($"Output for input 5: {outputFive}");
            
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}
