using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IStudentService
    {
        public bool CheckStudent(Student a);
        public void AddStudent(Student a);
        public Student GetOneStudent(int id);
        public void UpdateStudent(Student a);
        public void DeleteStudent(int id);
        public List<Student> GetAllStudent();
        public int ConvertInteger(string id);
        public double ConvertDouble(string grade);
    }
}
