namespace HW5_StudentManagementSystem.Models;
public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Age { get; set; }
    public string ClassName { get; set; }
    public Dictionary<string, int> Marks { get; set; }

    public Student(string firstName, string lastName, byte age, string studentClass)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        ClassName = studentClass;
        Marks = new Dictionary<string, int>();
    }

    public double GetAverageMark()
    {
        if (Marks.Count == 0) return 0;
        double sum = 0;
        foreach (var mark in Marks.Values)
        {
            sum += mark;
        }

        return sum / Marks.Count;
    }

    public void Info()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Fist Name: {FirstName}, \nLast Name: {LastName} \nAge: {Age}, \nClass: {ClassName}, \nAverage Mark: {GetAverageMark():F2}");
        Console.ResetColor();
    }
}