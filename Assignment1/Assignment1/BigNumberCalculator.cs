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
            if (num.Length < 3)
            {
                return null;
            }

            foreach (var s in num)
            {
                if (s != '0' && s != '1' && s != 'b')
                {
                    return null;
                }
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
            if (num.Length < 3)
            {
                return null;
            }

            foreach (var n in num)
            {
                if (n != '0' && n != '1' && n != 'b')
                {
                    return null;
                }
            }

            char[] binaryNumber = num.ToCharArray(2, num.Length - 2);
            string output = string.Empty;

            for (int k = 0; k < binaryNumber.Length; k++)
            {
                if (binaryNumber[k] == '0')
                {
                    binaryNumber[k] = '1';
                }
                else
                {
                    binaryNumber[k] = '0';
                }
            }

            int i = binaryNumber.Length - 1;
            int s = 1;

            while (i >= 0)
            {
                s += (i >= 0) ? (binaryNumber[i] - '0') : 0;

                output = (char)(s % 2 + '0') + output;
                s /= 2;
                i--;
            }

            output = "0b" + output;

            return output;
        }

        public static string ToBinaryOrNull(string num)
        {
            if (num.Length < 3)
            {
                if(!int.TryParse(num, out int result))
                {
                    return null;
                }
            }

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
