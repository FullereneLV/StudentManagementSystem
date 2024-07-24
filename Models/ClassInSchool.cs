using HW5_StudentManagementSystem.Models;
namespace HW5_StudentManagementSystem;
public class ClassInSchool
{
    public string Name { get; }
    public List<Student> Students = new();
    public List<User> Users = new();
    public int AverageMarks { get; }

    public ClassInSchool(string name)
    {
        Name = name;
    }
    
    public void PrintUser()
    {
        Console.WriteLine("First Name | Last Name | Email | Is teacher");
        foreach (var user in Users)
        {
            Console.WriteLine($"{user.FirstName} | {user.LastName} | {user.Email} | {user.IsTeacher}");
        }
    }

    public void PrintStudents()
    {
        Console.WriteLine("First Name | Last Name | Age | Mark");
        foreach (var student in Students)
        {
            Console.WriteLine($"{student.FirstName} | {student.LastName} | {student.Age} | {student.GetAverageMark():F2}");
        }
    }
}