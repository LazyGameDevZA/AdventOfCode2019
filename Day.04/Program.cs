using System;
using System.Collections.Generic;
using System.Linq;

namespace Day._04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");

            var passwordRange = args[0].Split('-');
            var low = int.Parse(passwordRange[0]);
            var high = int.Parse(passwordRange[1]);

            var matchCount = 0;

            for(int item = low; item <= high; item++)
            {
                var result = PasswordValidator.Validate(item);

                if(result)
                {
                    Console.WriteLine(item);
                    matchCount++;
                }
            }
            
            Console.WriteLine($"Matching passwords found: {matchCount}");
            
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}
