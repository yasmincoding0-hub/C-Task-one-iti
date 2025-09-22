using System;

// #1 - Create Product Anonymous Object
class Product
{
    public string name;
    public double price;
}

class Program
{
    // method to create anonymous product
    static Product createProduct()
    {
        // return anonymous product
        return new Product { name = "Burger", price = 50.0 };
    }

    static void Main(string[] args)
    {
        // call method and print product
        var product = createProduct();
        Console.WriteLine("Product Name: " + product.name);
        Console.WriteLine("Product Price: " + product.price);

        // #2 - Extension Method String Word Count
        string text = "Hello, world!";
        Console.WriteLine("Word Count: " + text.WordCount());

        // #3 - Extension Method Int IsEven
        int number = 10;
        Console.WriteLine("Is Even: " + number.IsEven());

        // #4 - Extension Method DateTime Age
        DateTime birthDate = new DateTime(2000, 5, 1);
        Console.WriteLine("Age: " + birthDate.GetAge());

        // #5 - Extension Method String Reverse
        string word = "hello";
        Console.WriteLine("Reverse: " + word.ReverseText());
    }
}

// #2 - Extension Method for String (Word Count)
public static class StringExtensions
{
    public static int WordCount(this string str)
    {
        // split by space and punctuation
        return str.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

// #3 - Extension Method for Int (Is Even)
public static class IntExtensions
{
    public static bool IsEven(this int num)
    {
        return num % 2 == 0;
    }
}

// #4 - Extension Method for DateTime (Get Age)
public static class DateTimeExtensions
{
    public static int GetAge(this DateTime birthDate)
    {
        DateTime today = DateTime.Now;
        int age = today.Year - birthDate.Year;
        if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day))
        {
            age--;
        }
        return age;
    }
}

// #5 - Extension Method for String (Reverse)
public static class ReverseStringExtension
{
    public static string ReverseText(this string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
