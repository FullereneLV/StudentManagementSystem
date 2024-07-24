
namespace HW5_StudentManagementSystem.MenuAll;
public class ClassesMenu
{
    private List<ClassInSchool> _classes;
    public ClassesMenu(List<ClassInSchool> classes)
    {
        _classes = classes;
    }
    public void RunClassesMenu()
    {
        string prompt = "Welcom to Student management system:";
        string[] options = { "Add class", "Remove class", "View classes", "Bact to Main menu" };
        Menu menu = new Menu(prompt, options);
        int selectedIndex = menu.Run();

        switch (selectedIndex)
        {
            case 0:
                AddClass();
                break;
            case 1:
                RemoveClass();
                break;
            case 2:
                ViewClasses();
                break;
            case 3:
                BackToMainMenu();
                break;
        }
    }

    public void AddClass()
    {
        Console.Write("Enter class name: ");
        var className = Console.ReadLine();
        _classes.Add(new ClassInSchool(className));
        Console.WriteLine("Class added successfully.");
        ConsoleUtils.WaitForKeyPress();
        RunClassesMenu();
    }

    public void RemoveClass()
    {
        Console.Write("Enter class name to remove: ");
        var className = Console.ReadLine();
        var schoolClass = _classes.Find(c => c.Name == className);
        if (schoolClass != null)
        {
            _classes.Remove(schoolClass);
            Console.WriteLine("Class removed successfully.");
        }
        else
        {
            Console.WriteLine("Class not found.");
        }
        ConsoleUtils.WaitForKeyPress();
        RunClassesMenu();
    }

    public void ViewClasses()
    {
        foreach (var schoolClass in _classes)
        {
            schoolClass.PrintStudents();
        }
        ConsoleUtils.WaitForKeyPress();
        RunClassesMenu();
    }

    private void BackToMainMenu(){
        
    }
}
