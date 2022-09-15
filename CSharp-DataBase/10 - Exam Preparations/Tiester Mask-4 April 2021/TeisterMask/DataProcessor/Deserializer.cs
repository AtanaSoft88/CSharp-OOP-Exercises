namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var rootName = "Projects";
            var projectsDTO = DeserializerCustom<ProjectsImportDTO[]>(xmlString, rootName);
            StringBuilder sb = new StringBuilder();
            foreach (var dto in projectsDTO)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //Open Project Date
                var isOpenProjDateParsed = DateTime
                    .TryParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var resOpenProjDate);
                if (!isOpenProjDateParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //Due Project Date - we make nullable DateTime to write the value as null if null and correct date if parse succeeds
                DateTime? nullableDateTime = null;

                if (dto.DueDate!=null && dto.DueDate!=String.Empty)
                {
                    var isDueProjDateParsed = DateTime
                     .TryParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var resDueProjDate);
                    if (!isDueProjDateParsed)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    nullableDateTime = resDueProjDate;
                }
                



                var project = new Project
                {
                    Name = dto.Name,
                    OpenDate = resOpenProjDate,
                    DueDate = nullableDateTime

                };

                
                //Collection Tasks.OpenDates
                var tasksDto = dto.Tasks;                
                foreach (var currentTask in tasksDto)
                {
                    if (!IsValid(currentTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var isTaskOpenDateParsed = DateTime
                   .TryParseExact(currentTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var resTaskOpenDate);
                    if (!isTaskOpenDateParsed)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //Collection Tasks.DueDates
                    var isTaskDueDateParsed = DateTime
                    .TryParseExact(currentTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var resTaskDueDate);
                    if (!isTaskDueDateParsed)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (resTaskOpenDate < resOpenProjDate || resTaskDueDate > nullableDateTime)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    project.Tasks.Add(new Task 
                    {
                        Name=currentTask.Name,
                        OpenDate= resTaskOpenDate,
                        DueDate = resTaskDueDate ,
                        ExecutionType = (ExecutionType)currentTask.ExecutionType,
                        LabelType = (LabelType)currentTask.LabelType

                    });
                }            
                                         
                               
                
                context.Projects.Add(project);
                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count()} tasks.");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeesDTO[]>(jsonString);
            foreach (var emp in employeesDto)
            {
                if (!IsValid(emp))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }                

                var employee = new Employee
                {
                    Username = emp.Username,
                    Email = emp.Email,
                    Phone = emp.Phone,
                    
                };                                

                foreach (var taskId in emp.Tasks.Distinct())
                {
                    if (!IsValid(taskId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task dbTask = context.Tasks.Where(x => x.Id == taskId).FirstOrDefault();

                    if (dbTask==null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    employee.EmployeesTasks.Add(new EmployeeTask 
                    { 
                        Task = dbTask 
                    });

                }
                context.Employees.Add(employee);
                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count()} tasks.");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public static T DeserializerCustom<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
                .Deserialize(reader);

            return dtos;
        } // Usefull Method fm XML file to ClassDto[]
    }
}