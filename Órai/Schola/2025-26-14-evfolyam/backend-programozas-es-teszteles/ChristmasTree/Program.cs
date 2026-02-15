using System;

class Program
{
    static void Main(string[] args)
    {
        Triangle ob = new Triangle();
        ob.CreateTriangle();
        Console.ReadLine();
    }
}

class Triangle
{
    public void CreateTriangle()
    {
        Console.Write("Írd be a háromszögek számát: ");

        int n = int.Parse(Console.ReadLine());
        int center = Console.WindowWidth / 2;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                string branch = new string('*', j);

                Console.ForegroundColor = ConsoleColor.Green;

                int width = 2 * j + 1;
                int leftPadding = center - (width / 2);

                string leaves = new string('*', width);
                Console.WriteLine(new string(' ', leftPadding) + leaves);
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new string(' ', center) + "|");
        }

        Console.ResetColor();
    }
}
