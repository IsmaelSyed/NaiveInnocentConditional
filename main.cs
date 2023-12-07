using System;

class Program
{
    static void Main()
    {
        int[] temperatures = new int[5];

        try
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter temperature: ");
                int temperature = int.Parse(Console.ReadLine());

                if (temperature < -30 || temperature > 130)
                {
                    throw new ArgumentOutOfRangeException($"Temperature {temperature} is invalid, Please enter a valid temperature between -30 and 130");
                }

                temperatures[i] = temperature;
            }

            DisplayComparisonResult(temperatures);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"EXCEPTION {ex.Message}");
        }
    }

    static void DisplayComparisonResult(int[] temperatures)
    {
        bool warmer = false;
        bool cooler = false;

        for (int i = 1; i < temperatures.Length; i++)
        {
            if (temperatures[i] > temperatures[i - 1])
            {
                warmer = true;
            }
            else if (temperatures[i] < temperatures[i - 1])
            {
                cooler = true;
            }
        }

        if (warmer && cooler)
        {
            Console.WriteLine("It's a mixed bag");
        }
        else if (warmer)
        {
            Console.WriteLine("Getting warmer");
        }
        else if (cooler)
        {
            Console.WriteLine("Getting colder");
        }

        Console.WriteLine($"5-day Temperature [{string.Join(", ", temperatures)}]");
        Console.WriteLine($"Average Temperature is {CalculateAverage(temperatures):F1} degrees");
    }

    static double CalculateAverage(int[] temperatures)
    {
        double sum = 0;

        foreach (int temperature in temperatures)
        {
            sum += temperature;
        }

        return sum / temperatures.Length;
    }
}
