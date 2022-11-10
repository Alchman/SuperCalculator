using System.Text.RegularExpressions;

public class SumCalculator : ICalculator
{
    private static char StringSeparator = '+';
    private static string InputRegexp = "^\\d+[+]\\d+$";

    private Regex _regex;

    public SumCalculator()
    {
        _regex = new Regex(InputRegexp);
    }

    public bool TryCalculate(string inputString, out float result)
    {
        bool isInputValid = _regex.Match(inputString).Success;
        result = 0;
        if (!isInputValid)
        {
            return false;
        }

        int sum;
        bool success = TryParseAndSumNumbers(inputString, out sum);
        if (!success)
        {
            return false;
        }

        result = sum;
        return true;
    }

    private bool TryParseAndSumNumbers(string inputString, out int sum)
    {
        sum = 0;
        string[] numbers = inputString.Split(StringSeparator);
        foreach (var number in numbers)
        {
            int parsedValue;
            bool parsed = int.TryParse(number, out parsedValue);
            if (!parsed)
            {
                return false;
            }
            sum += parsedValue;
        }
        return true;
    }
}
