using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Lab
{
    internal class Program
    {
        class Subject
        {
            public int Code { get; set; }
            public string Name { get; set; }
        }

        class Student
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Subject[] subjects { get; set; }
        }

        static void Main(string[] args)
        {
            // ===================== Question 1 =====================
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

            // Q1: Display numbers without any repeated Data and sorted
            var q1 = numbers.Distinct().OrderBy(n => n);
            Console.WriteLine("Q1: Distinct & Sorted Numbers");
            foreach (var num in q1) Console.WriteLine(num);

            // Q2: Using Q1 result and show each number and its multiplication
            var q2 = q1.Select(n => new { Number = n, Multiply = n * n });
            Console.WriteLine("\nQ2: Number and its Multiplication");
            foreach (var item in q2) Console.WriteLine($"{item.Number} => {item.Multiply}");


            // ===================== Question 2 =====================
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            // Q1: Select names with length equal 3
            var q3 = from n in names
                     where n.Length == 3
                     select n;
            Console.WriteLine("\nQ3: Names with length 3");
            foreach (var name in q3) Console.WriteLine(name);

            // Q2: Select names that contain "a" and sort them by length
            var q4 = names.Where(n => n.ToLower().Contains("a"))
                          .OrderBy(n => n.Length);
            Console.WriteLine("\nQ4: Names containing 'a' sorted by length");
            foreach (var name in q4) Console.WriteLine(name);

            // Q3: Display the first 2 names
            var q5 = names.Take(2);
            Console.WriteLine("\nQ5: First 2 Names");
            foreach (var name in q5) Console.WriteLine(name);


            // ===================== Question 3 =====================
            List<Student> students = new List<Student>()
            {
                new Student(){ ID=1, FirstName="Ali", LastName="Mohammed",
                    subjects=new Subject[]{ new Subject(){ Code=22,Name="EF"},
                                            new Subject(){ Code=33,Name="UML"}}},

                new Student(){ ID=2, FirstName="Mona", LastName="Gala",
                    subjects=new Subject []{ new Subject(){ Code=22,Name="EF"},
                                             new Subject(){ Code=34,Name="XML"},
                                             new Subject(){ Code=25, Name="JS"}}},

                new Student(){ ID=3, FirstName="Yara", LastName="Yousf",
                    subjects=new Subject []{ new Subject (){ Code=22,Name="EF"},
                                             new Subject (){ Code=25,Name="JS"}}},

                new Student(){ ID=1, FirstName="Ali", LastName="Ali",
                    subjects=new Subject []{  new Subject (){ Code=33,Name="UML"}}},
            };

            // Q1: Display Full name and number of subjects
            var q6 = students.Select(s => new
            {
                FullName = s.FirstName + " " + s.LastName,
                SubjectCount = s.subjects.Length
            });
            Console.WriteLine("\nQ6: Full Name & Subjects Count");
            foreach (var st in q6) Console.WriteLine($"{st.FullName} => {st.SubjectCount}");

            // Q2: Order by FirstName Desc then LastName Asc
            var q7 = students.OrderByDescending(s => s.FirstName)
                             .ThenBy(s => s.LastName)
                             .Select(s => new { s.FirstName, s.LastName });
            Console.WriteLine("\nQ7: Ordered Students");
            foreach (var st in q7) Console.WriteLine($"{st.FirstName} {st.LastName}");

            // Q3: Display each student and student’s subject (SelectMany)
            var q8 = students.SelectMany(s => s.subjects,
                                         (s, subj) => new { StudentName = s.FirstName, SubjectName = subj.Name });
            Console.WriteLine("\nQ8: Student with Subjects");
            foreach (var item in q8) Console.WriteLine($"{item.StudentName} => {item.SubjectName}");

            // BONUS: GroupBy Subject
            var q9 = students.SelectMany(s => s.subjects,
                                         (s, subj) => new { s.FirstName, subj.Name })
                             .GroupBy(x => x.Name);
            Console.WriteLine("\nBONUS: Group by Subject");
            foreach (var group in q9)
            {
                Console.WriteLine($"Subject: {group.Key}");
                foreach (var st in group) Console.WriteLine($"   {st.FirstName}");
            }
        }
    }
}
