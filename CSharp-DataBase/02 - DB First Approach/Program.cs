using demo_DB.First_Approach.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace demo_DB.First_Approach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Microsoft.EntityFrameworkCore.SqlServer  -> to be v3.1.26
            //Microsoft.EntityFrameworkCore.Design    -> to be v3.1.26
            //CONNECTION STRING:
            //Type in PowerShell: dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Integrated Security=true;Database=SoftUni;TrustServerCertificate=Yes;" Microsoft.EntityFrameworkCore.SqlServer
            
            SoftUniContext context = new SoftUniContext();
            DbSet<Employee> employeeSet = context.Employees;
            
            
            // How to UPDATE Entity 

            //1) Retrieve entity by id
            
           Employee emplyeeToUpdate = context.Employees.FirstOrDefault(item => item.EmployeeId == 293);

            //2) Validate entity is not null
            if (emplyeeToUpdate != null)
            {            
                //3) Make changes on entity
                emplyeeToUpdate.MiddleName = "Updated Mid Name";
                emplyeeToUpdate.JobTitle = "Updated_HackerDev";
                
                //4) Save changes in database
                //context.SaveChanges();
            }
            
            //How to add New Employee entity into table Employees

            //Variant 1
            Employee currentEmloyee1 = new Employee { FirstName = "Parko", LastName = "Gerov", JobTitle = "HackerDev", DepartmentId = 5, ManagerId = 5, HireDate = DateTime.Now, Salary = 16500, AddressId = 5 };
            context.Employees.Add(currentEmloyee1);
            //context.SaveChanges(); // uncomment this if you want to change actual DB
            
            //Variant 2
            Employee currentEmloyee2 = new Employee { FirstName = "Parko", LastName = "Gerov", JobTitle = "HackerDev", DepartmentId = 5, ManagerId = 5, HireDate = DateTime.Now, Salary = 16500, AddressId = 5 };
            employeeSet.Add(currentEmloyee2);
            //context.SaveChanges(); // uncomment this if you want to change actual DB
            //Variant 3
            employeeSet.Add(new Employee
            {
                FirstName = "Parko",
                LastName = "Gerov",
                JobTitle = "HackerDev",
                DepartmentId = 5,
                ManagerId = 5,
                HireDate = DateTime.Now,
                Salary = 16500,
                AddressId = 5
            });

            //Variant 4
            employeeSet.Add(new Employee { FirstName = "Evlogii", LastName = "Minchevich", JobTitle = "HackerTrainee", DepartmentId = 6, ManagerId = 7, HireDate = DateTime.Now, Salary = 7500, AddressId = 4 });
            employeeSet.Add(new Employee { FirstName = "Pumba", LastName = "Timonov", JobTitle = "HackerJunior", DepartmentId = 3, ManagerId = 4, HireDate = DateTime.Now, Salary = 4500, AddressId = 5 });
            //context.SaveChanges(); // uncomment this if you want to change actual DB



            // How to remove an Employee from Table Emplyees

            context.RemoveRange(context.Employees.Where(x => x.EmployeeId >= 298)); // with RemoveRange() we expect to remove more rows in table
            context.Remove(context.Employees.FirstOrDefault(x => x.EmployeeId == 293)); // with Remove() we expect to remove only 1 row in table
            //context.SaveChanges();


            //How to Access Table Entities by loop and Linq
            //---------------------------------------------------------------
            foreach (var emp in employeeSet.Where(x => x.Salary < 15000 && x.ManagerId <= 16))
            {
                Console.WriteLine($"FirstName: [{emp.FirstName.ToUpper()}] , LastName: [{emp.LastName.ToUpper()}], Salary of: {emp.Salary} , ManagerID = {emp.ManagerId}");

            }

            //---------------------------------------------------------------

            var linqFunc = employeeSet
                .Where(x => x.Salary > 15000 && x.Salary <= 30000).Select(y => $"{y.FirstName},{y.Salary} - {y.JobTitle}").ToList();

            Console.WriteLine(string.Join("\r\n", linqFunc));

            

        }
    }
}
