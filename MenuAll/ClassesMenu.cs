
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
                new MainMenu(_classes).RunMainMenu();
                break;
        }
    }

    public void AddClass()
    {
        Console.Write("Enter class name: ");
        var className = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(className))
        {
            var newClassExist = _classes.Exists(c => c.Name == className);
            if (!newClassExist)
            {
                _classes.Add(new ClassInSchool(className));
                Console.WriteLine("Class added successfully.");
            }
            else
            {
                Console.WriteLine("Class exists.");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter class name:");
            Console.ResetColor();
        }
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Class not found.");
            Console.ResetColor();
        }
        ConsoleUtils.WaitForKeyPress();
        RunClassesMenu();
    }

    public void ViewClasses()
    {
        Console.WriteLine("Show all classes in school:");
        var count = _classes.Count();
        if (count != 0)
        {
            foreach (var schoolClass in _classes)
            {
                Console.WriteLine($"Class name :{schoolClass.Name}");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"List of class is empty.");
            Console.ResetColor();

        }
        ConsoleUtils.WaitForKeyPress();
        RunClassesMenu();
    }
}
