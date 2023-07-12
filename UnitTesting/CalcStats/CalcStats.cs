namespace CalcStats
{
    public class CalcStats
    {
        public int MinValue(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Invalid input. The array cannot be null or empty.");
            }

            return numbers.Min();
        }

        public int MaxValue(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Invalid input. The array cannot be null or empty.");
            }

            return numbers.Max();
        }

        public int NumberOfElements(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentException("Invalid input. The array cannot be null.");
            }

            return numbers.Length;
        }

        public double AverageValue(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Invalid input. The array cannot be null or empty.");
            }

            return numbers.Average();
        }
    }
}