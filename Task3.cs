using System;

// (1) create class calc has sum, sub, mul, div with overloading
public class Calc
{
    public int Sum(int a, int b) => a + b;
    public double Sum(double a, double b) => a + b;

    public int Sub(int a, int b) => a - b;
    public double Sub(double a, double b) => a - b;

    public int Mul(int a, int b) => a * b;
    public double Mul(double a, double b) => a * b;

    public int Div(int a, int b) => b != 0 ? a / b : 0;
    public double Div(double a, double b) => b != 0 ? a / b : 0;
}

// (3) create question class (header , body , mark , show())
// (4) implement all constructors and property
public class Ques
{
    public string Head { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }

    public Ques() { }

    public Ques(string h, string b, int m)
    {
        Head = h;
        Body = b;
        Mark = m;
    }

    public virtual void Show()
    {
        Console.WriteLine("Header: " + Head);
        Console.WriteLine("Body: " + Body);
        Console.WriteLine("Mark: " + Mark);
    }
}

// (5) create mcq question : question + (+string[] choices)
public class MCQ : Ques
{
    public string[] Choices { get; set; }

    public MCQ() : base()
    {
        Choices = new string[0];
    }

    public MCQ(string h, string b, int m, string[] ch) : base(h, b, m)
    {
        Choices = ch;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine("Choices:");
        for (int i = 0; i < Choices.Length; i++)
        {
            Console.WriteLine("  " + (i + 1) + ". " + Choices[i]);
        }
    }
}

// (2) try all lec demo + (6) in main
class Program
{
    static void Main(string[] args)
    {
        // (2) try all lec demo
        Calc c = new Calc();
        Console.WriteLine("Calc Demo:");
        Console.WriteLine("5 + 3 = " + c.Sum(5, 3));
        Console.WriteLine("10 - 4 = " + c.Sub(10, 4));
        Console.WriteLine("6 * 2 = " + c.Mul(6, 2));
        Console.WriteLine("20 / 5 = " + c.Div(20, 5));

        // (6) in main : create object from mcq and print it
        string[] colors = { "Red", "Green", "Blue" };
        Ques q1 = new MCQ("Q1", "Pick a color:", 5, colors);
        q1.Show();

        // (6) in main : create array from mcq , take data from user and print it
        Console.Write("\nHow many MCQ? ");
        int n = int.Parse(Console.ReadLine() ?? "1");
        MCQ[] arr = new MCQ[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nEnter data for MCQ " + (i + 1) + ":");
            Console.Write("Header: ");
            string h = Console.ReadLine() ?? "";
            Console.Write("Body: ");
            string b = Console.ReadLine() ?? "";
            Console.Write("Mark: ");
            int m = int.Parse(Console.ReadLine() ?? "1");

            Console.Write("How many choices? ");
            int cNum = int.Parse(Console.ReadLine() ?? "1");
            string[] ch = new string[cNum];
            for (int j = 0; j < cNum; j++)
            {
                Console.Write("Choice " + (j + 1) + ": ");
                ch[j] = Console.ReadLine() ?? "";
            }

            arr[i] = new MCQ(h, b, m, ch);
        }

        Console.WriteLine("\n--- All MCQ ---");
        foreach (var item in arr)
        {
            item.Show();
            Console.WriteLine();
        }

        // (7) bonus - take answers from user and calc result
        int total = 0;
        int score = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("Your answer for Q" + (i + 1) + " (number): ");
            int ans = int.Parse(Console.ReadLine() ?? "1");

            if (ans == 1) score += arr[i].Mark; // assume correct is choice 1
            total += arr[i].Mark;
        }

        Console.WriteLine("\nResult: " + score + "/" + total);
        Console.WriteLine("Percent: " + c.Div(score * 100, total) + "%");
    }
}
