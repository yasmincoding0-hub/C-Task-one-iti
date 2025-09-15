using System;
using System.Collections.Generic;

// ---------------- Static ID Generator ----------------
public static class IdGenerator
{
    private static int _counter = 0;
    public static int GenerateId() => ++_counter;
}

// ---------------- Grade Class ----------------
public class Grade
{
    public int Value { get; set; }
    public Grade(int value) => Value = value;

    // Add two grades
    public static Grade operator +(Grade g1, Grade g2) => new Grade(g1.Value + g2.Value);

    // Compare two grades
    public static bool operator ==(Grade g1, Grade g2)
    {
        if (g1 == null && g2 == null) return true;
        if (g1 == null || g2 == null) return false;
        return g1.Value == g2.Value;
    }
    public static bool operator !=(Grade g1, Grade g2) => !(g1 == g2);

    public override bool Equals(object obj) => obj is Grade g && g.Value == Value;
    public override int GetHashCode() => Value.GetHashCode();
}

// ---------------- Course Level Enum ----------------
public enum CourseLevel { Beginner, Intermediate, Advanced }

// ---------------- Person Base Class ----------------
public abstract class Person
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Id = IdGenerator.GenerateId();
        Name = name;
        Age = age;
    }

    public abstract void Introduce();
}

// ---------------- Instructor Class ----------------
public class Instructor : Person
{
    public List<Course> CoursesTeaching { get; private set; } = new List<Course>();

    public Instructor(string name, int age) : base(name, age) { }

    public void TeachCourse(Course course)
    {
        CoursesTeaching.Add(course);
        course.Instructor = this;
    }

    public override void Introduce() => Console.WriteLine($"Hi, I am {Name}, a teacher.");
}

// ---------------- Student Class ----------------
public class Student : Person
{
    public List<Course> CoursesEnrolled { get; private set; } = new List<Course>();
    public List<Grade> Grades { get; private set; } = new List<Grade>();

    public Student(string name, int age) : base(name, age) { }

    public void RegisterCourse(Course course)
    {
        CoursesEnrolled.Add(course);
        course.Students.Add(this);

        string message = course.Level switch
        {
            CourseLevel.Beginner => "Good luck starting out!",
            CourseLevel.Intermediate => "Keep it up!",
            CourseLevel.Advanced => "This will be challenging!",
            _ => ""
        };

        Console.WriteLine($"{Name} registered in {course.Name}: {message}");
    }

    public override void Introduce() => Console.WriteLine($"Hi, I am {Name}, a learner.");
}

// ---------------- Course Class ----------------
public class Course
{
    public string Name { get; set; }
    public CourseLevel Level { get; set; }
    public Instructor Instructor { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    public Course(string name, CourseLevel level)
    {
        Name = name;
        Level = level;
    }
}

// ---------------- Department Class ----------------
public class Department
{
    public string Name { get; set; }
    public List<Person> Employees { get; set; } = new List<Person>();

    public Department(string name) { Name = name; }
}

// ---------------- Company Class ----------------
public class Company
{
    public string Name { get; set; }
    public List<Department> Departments { get; set; } = new List<Department>();

    public Company(string name) { Name = name; }
}

// ---------------- Shape Interface and Classes ----------------
public interface IDrawable { void Draw(); }

public abstract class Shape : IDrawable
{
    public abstract double Area();
    public abstract void Draw();
}

public class Circle : Shape
{
    public double Radius;
    public Circle(double r) { Radius = r; }

    public override double Area() => Math.PI * Radius * Radius;
    public override void Draw() => Console.WriteLine($"Drawing Circle radius {Radius}");
}

public class Rectangle : Shape
{
    public double Width, Height;
    public Rectangle(double w, double h) { Width = w; Height = h; }

    public override double Area() => Width * Height;
    public override void Draw() => Console.WriteLine($"Drawing Rectangle {Width}x{Height}");
}

// ---------------- Car and Engine (Composition) ----------------
public class Engine
{
    public string Model { get; set; }
    public Engine(string model) => Model = model;
}

public class Car
{
    public string Make { get; set; }
    public Engine Engine { get; set; }

    public Car(string make, string engineModel)
    {
        Make = make;
        Engine = new Engine(engineModel);
    }
}

// ---------------- Main Program ----------------
class Program
{
    static void Main()
    {
        // --- Create Company & Departments ---
        Company myCompany = new Company("Tech Corp");
        Department devDept = new Department("Development");
        Department hrDept = new Department("HR");
        myCompany.Departments.Add(devDept);
        myCompany.Departments.Add(hrDept);

        // --- Create Instructors ---
        Instructor inst1 = new Instructor("Dr. Ali", 45);
        Instructor inst2 = new Instructor("Dr. Mona", 40);
        devDept.Employees.Add(inst1);
        devDept.Employees.Add(inst2);

        // --- Create Courses ---
        Course c1 = new Course("C# Programming", CourseLevel.Beginner);
        Course c2 = new Course("Algorithms", CourseLevel.Advanced);
        inst1.TeachCourse(c1);
        inst2.TeachCourse(c2);

        // --- Create Students ---
        Student s1 = new Student("Ahmed", 20);
        Student s2 = new Student("Sara", 21);
        devDept.Employees.Add(s1);
        hrDept.Employees.Add(s2);

        // --- Students register courses ---
        s1.RegisterCourse(c1);
        s1.RegisterCourse(c2);
        s2.RegisterCourse(c2);

        // --- Assign grades ---
        s1.Grades.Add(new Grade(80));
        s1.Grades.Add(new Grade(90));
        s2.Grades.Add(new Grade(95));

        // --- Demonstrate Grade operators ---
        Grade totalS1 = new Grade(0);
        foreach (var g in s1.Grades) totalS1 += g;

        Console.WriteLine($"\nTotal grade for {s1.Name}: {totalS1.Value}");
        Console.WriteLine($"Are first two grades equal? {s1.Grades[0] == s1.Grades[1]}");

        // --- Students Report ---
        Console.WriteLine("\n--- Students Report ---");
        foreach (var dept in myCompany.Departments)
            foreach (var emp in dept.Employees)
                if (emp is Student st)
                    Console.WriteLine($"Student: {st.Name}, Dept: {dept.Name}, Courses: {string.Join(", ", st.CoursesEnrolled.ConvertAll(c => c.Name))}, Total Grades: {totalS1.Value}");

        // --- Instructors Report ---
        Console.WriteLine("\n--- Instructors Report ---");
        foreach (var dept in myCompany.Departments)
            foreach (var emp in dept.Employees)
                if (emp is Instructor instr)
                    Console.WriteLine($"Instructor: {instr.Name}, Courses Teaching: {string.Join(", ", instr.CoursesTeaching.ConvertAll(c => c.Name))}");

        // --- Departments Report ---
        Console.WriteLine("\n--- Departments Report ---");
        foreach (var dept in myCompany.Departments)
            Console.WriteLine($"Department: {dept.Name}, Employees Count: {dept.Employees.Count}");

        // --- Shapes ---
        List<Shape> shapes = new List<Shape> { new Circle(5), new Rectangle(4, 6) };
        Console.WriteLine("\n--- Shapes Report ---");
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Area: {shape.Area()}");
            shape.Draw();
        }

        // --- Car & Engine ---
        Car myCar = new Car("Toyota", "V6");
        Console.WriteLine($"\nCar Make: {myCar.Make}, Engine Model: {myCar.Engine.Model}");
    }
}
