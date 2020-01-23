using System;
using System.Linq;

namespace LCReverseInteger1
{
    class Program
    {
        public class Solution
        {
            public int Reverse(int x)
            {

                //added a try-catch block to account for any numbers that are too large and overflow
                try
                {

                    //barbaric way to account for negative numbers, but it works. We have to remove
                    //the negative sign before doing the int/string conversions or it'll just return 0
                    bool negativeNumber = false;

                    //if it's negative, make it positive and mark the flag to add a negative sign later
                    //note: max negative value will overflow on Math.abs(), but the problem just wants
                    //a 0 returned if the number overflows, so the try-catch block works
                    if (x < 0)
                    {
                        x = Math.Abs(x);
                        negativeNumber = true;
                    }

                    //convert the number to a string and reverse it.
                    //string.Concat() is necessary because the Linq Reverse() method will return a char[] here
                    string reversedString = string.Concat(x.ToString().Reverse());

                    //remove leading zeroes and then convert it back to an integer
                    reversedString.TrimStart('0');

                    int.TryParse(reversedString, out int reversedNumber);

                    //if the number was originally negative, turn it back to a negative
                    if (negativeNumber)
                    {
                        reversedNumber *= -1;
                    }

                    return reversedNumber;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
