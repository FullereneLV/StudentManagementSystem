using HW5_StudentManagementSystem;
using HW5_StudentManagementSystem.MenuAll;
using HW5_StudentManagementSystem.Models;

var classesSchool = new List<ClassInSchool>();
var users = new List<User>();
new LogInMenu(users, classesSchool).RunLoginMenu();