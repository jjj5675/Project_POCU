using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        public BigNumberCalculator(int bitCount, EMode mode)
        {
        }

        public static string GetOnesComplementOrNull(string num)
        {
            char[] binaryIdentifier = num.ToCharArray(0, 1);

            if (!binaryIdentifier.Equals("0b"))
            {
                return null;
            }

            char[] binaryNumber = num.ToCharArray(2, num.Length - 2);
            string output = "0b";

            foreach (var c in binaryNumber)
            {
                if (c == '0')
                {
                    output += "1";
                }
                else
                {
                    output += "0";
                }
            }

            return output;
        }

        public static string GetTwosComplementOrNull(string num)
        {
            return null;
        }

        public static string ToBinaryOrNull(string num)
        {
            return null;
        }

        public static string ToHexOrNull(string num)
        {
            return null;
        }

        public static string ToDecimalOrNull(string num)
        {
            return null;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }
    }
}
