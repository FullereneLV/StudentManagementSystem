namespace HW5_StudentManagementSystem.Models;
public class User
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public bool IsTeacher { get; set; }

    public User(
        string email,
        string firstName,
        string lastName,
        string password,
        bool isTeacher)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        IsTeacher = isTeacher;
    }

    public User(string email, string password){
        Email = email;
        FirstName = "Unknown";
        LastName = "Unknown";
        Password = password;
        IsTeacher = false;
    }
}
