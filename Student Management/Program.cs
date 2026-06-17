using System;
using System.Data.Common;
using System.Numerics;
using System.Xml.Linq;


class Program
{
    static void Main()
    {
        menu();
    }
    
    static void menu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to student management app!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Update a student");
            Console.WriteLine("3. Delete a student");
            Console.WriteLine("4. View all students");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Please input one of these number to use our service!");

            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("What's that student's ID?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    if (StudentService.findStudent(id) !=null)
                    {
                        Console.WriteLine("ID already exist!");
                        break;
                    }
                    Console.WriteLine("What's that student's name?");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("What's that student's age?");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("What's that student's GPA?");
                    double grade = Convert.ToDouble(Console.ReadLine());
                    Student a = new Student(id, studentName, age, grade);
                    StudentService.addStudent(a);
                    break;
                case 2:
                    Console.WriteLine("Which student do u want to update?");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    Student target = StudentService.findStudent(ID);
                    if ( target == null) break;
                    Console.WriteLine("what's the new name?");
                    string Name = Console.ReadLine();
                    Console.WriteLine("what's the new age?");
                    int Age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("what's the new grade?");
                    double GPA = Convert.ToDouble(Console.ReadLine());
                    StudentService.updateStudent(ID, Name, Age, GPA);
                    
                    break;
                case 3:
                    Console.WriteLine("Which student do u want to delete?");
                    int deleteID = Convert.ToInt32(Console.ReadLine());
                    Student unknown = StudentService.findStudent(deleteID);
                    if (unknown == null) break;
                    StudentService.deleteStudent(unknown);
                    break;
                case 4:
                    StudentService.getAllStudent();
                    break;

                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid number! Please try again.");
                    break;
            }
        }
    }
}