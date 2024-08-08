using HW5_StudentManagementSystem.Models;

namespace HW5_StudentManagementSystem.MenuAll;
public class LogInMenu
{
    private List<User> _users;
    private MainMenu _mainMenu;

    public LogInMenu(List<User> users, List<ClassInSchool> classes)
    {
        _users = users;
        _mainMenu = new MainMenu(classes);
    }
    public void RunLoginMenu()
    {
        string prompt = "Welcom to Student management system:";
        string[] options = { "Sing In", "Log In", "Exit" };
        Menu menu = new Menu(prompt, options);
        int selectedIndex = menu.Run();

        switch (selectedIndex)
        {
            case 0:
                SingInUser();
                break;
            case 1:
                LogInUser();
                break;
            case 2:
                ConsoleUtils.QuitConsole();
                break;
        }
    }

    private void SingInUser()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to create account");
        Console.ResetColor();
        Console.WriteLine("Enter email:");
        var email = Console.ReadLine();
        Console.WriteLine("Enter password");
        var password = Console.ReadLine();
        if (_users.Exists(u => u.Email == email))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Username already exists. Please try logging in.");
            Console.ResetColor();
        }
        else
        {
            bool isTeacher = false;
            Console.WriteLine("Enter First Name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            var lastName = Console.ReadLine();
            ConsoleKey keyPressed;
            do
            {
                Console.WriteLine("Are you a teacher: Yes/No? ");
                keyPressed = Console.ReadKey(false).Key;
                if (keyPressed == ConsoleKey.Y)
                {
                    isTeacher = true;
                }
                else if (keyPressed == ConsoleKey.N)
                {
                    isTeacher = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter Y or N");
                }
                Console.WriteLine();
            } while (keyPressed != ConsoleKey.Y && keyPressed != ConsoleKey.N);

            _users.Add(new User(email, firstName, lastName, password, isTeacher));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User registered successfully.");
            Console.ResetColor();
            ConsoleUtils.WaitForKeyPress();
            RunLoginMenu();
        }
    }

    private void LogInUser()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to Log In:");
        Console.ResetColor();
        Console.WriteLine("Enter email:");
        var email = Console.ReadLine();
        Console.WriteLine("Enter password");
        var password = Console.ReadLine();

        var user = _users.Find(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Login successful!");
            Console.ResetColor();
            ConsoleUtils.WaitForKeyPress();
            _mainMenu.RunMainMenu();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid credentials. Please try again.");
            Console.ResetColor();
            ConsoleUtils.WaitForKeyPress();
            RunLoginMenu();
        }
    }
}
