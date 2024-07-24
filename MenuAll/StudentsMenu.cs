using HW5_StudentManagementSystem.Models;

namespace HW5_StudentManagementSystem.MenuAll;

public class StudentsMenu
{
    private List<ClassInSchool> _classes;

    public StudentsMenu(List<ClassInSchool> classes)
    {
        _classes = classes;
    }
    public void RunStudentMenu()
    {
        string prompt = "Welcom to Manage Students:";
        string[] options = { "Add Student", "Remove Student", "Show All Students", "Back to Main Menu" };
        Menu menu = new Menu(prompt, options);
        int selectedIndex = menu.Run();

        switch (selectedIndex)
        {
            case 0:
                AddStudent();
                break;
            case 1:
                RemoveStudent();
                break;
            case 2:
            
                //BackToMainMenu();
                break;
        }
    }

    private void AddStudent()
    {
        Console.Write("Enter student first name: ");
        var firstName = Console.ReadLine();
        Console.Write("Enter student last name: ");
        var lastName = Console.ReadLine();
        Console.Write("Enter student age: ");
        var age = byte.Parse(Console.ReadLine());
        Console.Write("Enter student class: ");
        var studentClass = Console.ReadLine();

        var schoolClass = _classes.Find(c => c.Name == studentClass);
        if (schoolClass != null)
        {
            schoolClass.Students.Add(new Student(firstName, lastName, age, studentClass));
            Console.WriteLine("Student added successfully.");
        }
        else
        {
            Console.WriteLine("Class not found.");
        }
        ConsoleUtils.WaitForKeyPress();
        RunStudentMenu();
    }

    private void RemoveStudent()
    {
        Console.Write("Enter student last name to remove: ");
        var name = Console.ReadLine();
        var found = false;

        foreach (var schoolClass in _classes)
        {
            var student = schoolClass.Students.Find(s => s.LastName == name);
            if (student != null)
            {
                schoolClass.Students.Remove(student);
                Console.WriteLine("Student removed successfully.");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Student not found.");
        }
        ConsoleUtils.WaitForKeyPress();
        RunStudentMenu();
    }
    private void BackToMainMenu(){

    }

    private Student ShowAllStudents(){
        foreach (var schoolClass in _classes)
        {
            
        }

        return null;
    }
}
