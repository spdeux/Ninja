﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja
{
    public class FizzBuzz
    {
        public static string GetOutput(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";

            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Buzz";

            return number.ToString();
        }
    }
}
