using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using AoC2023.Days;

namespace AoC2023;

public static class Program
{
    public static void Main(string[] args)
    {
        var stopwatch = Stopwatch.StartNew();
        
        var days = new List<(string, IDay)>
        {
            ("Day 01", new D01()),
            ("Day 02", new D02())   
        };
        
        foreach (var (s, day) in days)
        {
            // Warmup runs
            day.P1(); day.P2();
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"--------------------------{s}--------------------------");
            Console.ResetColor();
            
            lock(day){
                ExecuteAndMeasure(day.P1, " Part 1"); 
                ExecuteAndMeasure(day.P2, " Part 2");
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("----------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Total Elapsed Time: {stopwatch.Elapsed.TotalMilliseconds}ms");
    }
    
    private static void ExecuteAndMeasure(Func<object> action, string part)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = action.Invoke();
        stopwatch.Stop();
            
        var formattedResult = $"{part}: {result, -10}";
        Console.WriteLine($"{formattedResult, 10}{ "Elapsed Time:", 30} {stopwatch.Elapsed.TotalMilliseconds, 0}ms");
    }
}