using System;
using System.Data.Common;
using System.Numerics;
using System.Xml.Linq;
using Interface;
using service;


class Program
{
    static void Main()
    {
        menu();
    }
    
    static void menu()
    {
        IStudentService student = new StudentService();
        while (true)
        {
            Console.WriteLine("Welcome to student management app!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Update a student");
            Console.WriteLine("3. Delete a student");
            Console.WriteLine("4. View all students");
            Console.WriteLine("5. View selected student via ID");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Please input one of these number to use our service!");

            int input = student.ConvertInteger(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("What's that student's ID?");
                    int id = student.ConvertInteger(Console.ReadLine());
                    if (id == -1) break;
                    Console.WriteLine("What's that student's name?");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("What's that student's age?");
                    int age = student.ConvertInteger(Console.ReadLine());
                    if (age == -1) break;
                    Console.WriteLine("What's that student's GPA?");
                    double grade = student.ConvertDouble(Console.ReadLine());
                    if (grade == -1) break;
                    student.AddStudent(new Student(id, studentName, age, grade));
                    break;
                case 2:
                    Console.WriteLine("Which student do u want to update?");
                    int ID = student.ConvertInteger(Console.ReadLine());
                    if (ID == -1) break;
                    Console.WriteLine("what's the new name?");
                    string Name = Console.ReadLine();
                    Console.WriteLine("what's the new age?");
                    int Age = student.ConvertInteger(Console.ReadLine());
                    if (Age == -1) break;
                    Console.WriteLine("what's the new grade?");
                    double GPA = student.ConvertDouble(Console.ReadLine());
                    if (GPA == -1) break;
                    student.UpdateStudent(new Student(ID, Name, Age, GPA));
                    break;
                case 3:
                    Console.WriteLine("Which student do u want to delete?");
                    int deleteID = student.ConvertInteger(Console.ReadLine());
                    if (deleteID == -1) break;
                    student.DeleteStudent(deleteID);
                    break;
                case 4:
                    Console.WriteLine($"{"ID",-10}{"Name",-20}{"Age",-8}{"GPA",-8}");
                    List<Student> students = student.GetAllStudent();
                    foreach(Student a in students)
                    {
                        Console.WriteLine($"{a.Id,-10}{a.Name,-20}{a.Age,-8}{a.GPA,-8}");
                    }
                    break;
                case 5:
                    Console.WriteLine("Which student do u want to view?");
                    int iD = student.ConvertInteger(Console.ReadLine());
                    if (iD == -1) break;
                    Student b = student.GetOneStudent(iD);
                    if (b != null)
                    {
                        Console.WriteLine($"{"ID",-10}{"Name",-20}{"Age",-8}{"GPA",-8}");
                        Console.WriteLine($"{b.Id,-10}{b.Name,-20}{b.Age,-8}{b.GPA,-8}");
                    }
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid input! Please try again.");
                    break;
            }
        }
    }
}