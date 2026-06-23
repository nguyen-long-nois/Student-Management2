using System;
using System.Collections.Generic;
using System.Text;

public class Student
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public int Age { get; set; } 
    public double GPA { get; set; } 
    public Student(int id, string name, int age, double grade)
    {
        Id = id;
        Name = name;
        Age = age;
        GPA = grade;
    }
    public Student() { }
}

