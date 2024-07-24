using HW5_StudentManagementSystem.Models;

namespace HW5_StudentManagementSystem.MenuAll
{
    public class MarksMenu
    {
        private readonly List<ClassInSchool> _classes;
        public MarksMenu(List<ClassInSchool> classes)
        {
            _classes = classes;
        }
        public void RunMarksMenu()
        {
            string prompt = "Welcom to Manage Marks:";
            string[] options = { "Add/Update Marks", "Remove Marks", "Back to Main Menu" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    AddUpdateMarksByStudent();
                    break;
                case 1:
                    RemoveMarksByStudent();
                    break;
                case 2:
                    new MainMenu(_classes).RunMainMenu();
                    break;
            }
        }
        private void AddUpdateMarksByStudent()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter student last name to manage marks: ");
            Console.ResetColor();
            var name = Console.ReadLine();
            var student = FindStudent(name);
            if (student != null)
            {
                SchoolSubjectForAddOrUpdateMenu(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            ConsoleUtils.WaitForKeyPress();
            RunMarksMenu();
        }

        private Student FindStudent(string lastName)
        {
            foreach (var schoolClass in _classes)
            {
                var student = schoolClass.Students.Find(s => s.LastName == lastName);
                if (student != null)
                {
                    return student;
                }
            }

            return null;
        }

        private void RemoveMarksByStudent()
        {
            Console.Write("Enter student last name to manage marks: ");
            var name = Console.ReadLine();
            var student = FindStudent(name);
            if (student != null)
            {
                SchoolSubjectForRemoveMenu(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            ConsoleUtils.WaitForKeyPress();
            RunMarksMenu();
        }

        private void SchoolSubjectForRemoveMenu(Student student)
        {
            string prompt = "School Subject Menu:";
            string[] options = { $"{SchoolSubject.Math.ToString()}",
                                $"{SchoolSubject.English.ToString()}",
                                $"{SchoolSubject.Biology.ToString()}",
                                $"{SchoolSubject.Geography.ToString()}" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    student.Marks.Remove($"{SchoolSubject.Math}");
                    Console.WriteLine("Mark removed successfully.");
                    ConsoleUtils.WaitForKeyPress();
                    RunMarksMenu();
                    break;
                case 1:
                    student.Marks.Remove($"{SchoolSubject.English}");
                    Console.WriteLine("Mark removed successfully.");
                    ConsoleUtils.WaitForKeyPress();
                    RunMarksMenu();
                    break;
                case 2:
                    student.Marks.Remove($"{SchoolSubject.Biology}");
                    Console.WriteLine("Mark removed successfully.");
                    ConsoleUtils.WaitForKeyPress();
                    RunMarksMenu();
                    break;
                case 3:
                    student.Marks.Remove($"{SchoolSubject.Geography}");
                    Console.WriteLine("Mark removed successfully.");
                    ConsoleUtils.WaitForKeyPress();
                    RunMarksMenu();
                    break;
            }
        }

        private void SchoolSubjectForAddOrUpdateMenu(Student student)
        {
            string prompt = "School Subject Menu:";
            string[] options = { $"{SchoolSubject.Math.ToString()}",
                                $"{SchoolSubject.English.ToString()}",
                                $"{SchoolSubject.Biology.ToString()}",
                                $"{SchoolSubject.Geography.ToString()}" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();
            Console.Write("Enter mark: ");
            var value = Console.ReadLine();
            int mark;
            int.TryParse(value, out mark);
            switch (selectedIndex)
            {
                case 0:
                    student.Marks[SchoolSubject.Math.ToString()] = mark;
                    Console.WriteLine("Mark added/updated successfully.");
                    ConsoleUtils.WaitForKeyPress();
                    RunMarksMenu();
                    break;
                case 1:
                    student.Marks[SchoolSubject.English.ToString()] = mark;
                    Console.WriteLine("Mark added/updated successfully.");
                    ConsoleUtils.WaitForKeyPress();
                    RunMarksMenu();
                    break;
                case 2:
                    student.Marks[SchoolSubject.Biology.ToString()] = mark;
                    Console.WriteLine("Mark added/updated successfully.");
                    ConsoleUtils.WaitForKeyPress();
                    RunMarksMenu();
                    break;
                case 3:
                    student.Marks[SchoolSubject.Geography.ToString()] = mark;
                    Console.WriteLine("Mark added/updated successfully.");
                    ConsoleUtils.WaitForKeyPress();
                    RunMarksMenu();
                    break;
            }
        }
    }
}
