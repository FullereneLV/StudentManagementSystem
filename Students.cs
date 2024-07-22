namespace HW5_StudentManagementSystem;

public class Students
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public byte Age {get; set;}
    public string ClassName{get; set;}
    public int AverageMark{get;}

public Students(){
    FirstName = "Unknown";
    LastName = "Unknown";
    Age = 0;
    ClassName = "Unknown";
    AverageMark = 0;
}

public Students(
                string firstName, 
                string lastName,
                byte age, 
                string className)
{
    FirstName = firstName;
    LastName = lastName;
    Age = age;
    ClassName = className;
}
}
