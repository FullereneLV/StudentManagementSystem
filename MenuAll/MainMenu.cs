using HW5_StudentManagementSystem.Models;

namespace HW5_StudentManagementSystem.MenuAll;

public class MainMenu
{
    private List<ClassInSchool> _classes;
    private List<User> _users;
    private ClassesMenu _classesMenu;
    private StudentsMenu _studentsMenu;
    private MarksMenu _marksMenu;
    private ViewInfoMenu _viewInfoMenu;

    public MainMenu(List<ClassInSchool> classes)
    {
        _classes = classes;
        _classesMenu = new ClassesMenu(_classes);
        _studentsMenu = new StudentsMenu(_classes);
        _marksMenu = new MarksMenu(_classes);
        _viewInfoMenu = new ViewInfoMenu(_classes);
    }

    public void RunMainMenu()
    {
        string prompt = "Welcom to Main Menu:";
        string[] options = { "Manage Classes", "Manage Students",
                            "Manage Marks", "View Information",
                            "Log Out" };
        Menu menu = new Menu(prompt, options);
        int selectedIndex = menu.Run();

        switch (selectedIndex)
        {
            case 0:
                _classesMenu.RunClassesMenu();
                break;
            case 1:
                _studentsMenu.RunStudentMenu();
                break;
            case 2:
                _marksMenu.RunMarksMenu();
                break;
            case 3:
                _viewInfoMenu.RunInfoMenu();
                break;
            case 4:
                ConsoleUtils.WaitForKeyPress();
                break;
        }
    }
}
