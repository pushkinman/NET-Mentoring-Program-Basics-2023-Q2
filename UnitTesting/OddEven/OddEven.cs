
public class OddEven
{
    public string PrintNumber(int number)
    {
        if (IsEven(number))
        {
            return "Even";
        }
        else if (IsPrime(number))
        {
            return "Prime";
        }
        else
        {
            return "Odd";
        }
    }

    private bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    private bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}