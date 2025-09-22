using System;
using System.Collections;
using System.Collections.Generic;

// Q1: Optimized Bubble Sort
class BubbleSortExample
{
    public static void OptimizedBubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break; // stop if array already sorted
        }
    }
}

// Q2: Generic Range<T> Class
public class Range<T> where T : IComparable<T>
{
    private T min;
    private T max;

    public Range(T min, T max)
    {
        this.min = min;
        this.max = max;
    }

    public bool IsInRange(T value)
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }

    public dynamic Length()
    {
        return (dynamic)max - (dynamic)min;
    }
}

// Q3: Reverse ArrayList In-Place
class ReverseArrayList
{
    public static void Reverse(ArrayList arr)
    {
        int left = 0, right = arr.Count - 1;
        while (left < right)
        {
            object temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
    }
}

// Q4: Filter Even Numbers
class EvenNumbersFilter
{
    public static List<int> GetEvenNumbers(List<int> numbers)
    {
        List<int> evenList = new List<int>();
        foreach (int num in numbers)
        {
            if (num % 2 == 0)
                evenList.Add(num);
        }
        return evenList;
    }
}

// Q5: FixedSizeList<T>
public class FixedSizeList<T>
{
    private T[] items;
    private int count;

    public FixedSizeList(int capacity)
    {
        items = new T[capacity];
        count = 0;
    }

    public void Add(T item)
    {
        if (count >= items.Length)
            throw new InvalidOperationException("List is full!");
        items[count++] = item;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException("Invalid index!");
        return items[index];
    }
}

// Q6: First Non-Repeated Character
class FirstUniqueChar
{
    public static int FirstNonRepeatedIndex(string str)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();

        foreach (char c in str)
        {
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict[c] = 1;
        }

        for (int i = 0; i < str.Length; i++)
        {
            if (dict[str[i]] == 1)
                return i;
        }
        return -1;
    }
}

// Main Program to Test
class Program
{
    static void Main()
    {
        // Q1 test
        int[] arr = { 5, 3, 8, 4, 2 };
        BubbleSortExample.OptimizedBubbleSort(arr);
        Console.WriteLine("Q1 Sorted: " + string.Join(", ", arr));

        // Q2 test
        Range<int> range = new Range<int>(10, 20);
        Console.WriteLine("Q2 Is 15 in range? " + range.IsInRange(15));
        Console.WriteLine("Q2 Length: " + range.Length());

        // Q3 test
        ArrayList list = new ArrayList() { 1, 2, 3, 4, 5 };
        ReverseArrayList.Reverse(list);
        Console.Write("Q3 Reversed: ");
        foreach (var item in list) Console.Write(item + " ");
        Console.WriteLine();

        // Q4 test
        List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6 };
        var evenNums = EvenNumbersFilter.GetEvenNumbers(nums);
        Console.WriteLine("Q4 Even Numbers: " + string.Join(", ", evenNums));

        // Q5 test
        FixedSizeList<string> fixedList = new FixedSizeList<string>(2);
        fixedList.Add("Hello");
        fixedList.Add("World");
        Console.WriteLine("Q5 First item: " + fixedList.Get(0));

        // Q6 test
        string str = "swiss";
        Console.WriteLine("Q6 First non-repeated index: " + FirstUniqueChar.FirstNonRepeatedIndex(str));
    }
}
