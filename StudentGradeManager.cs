using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public List<double> Grades { get; set; }

    public Student(string name)
    {
        Name = name;
        Grades = new List<double>();
    }

    public double CalculateAverage()
    {
        return Grades.Count > 0 ? Grades.Average() : 0;
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        Console.WriteLine("Student Grade Management System");
        Console.WriteLine("-----------------------------");

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Add new student");
            Console.WriteLine("2. Add grades for a student");
            Console.WriteLine("3. View student grades");
            Console.WriteLine("4. View class average");
            Console.WriteLine("5. Exit");

            Console.Write("\nEnter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AddGrades();
                    break;
                case "3":
                    ViewStudentGrades();
                    break;
                case "4":
                    ViewClassAverage();
                    break;
                case "5":
                    Console.WriteLine("\nThank you for using the Student Grade Manager. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a number between 1 and 5.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("\nEnter student name: ");
        string name = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name. Student not added.");
            return;
        }

        if (students.Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("A student with this name already exists.");
            return;
        }

        students.Add(new Student(name));
        Console.WriteLine($"Student '{name}' has been added successfully.");
    }

    static void AddGrades()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students registered yet.");
            return;
        }

        Console.Write("\nEnter student name: ");
        string name = Console.ReadLine();
        
        Student student = students.FirstOrDefault(s => 
            s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter grade (0-100): ");
        if (double.TryParse(Console.ReadLine(), out double grade))
        {
            if (grade >= 0 && grade <= 100)
            {
                student.Grades.Add(grade);
                Console.WriteLine("Grade added successfully.");
            }
            else
            {
                Console.WriteLine("Grade must be between 0 and 100.");
            }
        }
        else
        {
            Console.WriteLine("Invalid grade format.");
        }
    }

    static void ViewStudentGrades()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students registered yet.");
            return;
        }

        Console.Write("\nEnter student name: ");
        string name = Console.ReadLine();
        
        Student student = students.FirstOrDefault(s => 
            s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        if (student.Grades.Count == 0)
        {
            Console.WriteLine($"{student.Name} has no grades yet.");
            return;
        }

        Console.WriteLine($"\nGrades for {student.Name}:");
        for (int i = 0; i < student.Grades.Count; i++)
        {
            Console.WriteLine($"Grade {i + 1}: {student.Grades[i]}");
        }
        Console.WriteLine($"Average: {student.CalculateAverage():F2}");
    }

    static void ViewClassAverage()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students registered yet.");
            return;
        }

        var studentsWithGrades = students.Where(s => s.Grades.Count > 0).ToList();
        
        if (studentsWithGrades.Count == 0)
        {
            Console.WriteLine("No grades have been recorded yet.");
            return;
        }

        double classAverage = studentsWithGrades.Average(s => s.CalculateAverage());
        Console.WriteLine($"\nClass Average: {classAverage:F2}");
        
        Console.WriteLine("\nIndividual Averages:");
        foreach (var student in studentsWithGrades.OrderByDescending(s => s.CalculateAverage()))
        {
            Console.WriteLine($"{student.Name}: {student.CalculateAverage():F2}");
        }
    }
}