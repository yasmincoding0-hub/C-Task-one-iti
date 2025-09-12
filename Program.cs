using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Display char
            Console.WriteLine("enter Your Char!");
            char mychar = Console.ReadKey().KeyChar;
            int asc = (int)mychar;
            Console.WriteLine("this is mychar  " + mychar + "  this is ASCII val " + asc);
            #endregion


            #region -Same program but vice versa.
            Console.WriteLine("Enter an ASCII value (0-255) ");
            int val = int.Parse(Console.ReadLine());
            char mychar1 = (char)val;
            Console.WriteLine($"The character for ASCII {val} is: '{mychar1}'");
            #endregion


            #region -A program to take a num from user and display odd or even based on this num. 
            Console.WriteLine("Enter Your num!");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                Console.WriteLine(" Your num is Even");
            }
            else
            {
                Console.WriteLine(" Your num Odd");
            }
            #endregion

            #region -A program to take two numbers and print the sum, subtraction, multiplication.
            Console.WriteLine("Enter Number one!");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number Two!");
            int num2 = int.Parse(Console.ReadLine());
            int sub = num1 - num2;
            int sum = num1 + num2;
            int multi = num1 * num2;
            Console.WriteLine("Substraction = " + sub + " ,Summation =" + sum + " ,Multiplaction= " + multi);
            #endregion

            #region -A program to take student degree and calculate grade
            Console.WriteLine("Enter Your degree!");
            double degree = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Total Course Mark!");
            int mark = int.Parse(Console.ReadLine());
            double presentage = (degree / mark) * 100;
            if (presentage >= 90)
            {
                Console.WriteLine("Your Degree is " + degree + " With presentage = " + presentage.ToString("F2") + "% Your Grade is A");
            }
            else if (presentage < 90 && presentage >= 80)
            {
                Console.WriteLine("Your Degree is " + degree + " With presentage = " + presentage.ToString("F2") + "% Your Grade is B");
            }
            else if (presentage < 80 && presentage >= 70)
            {
                Console.WriteLine("Your Degree is " + degree + " With presentage = " + presentage.ToString("F2") + "% Your Grade is B");
            }
            #endregion

            #region-Multiplication table
            Console.WriteLine("Enter The Number you Want to Get Multiplcation table for");
            int num3 = int.Parse(Console.ReadLine());
            int multi1 = 1;
            for (int i = 0; i <= 12; i++)
            {
                multi = num3 * i;
                Console.WriteLine(num3 + " * " + i + " = " + multi1);
            }
            #endregion

        }
    }
    }

