namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        public static string rootName = "";

        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            rootName = "Plays";            
            var playsDto = DeserializerCustom<ImportPlaysDTO[]>(xmlString, rootName);
            var plays = new List<Play>();
            foreach (var dto in playsDto) 
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact(dto.Duration,"c",CultureInfo.InvariantCulture,out var resultDuration);
                if (!isDurationValid || resultDuration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
               
                bool iSGenreValid = Enum.TryParse<Genre>(dto.Genre, ignoreCase: false, out Genre validGenre);
                if (!iSGenreValid) 
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play 
                { 
                    Title = dto.Title,
                    Duration = resultDuration,
                    Rating = dto.Rating,
                    Genre = validGenre,
                    Description = dto.Description,
                    Screenwriter = dto.Screenwriter,
                };
                plays.Add(play);
                sb.AppendLine($"Successfully imported {play.Title} with genre {play.Genre} and a rating of {play.Rating}!");
            }
            context.Plays.AddRange(plays);
            context.SaveChanges();  
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            rootName = "Casts";
            var castsDto = DeserializerCustom <ImportCastsDTO[]> (xmlString,rootName);
            var casts = new List<Cast>();
            foreach (var dto in castsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var cast = new Cast 
                { 
                    FullName = dto.FullName,
                    IsMainCharacter = dto.IsMainCharacter,
                    PhoneNumber = dto.PhoneNumber,
                    PlayId = dto.PlayId,
                };
                
                var character = cast.IsMainCharacter == true ? "main" : "lesser";

                casts.Add(cast);
                sb.AppendLine($"Successfully imported actor {cast.FullName} as a {character} character!");
            }
            context.Casts.AddRange(casts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var theatreTicketsDto = JsonConvert.DeserializeObject<ImportProjectionDTO[]>(jsonString);
            var theatres = new List<Theatre>();
            foreach (var dto in theatreTicketsDto) 
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre 
                {
                    Name = dto.Name,
                    NumberOfHalls = dto.NumberOfHalls,
                    Director = dto.DirectorName,

                };

                foreach (var dTicket in dto.Tickets)
                {
                    if (!IsValid(dTicket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var ticket = new Ticket
                    {
                        Price = dTicket.Price,
                        RowNumber = dTicket.RowNumber,
                        PlayId = dTicket.PlayId,        //PlayId will be always valid.
                    };
                    theatre.Tickets.Add(ticket);
                }
                theatres.Add(theatre);
                sb.AppendLine($"Successfully imported theatre {theatre.Name} with #{theatre.Tickets.Count} tickets!");
            }
            context.Theatres.AddRange(theatres);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
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
