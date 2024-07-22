namespace HW5_StudentManagementSystem;

public class EnterAccount{

private  string _email;
private  string _password;

public Dictionary<string, string> GredantionalUser = new Dictionary<string, string>();

    public void SignIn(){

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
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Your email exist.");
                Console.ResetColor();
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
                        //res = SubMenu(email);
                    }
                }
                else
                {
                    Console.WriteLine("Please Sign In");
                    PauseBeforeContinuing();
                    new RunStudentManagementSystem();
                }
                res = true;
            }
        }

    public bool IsEmailExist(string email) => GredantionalUser.ContainsKey(email);
    public bool IsValidCredentials(string email, string password)=> GredantionalUser[email].Contains(password);

    void PauseBeforeContinuing()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
}