using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // DATABASE FIRST MODEL !

            //Microsoft.EntityFrameworkCore.SqlServer ->to be v3.1.26
            //Microsoft.EntityFrameworkCore.Design    -> to be v3.1.26
            //Microsoft.EntityFrameworkCore.Tools  -> to be v3.1.26
            //Microsoft.EntityFrameworkCore   -> to be v3.1.26

            SoftUniContext contextSoftUni = new SoftUniContext();


            //Task 3 Employees Full Information
            string employeesInfo = String.Empty;
            employeesInfo = GetEmployeesFullInformation(contextSoftUni);
            Console.WriteLine(employeesInfo);

            //Task 4 Employees with Salary Over 50 000
            string employeeSalaryInfo = GetEmployeesWithSalaryOver50000(contextSoftUni);
            Console.WriteLine(employeeSalaryInfo);

            //Task 5.Employees from Research and Development
            string employeeDepartmentInfo = GetEmployeesFromResearchAndDevelopment(contextSoftUni);
            Console.WriteLine(employeeDepartmentInfo);

            //Task 6.Adding a New Address and Updating Employee
            string addAddress = AddNewAddressToEmployee(contextSoftUni);
            Console.WriteLine(addAddress);

            //Task7. Employees and Projects
            string empAndProj = GetEmployeesInPeriod(contextSoftUni);
            Console.WriteLine(empAndProj);

            //Task 8.Addresses by Town
            string addressBytown = GetAddressesByTown(contextSoftUni);
            Console.WriteLine(addressBytown);


            // Task 9.Employee 147
            string emp147 = GetEmployee147(contextSoftUni);
            Console.WriteLine(emp147);


            //Task 10.Departments with More Than 5 Employees
            string res = GetDepartmentsWithMoreThan5Employees(contextSoftUni);
            Console.WriteLine(res);

            // Task 11.Find Latest 10 Projects
            string latestProj = GetLatestProjects(contextSoftUni);
            Console.WriteLine(latestProj);

            // Task 12.Increase Salaries
            string increase = IncreaseSalaries(contextSoftUni);
            Console.WriteLine(increase);

            // Task 13.	Find Employees by First Name Starting with "Sa"
            string firstNameStartingWith = GetEmployeesByFirstNameStartingWithSa(contextSoftUni);
            Console.WriteLine(firstNameStartingWith);

            // Task 14.Delete Project by Id
            //string deleteProjById = DeleteProjectById(contextSoftUni);
            //Console.WriteLine(deleteProjById);

            // Task 15.Remove Town - Delete operation in DB
            //string removeTown = RemoveTown(contextSoftUni);
            //Console.WriteLine(removeTown);
        }
        

        // Task 3 
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var emp in context.Employees.OrderBy(x => x.EmployeeId))
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }
        /*
        
        public static List<string> GetEmployeesFullInformation(SoftUniContext context)
        {
           var employees = context.Employees.Select(x => ($"{x.FirstName} {x.LastName} {x.MiddleName} {x.JobTitle} {x.Salary:f2}\r\n")).ToList();

            return employees;
        }
        */

        // Task 4 

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            DbSet<Employee> employeesInfo = context.Employees;

            foreach (var emp in employeesInfo.Where(x => x.Salary > 50000).OrderBy(x => x.FirstName))
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext contextSoftUni)
        { // Research and Development
            StringBuilder sb = new StringBuilder();

            foreach (var emp in contextSoftUni.Employees.Where(x => x.Department.Name == "Research and Development").OrderBy(x => x.Salary).ThenByDescending(x => x.FirstName))
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from Research and Development - ${emp.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        // Task 6
        public static string AddNewAddressToEmployee(SoftUniContext contextSoftUni)
        {
            var addressNew = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = contextSoftUni.Employees.First(x => x.LastName == "Nakov");
            employee.Address = addressNew;
            //contextSoftUni.RemoveRange(contextSoftUni.Addresses.Where(x => x.AddressId > 291));            

            contextSoftUni.SaveChanges();
            var finalEmplyeesInfo = contextSoftUni.Employees.OrderByDescending(e => e.AddressId).Select(e => e.Address.AddressText).Take(10).ToList();


            return String.Join("\n", finalEmplyeesInfo);
        }

        // Task 7
        public static string GetEmployeesInPeriod(SoftUniContext context)  //M/d/yyyy h:mm:ss tt
        {
            StringBuilder sb = new StringBuilder();

            var employeesFilteredByYear = context.Employees.Where(e => e.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003)).Take(10).Select(e => new
            { //We can give anonymous func parameters - name (empFirstName,empLasttName,manFirstName,manLastName, Projects ..etc)
                //this time it is a MUST becuse FirstName and LastName are the same of both objects and VS givs an error.
                emplFirstName = e.FirstName,
                emplLasttName = e.LastName,
                managerFirstName = e.Manager.FirstName,
                managerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects.Select(p => new { p.Project.Name, p.Project.StartDate, p.Project.EndDate })
            });

            foreach (var infoEmpManager in employeesFilteredByYear)
            {
                sb.AppendLine($"{infoEmpManager.emplFirstName} {infoEmpManager.emplLasttName} - Manager: {infoEmpManager.managerFirstName} {infoEmpManager.managerLastName}");

                foreach (var proj in infoEmpManager.Projects)
                {
                    var currentStartDate = proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var currentEndDate = proj.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDateConditioned = currentEndDate != null ? currentEndDate : "not finished";

                    sb.AppendLine($"--{proj.Name} - {currentStartDate} - {endDateConditioned}");
                }
            }


            return sb.ToString().TrimEnd();

            //Variant 2
            /*
             var employees = context.Employees.Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate,
                        ProjectEndDate = ep.Project.EndDate
                    })
                }).Take(10);

            StringBuilder employeeManagerResult = new StringBuilder();

            foreach (var employee in employees)
            {
                employeeManagerResult.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    var endDate = project.ProjectEndDate.HasValue ? project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                    employeeManagerResult.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return employeeManagerResult.ToString().TrimEnd();
             */

        }

        // Task 8
        public static string GetAddressesByTown(SoftUniContext contextSoftUni)
        {
            StringBuilder sb = new StringBuilder();
            var addressEmp = contextSoftUni.Addresses.Select(y => new { y.AddressText, y.Town.Name, y.Employees.Count }).OrderByDescending(y => y.Count).ThenBy(x => x.Name).ThenBy(x => x.AddressText).Take(10).ToList();

            foreach (var item in addressEmp)
            {
                sb.AppendLine($"{item.AddressText}, {item.Name} - {item.Count} employees");
            }
            return sb.ToString().TrimEnd();
        }

        //Task 9

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employee147 = context.Employees.Select(x => new
            {
                x.EmployeeId,
                x.FirstName,
                x.LastName,
                x.JobTitle,
                Projects = x.EmployeesProjects.OrderBy(x => x.Project.Name).Select(p => new { p.Project.Name })
            }).FirstOrDefault(x => x.EmployeeId == 147);


            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var item in employee147.Projects)
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().TrimEnd();
        }

        // Task 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentsOver5Emp = context.Departments.Where(e => e.Employees.Count > 5).OrderBy(x => x.Employees.Count).ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Manager.FirstName,
                    x.Manager.LastName,
                    Employees = x.Employees.Select(e => new { e.FirstName, e.LastName, e.JobTitle })
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName).ToList()
                });


            StringBuilder sb = new StringBuilder();

            //"<DepartmentName> - <ManagerFirstName>  <ManagerLastName>
            //"<EmployeeFirstName> <EmployeeLastName> - <JobTitle>
            foreach (var dep in departmentsOver5Emp)
            {
                sb.AppendLine($"{dep.Name} - {dep.FirstName} {dep.LastName}");
                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //Task 11
        public static string GetLatestProjects(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();
            var last10ProjectsInfo = context.Projects.OrderByDescending(x => x.StartDate).Take(10).OrderBy(x => x.Name).Select(x => new { x.Name, x.Description, x.StartDate }).ToList();

            foreach (var proj in last10ProjectsInfo)
            {
                sb.AppendLine(proj.Name);
                sb.AppendLine(proj.Description);
                sb.AppendLine($"{proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }
            return sb.ToString().TrimEnd();
        }

        //Task 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            //Departments which salaries must be increased are chained into array.
            string[] departmentsAffectedArr = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employeesSalaryIncrease = context.Employees.Where(x => departmentsAffectedArr.Contains(x.Department.Name)).ToList();

            employeesSalaryIncrease.ForEach(x => x.Salary *= 1.12m);

            //context.SaveChanges();

            foreach (var e in employeesSalaryIncrease.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();
            var employeesWithSa = context.Employees.Select(n => new
            {
                FirstName = n.FirstName,
                LastName = n.LastName,
                JTitle = n.JobTitle,
                Salary = n.Salary
            }).Where(x => x.FirstName.StartsWith("Sa")).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            foreach (var item in employeesWithSa)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JTitle} - (${item.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        // Task 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projectToDelete = context.Projects.FirstOrDefault(x => x.ProjectId == 2);

            var employeeProjectsToDelete = context.EmployeesProjects.Where(x => x.ProjectId == projectToDelete.ProjectId).ToList();

            context.RemoveRange(employeeProjectsToDelete);
            context.Remove(projectToDelete);
            //context.SaveChanges();

            var newProjectsLeft = context.Projects.ToList().Take(10);
            foreach (var prj in newProjectsLeft)
            {
                sb.AppendLine(prj.Name);
            }

            return sb.ToString().TrimEnd();
        }

        // Task 15
        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            //var townToDel = context.Towns.Find("Seattle");
            Town townToDel = context.Towns.Where(t => t.Name == "Seattle").FirstOrDefault();

            if (townToDel != null)
            {// First we need to delete [Employee - AdressId] -FK  == [Adresses - AdressId] -PK  -> we detach 1st relation
                //Then All Addresses of Employees which reference [Towns - TownId] =  [Adresses - TownId]
                //Finally we can delete the Town which corresponds to name "Seattle"

                List<Address> addressesToDelete = context.Addresses.Where(a => a.TownId == townToDel.TownId).ToList();

                Address address = context.Addresses.FirstOrDefault(x => x.TownId == townToDel.TownId);

                List<Employee> emplAddressesToBeSetNullFirst = context.Employees.Where(x => x.AddressId == address.AddressId).ToList();

                emplAddressesToBeSetNullFirst.ForEach(x => x.AddressId = null);

                context.RemoveRange(addressesToDelete);

                context.Remove(townToDel);
                context.SaveChanges();
                sb.AppendLine($"{addressesToDelete.Count()} addresses in Seattle were deleted");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
