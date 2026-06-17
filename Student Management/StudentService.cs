using System;
using System.Collections.Generic;
using System.Text;

class StudentService
{
    static List<Student> notes = new List<Student>();
    public static void addStudent(Student a)
    {
        if (a.Age < 0 || a.Age > 18)
        {
            Console.WriteLine("invalid age!");
        }
        else if(a.GPA <0 || a.GPA >10) {
            Console.WriteLine("invalid grade!");
        }
        else
        {
            notes.Add(a);
        }
        
    }
    public static void getOneStudent(Student a)
    {
        Console.WriteLine($"{"ID",-10}{"Name",-20}{"Age",-8}{"GPA",-8}");
        Console.WriteLine($"{a.Id,-10}{a.Name,-20}{a.Age,-8}{a.GPA,-8}");
    }
    public static void getAllStudent()
    {
        if (notes.Count == 0)
        {
            Console.WriteLine("List is empty!");
        }
        else
        {
            Console.WriteLine($"{"ID",-10}{"Name",-20}{"Age",-8}{"GPA",-8}");
            foreach (Student a in notes)
            {
                Console.WriteLine($"{a.Id,-10}{a.Name,-20}{a.Age,-8}{a.GPA,-8}");
            }
        }
    }
    public static Student findStudent(int id)
    {
        Student target = notes.Find(a => a.Id == id);
        return target;
    }
    public static void updateStudent(int id, string name, int age, double score)
    {
        Student a = findStudent(id);
        a.Name = name;
        a.Age = age;
        a.GPA = score;
    }
    public static void deleteStudent(Student a)
    { 
        notes.Remove(a);
        Console.WriteLine("Delete student successfully!");
    }
        
}

