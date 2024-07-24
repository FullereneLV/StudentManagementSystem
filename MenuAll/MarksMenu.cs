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
                    BackToMainMenu();
                    break;
            }
        }
        private void AddUpdateMarksByStudent()
        {
            Console.Write("Enter student last name to manage marks: ");
            var name = Console.ReadLine();
            var student = FindStudent(name);
            if (student != null)
            {
                Console.Write("Enter subject (Math, English, Biology, Geography): ");
                string subject = Console.ReadLine();
                Console.Write("Enter mark: ");
                int mark = int.Parse(Console.ReadLine());
                student.Marks[subject] = mark;
                Console.WriteLine("Mark added/updated successfully.");
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
                Console.Write($"Enter subject: \n{SchoolSubject.Math.ToString()},"
                                + $"{SchoolSubject.English.ToString()},"
                                + $"{SchoolSubject.Biology.ToString()},"
                                + $"{SchoolSubject.Geography.ToString()} \nto remove mark: ");
                string subject = Console.ReadLine();
                if (student.Marks.ContainsKey(subject))
                {
                    student.Marks.Remove(subject);
                    Console.WriteLine("Mark removed successfully.");
                }
                else
                {
                    Console.WriteLine("Subject not found.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            ConsoleUtils.WaitForKeyPress();
            RunMarksMenu();
        }

        private void SchoolSubjectMenu(Student student)
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
                    break;
                case 1:
                    student.Marks.Remove($"{SchoolSubject.English}");
                    Console.WriteLine("Mark removed successfully.");
                    break;
                case 2:
                    student.Marks.Remove($"{SchoolSubject.Biology}");
                    Console.WriteLine("Mark removed successfully.");
                    break;
                case 3:
                    student.Marks.Remove($"{SchoolSubject.Geography}");
                    Console.WriteLine("Mark removed successfully.");
                    break;
            }
        }
        private void BackToMainMenu(){

        }
    }

    
}
