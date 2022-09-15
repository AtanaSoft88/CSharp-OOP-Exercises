namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private static StringBuilder sb = new StringBuilder();
        private static string rootName = "";
        private static string ErrorMsg = "Invalid Data";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            sb.Clear();
            var departmentsAndCellsDto = JsonConvert.DeserializeObject<ImportDepartmentAndCellsDTO[]>(jsonString);
            foreach (var dto in departmentsAndCellsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }
                if (!dto.Cells.Any())
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }
                var department = new Department
                {
                    Name = dto.Name,
                };
                bool isCellInvalid = false;
                foreach (var cellDto in dto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(ErrorMsg);
                        isCellInvalid = true;
                        break;
                    }
                    var cell = new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow,
                    };

                    department.Cells.Add(cell);
                }
                if (isCellInvalid) { continue; }
                context.Departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count()} cells");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            sb.Clear();
            var prisonersWithMailsDto = JsonConvert.DeserializeObject<ImportPrisonersMailsDTO[]>(jsonString);
            foreach (var dto in prisonersWithMailsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var incarcerationDateValid = DateTime.TryParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var incarcerationDateResult);
                if (!incarcerationDateValid)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }


                DateTime? dateResult = null; // Because ReleaseDate in Models is nullable by default
                bool isValidDate = DateTime.TryParseExact(dto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }
                dateResult = date;

                var prisoner = new Prisoner
                {
                    FullName = dto.FullName,
                    Nickname = dto.Nickname,
                    Age = dto.Age,
                    IncarcerationDate = incarcerationDateResult,
                    ReleaseDate = dateResult,
                    Bail = dto.Bail,
                    CellId = dto.CellId,
                };

                foreach (var mDto in dto.Mails)
                {
                    if (!IsValid(mDto))
                    {
                        sb.AppendLine(ErrorMsg);
                        continue;
                    }
                    var mail = new Mail
                    {
                        Description = mDto.Description,
                        Sender = mDto.Sender,
                        Address = mDto.Address,
                    };

                    prisoner.Mails.Add(mail);
                }
                context.Prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            sb.Clear();
            rootName = "Officers";
            var officersPrisonersDto = DeserializerCustom<ImportOfficersPrisonersDTO[]>(xmlString, rootName);

            foreach (var dto in officersPrisonersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var psn = new Position();
                bool isParsedPsn = Enum.TryParse(dto.Position, ignoreCase: false, out psn);
                if (!isParsedPsn)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var wpn = new Weapon();
                bool isParsedWpn = Enum.TryParse(dto.Weapon, ignoreCase: false, out wpn);
                if (!isParsedWpn)
                {
                    sb.AppendLine(ErrorMsg);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = dto.FullName,
                    Salary = dto.Salary,
                    Position = psn,
                    Weapon = wpn,
                    DepartmentId = dto.DepartmentId,
                };

                foreach (var prId in dto.Prisoners)
                {                    
                    var offPrisoner = new OfficerPrisoner
                    {
                        Officer = officer,
                        PrisonerId = prId.Id,

                    };

                    officer.OfficerPrisoners.Add(offPrisoner);
                }

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count()} prisoners)");
                context.Officers.Add(officer);

            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
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