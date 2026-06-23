using System;
using System.Collections.Generic;
using System.Text;
using Interface;

namespace service
{
    class StudentService : IStudentService
    {
        Repository database = new Repository();
        public void AddStudent(Student a)
        {
            if (CheckStudent(a) == false)
            {
                Console.WriteLine("the new students doesn't fit our system!");
                return;
            }
            if (database.GetOneStudent(a.Id) != null)
            {
                Console.WriteLine("there is a student with that ID in the database!");
                return;
            }
            Repository.AddStudent(a);
        }
        public Student GetOneStudent(int id)
        {
            Student target = database.GetOneStudent(id);
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

            if (Repository.UpdateStudent(a) == 0)
            {
                Console.WriteLine("Student doesn't exist in the database!");
                return;
            }
            Console.WriteLine("student info got updated!");
        }
        public void DeleteStudent(int id)
        {
            if (Repository.DeleteStudent(id) == 0)
            {
                Console.WriteLine("student doesn't exist in the database!");
                return;
            }
            Console.WriteLine("delete successfully!");
        }

        public bool CheckStudent(Student a)
        {
            if (a.Age < 0 || a.Age > 25)
            {
                Console.WriteLine("invalid age!");
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
    }
}
