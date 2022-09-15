namespace Footballers.DataProcessor
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
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        public static string rootName = "";
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            rootName = "Coaches";
            var coachesDto = DeserializerCustom<ImportCoachesDTO[]>(xmlString, rootName);
            

            foreach (var dto in coachesDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coach = new Coach
                {
                    Name = dto.NameCoach,
                    Nationality = dto.Nationality,

                };               


                foreach (var dtoF in dto.Footballers)
                {
                    if (!IsValid(dtoF))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    bool isValidDateStart = DateTime.TryParseExact(dtoF.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out  var dateStart);
                    if (!isValidDateStart)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isValidDateEnd = DateTime.TryParseExact(dtoF.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateEnd);
                    if (!isValidDateEnd)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dateStart > dateEnd)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    coach.Footballers.Add(new Footballer
                    {
                        Name = dtoF.NameFootballer,
                        ContractStartDate = dateStart,
                        ContractEndDate = dateEnd,
                        BestSkillType = (BestSkillType)dtoF.BestSkillType,
                        PositionType = (PositionType)dtoF.PositionType
                    });
                   
                }
                sb.AppendLine($"Successfully imported coach - {coach.Name} with {coach.Footballers.Count} footballers.");
                

                context.Coaches.Add(coach);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();

        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            
            var teamsDto = JsonConvert.DeserializeObject<ImportTeamsDTO[]>(jsonString);

            foreach (var dto in teamsDto)
            {
                if (!IsValid(dto) || dto.Trophies <=0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                    Trophies = dto.Trophies

                };               
                                
                foreach (var dtoFb in dto.Footballers.Distinct())
                {
                    var footballer = context.Footballers.FirstOrDefault(x=>x.Id==dtoFb);
                    if (footballer == null) 
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer {Footballer = footballer });
                }
                team.TeamsFootballers.Select(x=>x.Footballer.Name).Distinct();
                sb.AppendLine($"Successfully imported team - {team.Name} with {team.TeamsFootballers.Count} footballers.");
                context.Teams.Add(team);
                context.SaveChanges();
            }

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
        }

    }
}
