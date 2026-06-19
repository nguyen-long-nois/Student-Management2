using System;
using System.Collections.Generic;
using System.Text;


class StudentService
{
    public static void addStudent(Student a)
    {
        if (a.Age < 0 || a.Age > 25)
        {
            Console.WriteLine("invalid age!");
        }
        else if (a.GPA < 0 || a.GPA > 10)
        {
            Console.WriteLine("the grade must be in interval [0, 10]");
        }
        else if (a.Name == "")
        {
            Console.WriteLine("student must has a name!");
        }
        else
        {
            if (Repository.GetOneStudent(a.Id) != null)
            {
                Console.WriteLine("Student already exist in the database!");
                return;
            }
            Repository.AddStudent(a);
        }
    }
    public static Student GetOneStudent(int id)
    {
        Student target = Repository.GetOneStudent(id);
        if (target == null)
        {
            Console.WriteLine("student doesn't exist in the list!");
        }
        return target;
    }
    public static void UpdateStudent(int id, string name, int age, double gpa)
    {
        if (Repository.GetOneStudent(id) == null)
        {
            Console.WriteLine("Student doesn't exist in the database!");
        }
        else if (age < 0 || age > 25)
        {
            Console.WriteLine("invalid age!");
        }
        else if (gpa < 0 || gpa > 10)
        {
            Console.WriteLine("the grade must be in interval [0, 10]");
        }
        else if (name == "")
        {
            Console.WriteLine("student must has a name!");
        }
        else 
        {
            Repository.UpdateStudent(new Student(id, name, age, gpa));
            Console.WriteLine("student info got updated!");
        }
        
    }
    public static void DeleteStudent(int id)
    {
        if(Repository.GetOneStudent(id) == null)
        {
            Console.WriteLine("Student doesn't exist in the database!");
        }
        Repository.DeleteStudent(id);
        Console.WriteLine("delete successfully!");
    }
}

