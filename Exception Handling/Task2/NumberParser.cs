using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue is null)
            {
                throw new ArgumentNullException(nameof(stringValue), "Input cannot be null.");
            }

            stringValue = stringValue.Trim();

            if (stringValue.Length == 0)
            {
                throw new FormatException("Input cannot be empty.");
            }

            int result = 0;
            bool isNegative = false;
            int startIndex = 0;

            if (stringValue[0] == '-')
            {
                isNegative = true;
                startIndex = 1;
            }
            else if (stringValue[0] == '+')
            {
                startIndex = 1;
            }

            for (int i = startIndex; i < stringValue.Length; i++)
            {
                if (char.IsDigit(stringValue[i]))
                {
                    int digit = stringValue[i] - '0';
                    checked
                    {
                        result = (result * 10) + digit;
                    }
                }
                else
                {
                    throw new FormatException("Invalid character found in input.");
                }
            }

            return isNegative ? -result : result;
        }
    }
}