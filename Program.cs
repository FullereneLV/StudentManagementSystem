using HW5_StudentManagementSystem;
using HW5_StudentManagementSystem.MenuAll;
using HW5_StudentManagementSystem.Models;

List<ClassInSchool> classesSchool = new List<ClassInSchool>();
List<User> users = new List<User>();
new LogInMenu(users, classesSchool).RunLoginMenu();