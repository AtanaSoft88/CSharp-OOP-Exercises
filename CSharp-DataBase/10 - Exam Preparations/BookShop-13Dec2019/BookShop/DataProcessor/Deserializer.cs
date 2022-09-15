namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
    
    public class Deserializer
    {
        public static IMapper mapper;
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            
            var rootName = "Books";
            var booksDto = DeserializerCustom<ImportBooksDTO[]>(xmlString,rootName);
            List<Book> books = new List<Book>();
            foreach (var bDto in booksDto) 
            {
                if (!IsValid(bDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime resultDT ;
                var isDateParsed = DateTime.TryParseExact(bDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out resultDT);
               
                if (!isDateParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var book = new Book 
                {
                    Name = bDto.Name,
                    Genre = (Genre)bDto.GenreNumb,
                    Price = bDto.Price,
                    Pages = bDto.Pages,
                    PublishedOn = resultDT
                };
                
                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
                books.Add(book);
                

            }
            context.Books.AddRange(books);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var authorsDto = JsonConvert.DeserializeObject<ImportAuthorsDTO[]>(jsonString);
            var authors = new List<Author>();
            foreach (var dto in authorsDto) 
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //•	If an email exists, do not import the author and append and error message.
                //That means we must create Collection of Authors and when add author we must check if the email exists inside this Collection of Authors,not in the Data Base!
                var emails = authors.Select(x => x.Email);
                if (emails.Contains(dto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var author = new Author 
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Phone = dto.Phone,

                };
                //•	If a book does not exist in the database, do not append an error message and continue with the next book.
                // books fm dto?!
                var booksDB = context.Books.Select(x=>x.Id).ToList();
                foreach (var bookId in booksDB)
                {
                    if (!dto.Books.Select(x=>x.Id).Contains(bookId))
                    {
                        continue;
                    }
                    author.AuthorsBooks.Add(new AuthorBook 
                    {
                        BookId = bookId
                    });
                }
                //•	If an author have zero books (all books are invalid) do not import the author and append an error message to the method output.
                if (!author.AuthorsBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                authors.Add(author);                
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, (author.FirstName + " " + author.LastName), author.AuthorsBooks.Count));
            }
            context.Authors.AddRange(authors);
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