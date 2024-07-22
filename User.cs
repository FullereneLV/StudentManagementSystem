namespace HW5_StudentManagementSystem
{
    public class User{
        public List<Students> Students {get; set;} = new();

        public Students  AddStudent()
        {
            Console.WriteLine("Enter First name student:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name student:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter age student:");
            byte age = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter class:");
            var className = Console.ReadLine();
            var newStudents = new Students(firstName,lastName,age,className);
            return newStudents;
        }

        public void RemoveStudent(){
            Console.WriteLine("Enter Last name student:");
            var studentLastName = Console.ReadLine();
            foreach(var student in Students){

                if(student.LastName == studentLastName){
                    Students.Remove(student);
                    break;
                }
            }
        }

        public void AddClassForStudentByLastName(){
            Console.WriteLine("Enter Last name student:");
            var studentLastName = Console.ReadLine();
            Console.WriteLine("Enter class:");
            var className = Console.ReadLine();

            foreach(var student in Students){
                 if(student.LastName == studentLastName){
                    student.ClassName = className;
                    break;
                }
            }
        }

        public void RemoveClassForStudent(){
            Console.WriteLine("Enter Last name student:");
            var studentLastName = Console.ReadLine();
            Console.WriteLine("Enter class:");
            foreach(var student in Students){
                if(student.LastName == studentLastName){
                student.ClassName.Remove(0);
                }
                break;
            }
        }

        public void GetInfoStudent(string studentLastName){
            foreach(var student in Students){
                student.LastName = studentLastName;
                Console.WriteLine($"Inormation about {studentLastName}");
                Console.WriteLine($"Name: {student.FirstName}" 
                + $" Last Name: {student.Age}"
                + $" Last Name: {student.AverageMark}"
                + $" Last Name: {student.ClassName}");
                break;
            }
        }

    }

}
