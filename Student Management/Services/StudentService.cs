using System;
using System.Collections.Generic;
using System.Text;
using Interface;

namespace service
{
    class StudentService : IStudentService
    {
        Repository _database = new Repository();
        public void AddStudent(Student a)
        {
            if (CheckStudent(a) == false)
            {
                Console.WriteLine("the new students doesn't fit our system!");
                return;
            }
            if (_database.GetOneStudent(a.Id) != null)
            {
                Console.WriteLine("there is a student with that ID in the database!");
                return;
            }
            _database.AddStudent(a);
        }
        public Student GetOneStudent(int id)
        {
            Student target = _database.GetOneStudent(id);
            if (target == null)
            {
                Console.WriteLine("student doesn't exist in the list!");
            }
            return target;
        }
        public void UpdateStudent(Student a)
        {
            if (CheckStudent(a) == false)
            {
                return;
            }

            if (_database.UpdateStudent(a) == 0)
            {
                Console.WriteLine("Student doesn't exist in the database!");
                return;
            }
            Console.WriteLine("student info got updated!");
        }
        public void DeleteStudent(int id)
        {
            if (_database.DeleteStudent(id) == 0)
            {
                Console.WriteLine("student doesn't exist in the database!");
                return;
            }
            Console.WriteLine("delete successfully!");
        }

        public bool CheckStudent(Student a)
        {
            if (a.Id <0 || a.Id > 99)
            {
                Console.WriteLine("Invalid ID! Student ID must be an integer in interval (0,99]");
                return false;
            }
            if (a.Age < 6 || a.Age >= 25)
            {
                Console.WriteLine("invalid age! Student age must be an integer in interval (6,25]");
                return false;
            }
            else if (a.GPA < 0 || a.GPA > 10)
            {
                Console.WriteLine("the grade must be in interval [0, 10]");
                return false;
            }
            else if (a.Name == "")
            {
                Console.WriteLine("student must has a name!");
                return false;
            }
            return true;
        }
        public List<Student> GetAllStudent()
        {
             return _database.GetAllStudent();
        }
        public int ConvertInteger(string id)
        {
            if (int.TryParse(id, out int result))
            {
                return result;
            }
            Console.WriteLine("this field only take an integer!");
            return -1;
        }
        public double ConvertDouble(string grade)
        {
            if (double.TryParse(grade, out double result))
            {
                return result;
            }
            Console.WriteLine("grade must be a double type!");
            return -1.0;
        }
    }
}
