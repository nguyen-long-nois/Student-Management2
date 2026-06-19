using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

class Repository
{
    const string connectionKey = "Server = (localdb)\\MSSQLLocalDB; Database = StudentList; Trusted_Connection=true";
    public static Student GetOneStudent(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionKey))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * from List Where ID= @Id", connection);
            cmd.Parameters.Add(new SqlParameter("Id", id));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    int StudentId = (int)reader["ID"];
                    string name = (string)reader["Fullname"];
                    int age = (int)reader["AGE"];
                    double grade = (double)reader["GPA"];
                    return new Student(StudentId, name, age, grade);
                }
                else
                {
                    return null;
                }

            }
        }
    } 
    public static List<Student> GetAllStudent()
    {
        List<Student> students = new List<Student>();
        using (SqlConnection connection = new SqlConnection(connectionKey))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select * from List", connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int StudentId = (int)reader["ID"];
                    string name = (string)reader["Fullname"];
                    int age = (int)reader["AGE"];
                    double grade = (double)reader["GPA"];
                    students.Add(new Student(StudentId, name, age, grade));
                }
            }
        }
        return students;
    }
    public static void AddStudent(Student a)
    {
        using (SqlConnection connection = new SqlConnection(connectionKey))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO LIST (ID, Fullname, AGE, GPA) \n VALUES (@Id, @name, @age, @gpa)", connection);
            cmd.Parameters.Add(new SqlParameter("Id", a.Id));
            cmd.Parameters.Add(new SqlParameter("name", a.Name));
            cmd.Parameters.Add(new SqlParameter("age", a.Age));
            cmd.Parameters.Add(new SqlParameter("gpa", a.GPA));
            cmd.ExecuteNonQuery();
        }
    }
    public static void DeleteStudent(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionKey))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM LIST \n WHERE ID = @Id", connection);
            cmd.Parameters.Add(new SqlParameter("Id", id));
            cmd.ExecuteNonQuery();
        }
    }
    public static void UpdateStudent(Student a)
    {
        using (SqlConnection connection = new SqlConnection(connectionKey))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE LIST \n SET Fullname = @name, AGE = @age, GPA = @gpa \n WHERE ID = @Id", connection);
            cmd.Parameters.Add(new SqlParameter("Id", a.Id));
            cmd.Parameters.Add(new SqlParameter("name", a.Name));
            cmd.Parameters.Add(new SqlParameter("age", a.Age));
            cmd.Parameters.Add(new SqlParameter("gpa", a.GPA));
            cmd.ExecuteNonQuery();
        }
    }
}


