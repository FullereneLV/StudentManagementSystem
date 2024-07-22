using Microsoft.VisualBasic;

namespace HW5_StudentManagementSystem;
public class RunStudentManagementSystem
{
    private bool _isRunning = true;

    User user = new User();

    private string _email;
    private string _password;
    public Dictionary<string, string> GredantionalUser = new Dictionary<string, string>();
    List<Option> options;
    public void Run()
    {
        

        while (_isRunning)
        {
            options = new List<Option>
            {
                new Option("Sign in", () => SignIn()),
                new Option("Log in", () =>  LogInFileds()),
                new Option("Leave", () => Environment.Exit(0)),
            };

            int index = 0;

            WriteMenu(options, options[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }
    }

    public void WriteMenu(List<Option> options, Option selectedOption)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcom to Student management system:");
        Console.ResetColor();
        Console.WriteLine("\nUse \u001b[32mup\u001b[0m or \u001b[32mdown\u001b[0m to navigate and press the \u001b[32mEnter/Return\u001b[0m key to select");
        foreach (Option option in options)
        {
            if (option == selectedOption)
            {
                Console.Write("\u001b[32m> \u001b[0m");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
        }
    }
    public void SignIn()
    {

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Create account:");
        Console.WriteLine("Email:");
        Console.ResetColor();
        _email = Console.ReadLine();

        if (!IsEmailExist(_email))
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Password:");
            Console.ResetColor();
            _password = Console.ReadLine();
            Console.WriteLine("Confirm Password:");
            var confirmPassword = Console.ReadLine();
            if (_password != confirmPassword)
            {
                Console.WriteLine("Password isn't the same.");
            }
            GredantionalUser.Add(_email, _password);
            Console.WriteLine("Successfully created an account.");
            PauseBeforeContinuing();
            WriteMenu(options, options.First());
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Your email exist.");
            Console.ResetColor();
            PauseBeforeContinuing();
            WriteMenu(options, options.First());
        }

    }
    public void LogInFileds()
    {

        bool res = false;

        while (!res)
        {
            Console.Clear();
            Console.WriteLine("Email:");
            _email = Console.ReadLine();

            if (IsEmailExist(_email))
            {
                Console.WriteLine("Password:");
                _password = Console.ReadLine();
                if (!IsValidCredentials(_email, _password))
                {

                    Console.WriteLine("\u001b[31mEmail or password is wrong.\u001b[0m Please try again.");
                    PauseBeforeContinuing();
                }
                else
                {
                    res = SubMenu(_email);
                }
            }
            else
            {
                Console.WriteLine("Please Sign In");
                PauseBeforeContinuing();
                WriteMenu(options, options.First());
            }
            res = true;
        }
    }

    public bool IsEmailExist(string email) => GredantionalUser.ContainsKey(email);
    public bool IsValidCredentials(string email, string password) => GredantionalUser[email].Contains(password);

    void PauseBeforeContinuing()
    {
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    bool SubMenu(string email = "")
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add Student");
            Console.WriteLine("2) Remove Student");
            Console.WriteLine("3) Add class");
            Console.WriteLine("4) Remove class");
            Console.WriteLine("5) Log Out");
            Console.WriteLine("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    user.AddStudent();
                    PauseBeforeContinuing();
                    return true;
                case "2":
                    user.RemoveStudent();
                    PauseBeforeContinuing();
                    return true;
                case "3":
                    user.AddClassForStudentByLastName();
                    PauseBeforeContinuing();
                    return true;
                case "4":
                    ;
                    PauseBeforeContinuing();
                    return true;
                case "5":
                    ;
                    PauseBeforeContinuing();
                    return false;
                default:
                    return true;
            }
        }
}
