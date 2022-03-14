using Humanizer;
using System.Diagnostics;

static void HumanizeQuants() {
    Console.WriteLine("case".ToQuantity(0));
    Console.WriteLine("case".ToQuantity(1));
    Console.WriteLine("case".ToQuantity(2));
    Console.WriteLine("case".ToQuantity(5));
}

static void HumanizeDates() {
    Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
    Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
    Console.WriteLine(TimeSpan.FromDays(1).Humanize());
    Console.WriteLine(TimeSpan.FromDays(16).Humanize());
}

Console.WriteLine("Qunats:");
HumanizeQuants();

Console.WriteLine("\nDate/Time Manipulation:");
HumanizeDates();

// debugging example
Console.WriteLine("\nDebugging Example: ");
int result = Fibonacci(5);
Console.WriteLine(result);

static int Fibonacci(int n)
{
    Debug.WriteLine($"Entering {nameof(Fibonacci)} method");
    Debug.WriteLine($"We are looking for the {n}th number");

    int n1 = 0;
    int n2 = 1;
    int sum;

    for (int i = 2; i < n+1; i++)
    {
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
        Debug.WriteIf(sum==1, $"sum is 1, n1 is {n1} and n2 is {n2}");
    }

    return n == 0 ? n1 : n2;
}