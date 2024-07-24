

using HW5_StudentManagementSystem.Models;

namespace HW5_StudentManagementSystem.MenuAll;

public class ViewInfoMenu
{
    private readonly List<ClassInSchool> _classes;

    public ViewInfoMenu(List<ClassInSchool> classes)
    {
        _classes = classes;
    }

     public void RunInfoMenu()
    {
        string prompt = "Welcom to View Information:";
        string[] options = { "View Student Details", "View Class Details",
                            "Back to Main Menu"};
        Menu menu = new Menu(prompt, options);
        int selectedIndex = menu.Run();

        switch (selectedIndex)
        {
            case 0:
                ViewStudentDetails();
                break;
            case 1:
                ViewClassDetails();
                break;
            case 2:
                new MainMenu(_classes).RunMainMenu();
                break;
        }
    }

    public void ViewStudentDetails()
    {
        Console.Write("Enter student last name to view details: ");
        string lastName = Console.ReadLine();
        var student = FindStudent(lastName);
        if (student != null)
        {
            student.Info();
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
        ConsoleUtils.WaitForKeyPress();
        RunInfoMenu();
    }
    
    public void ViewClassDetails()
    {
        Console.Write("Enter class name to view details: ");
        string className = Console.ReadLine();
        var schoolClass = _classes.Find(c => c.Name == className);
        if (schoolClass != null)
        {
            schoolClass.PrintStudents();
        }
        else
        {
            Console.WriteLine("Class not found.");
        }
        ConsoleUtils.WaitForKeyPress();
        RunInfoMenu();
    }
    
    private Student FindStudent(string name)
    {
        foreach (var schoolClass in _classes)
        {
            var student = schoolClass.Students.Find(s => s.LastName == name);
            if (student != null)
            {
                return student;
            }
        }

        return null;
    }
}
