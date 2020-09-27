using System.Globalization;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        private int mBitCount;
        private EMode mMode;

        public BigNumberCalculator(int bitCount, EMode mode)
        {
            mBitCount = bitCount;
            mMode = mode;
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
            if (num.Length > 1)
            {
                if (num[0] == '0')
                {
                    if (num[1] != 'b' && num[1] != 'x')
                    {
                        return null;
                    }
                }
                else if (num[0] == '-')
                {
                    string decimalNum = "123456789";
                    if (!decimalNum.Contains(num[1]))
                    {
                        return null;
                    }
                }
                else if (num[0] == '+')
                {
                    return null;
                }
            }
            else if (num.Length == 1 && num[0] == '0')
            {
                return "0b0";
            }
            else
            {
                return null;
            }

            if (num[1] == 'b')
            {
                char[] vs1 = num.ToCharArray(2, num.Length - 2);

                if (vs1.Length == 0)
                {
                    return null;
                }

                foreach (var b in vs1)
                {
                    if (b != '0' && b != '1')
                    {
                        return null;
                    }
                }
            }
            else if (num[1] == 'x')
            {
                char[] vs1 = num.ToCharArray(2, num.Length - 2);

                if (vs1.Length == 0)
                {
                    return null;
                }

                string hexNum = "0123456789abcdefABCDEF";

                foreach (var h in vs1)
                {
                    if (!hexNum.Contains(h))
                    {
                        return null;
                    }
                }
            }

            string numberCompare = "0123456789abcdefABCDEF+-";

            foreach (var c in num)
            {
                if (!numberCompare.Contains(c))
                {
                    return null;
                }
            }

            if (num.Contains("0b"))
            {
                return num;
            }
            else if (num.Contains("0x"))
            {
                char[] numberData = num.ToCharArray(2, num.Length - 2);
                string output = string.Empty;
                int value = 0;
                string remainder = string.Empty;

                foreach (var c in numberData)
                {
                    if (c >= '0' && c <= '9')
                    {
                        value = c - '0';
                    }
                    else if (c >= 'a' && c <= 'f')
                    {
                        value = 10 + c - 'a';
                    }
                    else if (c >= 'A' && c <= 'F')
                    {
                        value = 10 + c - 'A';
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (value >= 2)
                        {
                            remainder = (value % 2) + remainder;
                            value /= 2;
                        }
                        else
                        {
                            remainder = value + remainder;
                            value /= 2;
                        }
                    }

                    output = output + remainder;
                    remainder = string.Empty;
                }

                output = "0b" + output;

                return output;
            }
            else if (int.TryParse(num, out int result))
            {
                string output = string.Empty;
                int value = System.Math.Abs(result);

                while (value > 0)
                {
                    output = (value % 2) + output;
                    value /= 2;
                }

                output = "0b0" + output;

                if (result < 0)
                {
                    return GetTwosComplementOrNull(output);
                }

                return output;
            }

            return null;

            //else
            //{
            //    char[] data;

            //    if (num[0] != '-')
            //    {
            //        data = num.ToCharArray();
            //    }
            //    else
            //    {
            //        data = num.ToCharArray(1, num.Length - 1);
            //    }

            //    string output = string.Empty;
            //    string quotient = string.Empty;
            //    int value = 0;
            //    int powerOfTen = 10;
            //    int i = 0;

            //    do
            //    {
            //        if (value < 2)
            //        {
            //            if (data.Length - 1 < i)
            //            {
            //                if (quotient.Length == 1 && quotient[0] == '1')
            //                {
            //                    output = value + output;
            //                    output = quotient[0] + output;
            //                    break;
            //                }

            //                if (value == 1 && data[data.Length - 1] == '1' && ((data[data.Length - 2] - '0') % 2) == 0)
            //                {
            //                    quotient = quotient + (value / 2);
            //                    value %= 2;
            //                }

            //                if (quotient.Length != 0)
            //                {
            //                    data.Initialize();
            //                    data = quotient.ToCharArray();
            //                    quotient = string.Empty;
            //                    output = value + output;
            //                    value = i = 0;
            //                }
            //            }

            //            if (value == 0 && data[i] == '0')
            //            {
            //                quotient = quotient + '0';
            //                i++;
            //                continue;
            //            }

            //            if (quotient.Length < i)
            //            {
            //                quotient = quotient + '0';
            //            }
            //            value *= powerOfTen;
            //            value += data[i] - '0';
            //            i++;
            //            continue;
            //        }

            //        quotient = quotient + (value / 2);
            //        value %= 2;

            //    } while (true);

            //    output = "0b0" + output;

            //    if (num[0] == '-')
            //    {
            //        return GetTwosComplementOrNull(output);
            //    }

            //    return output;
            //}
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
