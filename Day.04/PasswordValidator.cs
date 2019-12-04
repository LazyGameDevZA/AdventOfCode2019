using System;
using System.Collections.Generic;
using System.Linq;

namespace Day._04
{
    public static class PasswordValidator
    {
        private static readonly List<int> repeatsFound = new List<int>(3);
        public static bool Validate(int password)
        {
            repeatsFound.Clear();
            var ascending = true;
            var passwordString = password.ToString();
            var previousChar = passwordString[0];
            var counter = 1;
            for(int i = 1; i < passwordString.Length && ascending; i++)
            {
                var currentChar = passwordString[i];

                ascending &= currentChar >= previousChar;

                var isDouble = currentChar == previousChar;
                if(isDouble)
                {
                    counter++;
                }

                if((!isDouble || i == passwordString.Length - 1) && counter > 1)
                {
                    repeatsFound.Add(counter);
                }

                if(!isDouble)
                {
                    previousChar = currentChar;
                    counter = 1;
                }
            }
            
            return ascending && repeatsFound.Any(x => x == 2);
        }
    }
}
