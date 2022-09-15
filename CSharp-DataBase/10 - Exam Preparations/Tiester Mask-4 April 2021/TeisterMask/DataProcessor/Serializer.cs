namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var rootName = "Projects";
            var projectsDto = context.Projects.ToArray().Where(x => x.Tasks.Any()).Select(p => new ExportProjectsWithTasksDTO 
            {
                TaskCount = p.Tasks.Count(),
                ProjectName = p.Name,
                HasEndDate = p.DueDate.HasValue?"Yes":"No",
                Tasks = p.Tasks.Select(t=> new TaskDTO 
                { 
                    TaskName = t.Name,
                    TaskLabel = t.LabelType.ToString()
                }).OrderBy(t=>t.TaskName).ToArray()

            }).OrderByDescending(tc=>tc.TaskCount).ThenBy(p=>p.ProjectName).ToArray();
            var projectsString = SerializerCustom<ExportProjectsWithTasksDTO[]>(projectsDto,rootName);
            return projectsString;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            //When you OrderBy ->DateTime and NEED SPECIAL FORMAT, cant be done only after the Query in JsonSerializerSettings as below!
            var employees = context.Employees.ToList().Where(t => t.EmployeesTasks.Any(x => x.Task.OpenDate >= date)).Select(e => new 
            {
                Username = e.Username,
                Tasks = e.EmployeesTasks.Where(t=>t.Task.OpenDate>=date).Select(et=> new 
                {
                    TaskName= et.Task.Name ,
                    OpenDate = et.Task.OpenDate, // if you ToString("date-format") -> you wont be able to Order by this date!
                    DueDate = et.Task.DueDate, // if you ToString("date-format") -> you wont be able to Order by this date!
                    LabelType = et.Task.LabelType.ToString() ,
                    ExecutionType = et.Task.ExecutionType.ToString() ,
                }).OrderByDescending(x=>x.DueDate).ThenBy(x=>x.TaskName)
            }).OrderByDescending(t=>t.Tasks.Count()).ThenBy(u=>u.Username).Take(10).ToList();

            var jsonSettings = new JsonSerializerSettings() 
            { //Here the upper Query is has been already Ordered and now a format can be selected for the json file output!
               DateFormatString = "MM/dd/yyyy"
            };
            var stringJsonBussiestEmployees = JsonConvert.SerializeObject(employees, Formatting.Indented, jsonSettings);
            return stringJsonBussiestEmployees;
        }

        private static string SerializerCustom<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty); // This way we delete any namespaces trails for judje!

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }       // Usefull Method fm ClassDto[] to XML file
    }
}