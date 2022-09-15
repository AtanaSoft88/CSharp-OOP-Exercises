namespace VaporStore.DataProcessor
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
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public const string InvalidData = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var gamesDto = JsonConvert.DeserializeObject<IEnumerable<ImportGamesDTO>>(jsonString);
            foreach (var dto in gamesDto)
            {
                if (!IsValid(dto) || dto.Tags.Count() == 0)
                {
                    sb.AppendLine(InvalidData);
                    continue;
                }

                //var isDateValid = DateTime.TryParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateResult);

                //if (!isDateValid)
                //{
                //    sb.AppendLine(InvalidData);
                //    continue;
                //}

                Developer developer = context.Developers.Where(x => x.Name == dto.DeveloperName).FirstOrDefault() ?? new Developer
                {
                    Name = dto.DeveloperName,
                };

                Genre genre = context.Genres.FirstOrDefault(x => x.Name == dto.Genre) ?? new Genre
                {
                    Name = dto.Genre,
                };

                var game = new Game
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = dto.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var dtoT in dto.Tags)
                {
                    var tag = context.Tags.Where(t => t.Name == dtoT).FirstOrDefault() ?? new Tag
                    {
                        Name = dtoT
                    };

                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag,
                    });

                }
                context.Games.Add(game);
                sb.AppendLine($"Added {dto.Name} ({dto.Genre}) with {dto.Tags.Count()} tags");
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();


            //foreach (var dto in gamesDto)
            //{
            //    if (!IsValid(dto) || dto.Tags.Count() == 0)
            //    {
            //        sb.AppendLine(InvalidData);
            //        continue;
            //    }
            //    //•	If a game is invalid, do not import its genre, developer or tags.
            //    //•	If a developer/genre/tag with that name doesn’t exist, create it. 


            //    Developer developer = context.Developers.FirstOrDefault(x => x.Name == dto.DeveloperName) ?? new Developer
            //    {                                                                                   //if it is null
            //        Name = dto.DeveloperName,
            //    };

            //    Genre genre = context.Genres.FirstOrDefault(x => x.Name == dto.Genre) ?? new Genre
            //    {
            //        Name = dto.Genre,
            //    };

            //    //var isDateValid = DateTime.TryParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateResult);

            //    //if (!isDateValid)
            //    //{
            //    //    sb.AppendLine(InvalidData);
            //    //    continue;
            //    //}

            //    var game = new Game
            //    {
            //        Name = dto.Name,
            //        Genre = genre,
            //        Developer = developer,
            //        Price = dto.Price,
            //        ReleaseDate = dto.ReleaseDate.Value,


            //    };

            //    foreach (var jsonTag in dto.Tags)
            //    {
            //        Tag tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag) ?? new Tag
            //        {
            //            Name = jsonTag,
            //        };
            //        game.GameTags.Add(new GameTag { Tag = tag });
            //    }


            //    context.Games.Add(game);
            //    context.SaveChanges();
            //    sb.AppendLine($"Added {dto.Name} ({dto.Genre}) with {dto.Tags.Count()} tags");
            //}
            //return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var usersDto = JsonConvert.DeserializeObject<IEnumerable<ImportUsersDTO>>(jsonString);

            foreach (var uDto in usersDto)
            {
                if (!IsValid(uDto) || !uDto.Cards.All(IsValid))
                {
                    sb.AppendLine(InvalidData);
                    continue;
                }

                foreach (var card in uDto.Cards) //This foreach can be replaced by "!uDto.Cards.All(IsValid)" from upper "if"statement
                {
                    if (!IsValid(card))
                    {
                        sb.AppendLine(InvalidData);
                        continue;
                    }
                }
                //When chosen type in DTO to be string instead of Enumeration - we must Enum.TryParse!

                //var card = new Card() { };
                //            CardType result = card.Type;
                //            var str = uDto.Cards.Select(x => x.Type).First();
                //            var valueCanParse = Enum.TryParse(str, ignoreCase: false, out result);
                //            if (!valueCanParse)
                //            {
                //                sb.AppendLine(InvalidData);
                //                continue;
                //            }

                //            var user = new User() 
                //{ 
                //	Username = uDto.Username,
                //	FullName = uDto.FullName,
                //	Email = uDto.Email,
                //	Age = uDto.Age,
                //	Cards = uDto.Cards.Select(x=> new Card 
                //	{
                //		Number = x.Number,
                //		Cvc =x.CVC,
                //		Type = result

                //	}).ToList()
                //};


                //If we used The Enumeration in DTO as type of Enum ( no matter in json file it is as String) , json will parse it for us but we must put Attribute [Required] and nullable "?" for this property in DTO ,so if parsed correctly it will pass ,or if null will not pass! Code is less and easier to write!

                var user = new User()
                {
                    Username = uDto.Username,
                    FullName = uDto.FullName,
                    Email = uDto.Email,
                    Age = uDto.Age,
                    Cards = uDto.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.CVC,
                        Type = x.Type.Value

                    }).ToList()
                };


                context.Users.Add(user);
                sb.AppendLine($"Imported {uDto.Username} with {uDto.Cards.Count()} cards");
                context.SaveChanges();

            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sbr = new StringBuilder();
            string rootName = "Purchases";
            var purchasesDto = DeserializerCustom<List<ImportPurchasesDTO>>(xmlString, rootName);
            foreach (var purchDto in purchasesDto)
            {
                if (!IsValid(purchDto))
                {
                    sbr.AppendLine(InvalidData);
                    continue;
                }

                var isDateParsed = DateTime.TryParseExact(purchDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);
                if (!isDateParsed)
                {
                    sbr.AppendLine(InvalidData);
                    continue;
                }

                //If in DTO the Type was described as a String ,we would need to TryParse as below ->
                //var isParsable = Enum.TryParse<PurchaseType>(purchDto.Type, ignoreCase: false, out var resultEnum);
                //if (!isParsable)
                //{
                //    sbr.AppendLine(InvalidData);
                //    continue;
                //}                              

                var purchase = new Purchase
                {
                    Date = dateTime,
                    Type = purchDto.Type.Value,
                    ProductKey = purchDto.Key,
                    //For finding the Nav.Properties we need to search in CONTEXT with FirstOrDefault()!  
                    Game = context.Games.FirstOrDefault(x => x.Name == purchDto.GameName), // Nav property -> search into context!
                    Card = context.Cards.FirstOrDefault(x => x.Number == purchDto.Card), // Nav property -> search into context!

                };
                //purchase.Card=context.Cards.FirstOrDefault(x=>x.Number == purchDto.Card);
                //purchase.Game = context.Games.FirstOrDefault(x => x.Name == purchDto.Title);

                context.Purchases.Add(purchase);

                var userName = context.Users.Where(x => x.Id == purchase.Card.UserId).Select(x => x.Username).FirstOrDefault();
                sbr.AppendLine($"Imported {purchDto.GameName} for {userName}");
            }
            context.SaveChanges();
            return sbr.ToString().TrimEnd();
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