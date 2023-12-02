using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2023.Days;

public class D01 : IDay
{
    private readonly string[] _input;
    private static readonly Regex NumbersRegex = new Regex("[^0-9]", RegexOptions.Compiled);

    public D01()
    {
        var filePath = Path.Combine("Data", "Day01");
        _input = File.ReadAllLines(filePath);
    }

    public object P1()
    {
        return _input.AsParallel().Sum(line => int.Parse(ExtractNumbers(line)));
    }
    
    public object P2()
    {
        return _input.AsParallel().Sum(line => int.Parse(ExtractNumbers(ReplaceNumbersWithDigits(line))));
    }

    private static string ReplaceNumbersWithDigits(string input)
    {
        var parsed = input.Replace("one", "o1e");
            parsed = parsed.Replace("two", "t2o"); 
            parsed = parsed.Replace("three", "t3e");
            parsed = parsed.Replace("four", "f4r");
            parsed = parsed.Replace("five", "f5e");
            parsed = parsed.Replace("six", "s6x"); 
            parsed = parsed.Replace("seven", "s7n"); 
            parsed = parsed.Replace("eight", "e8t"); 
            parsed = parsed.Replace("nine", "n9e");

        return parsed;
    }
    
    private static string ExtractNumbers(string input)
    {
        var numbers = NumbersRegex.Replace(input, "").ToCharArray();
        return $"{numbers.First()}{numbers.Last()}";
    }
}