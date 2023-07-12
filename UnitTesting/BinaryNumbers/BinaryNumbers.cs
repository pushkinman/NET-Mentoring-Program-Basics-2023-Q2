namespace BinaryNumbers
{
    public class BinaryNumbers
    {
        public int CountValidSequences(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Invalid input. The length of the sequence should be greater than 0.");
            }

            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 2;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
    }
}