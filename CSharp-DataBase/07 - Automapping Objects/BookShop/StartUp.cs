namespace BookShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BookShop.DTO;
    using BookShop.Models;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            //AutoMapper - installed packages
            //If Console doesnt read Unicode-> 
            //Console.OutputEncoding = Encoding.Unicode;

            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);            


            var config = new MapperConfiguration(cfg =>
            { // This is configured in different class --> DtoMappingProfile : Profile
                //It can be written 2 ways
                cfg.AddProfile<DtoMappingProfile>(); //1
                cfg.AddProfile(new DtoMappingProfile()); //2

            });

            var mapper =config.CreateMapper();


            var booksAutomapped = db.Books.Where(b => b.BookId == 3)
                //.Select(x => new BookDTO
                //{

                //    Title = x.Title,
                //    Description = x.Description,
                //    Price = x.Price,
                //    Copies = x.Copies

                //})
                .ProjectTo<BookDTO>(config)
                .ToList();

            var authorsAutomapped = db.Authors.Where(b => b.AuthorId == 2)
                .ProjectTo<AuthorDTO>(config).ToList();


            //-------------------
            //From AuthorAndBookDTO Class with mixed properties taken from 3 different tables,using ProjectTo<ClassDto>(configMapper)
            var authorAndBookInfo = db.Authors
                .Where(x=>x.Books
                .Select(y=>y.Price<=18.25m)
                .First())
                .Where(x=>x.LastName
                .Contains("nova"))
                .ProjectTo<AuthorAndBookDTO>(config)
                .ToList();
            Console.WriteLine(JsonConvert.SerializeObject(authorAndBookInfo, Formatting.Indented)); // into json
            
            //-------------------
            
            //We create Method "GetBookAndAuthors" which returns collection of our Class which contains manually mapped properties (combination of both classes -> Book , Author) exactly the those we need!
           IEnumerable<AuthorAndBookDTO> collectionAuthorAndBooks = GetBookAndAuthors(db,"B");
            
                        
        }

        public static IEnumerable<AuthorAndBookDTO> GetBookAndAuthors(BookShopContext dbContext, string startsWith)
        {
            var booksAndAuthors = dbContext.Authors.Where(a => a.FirstName.StartsWith(startsWith)).Select(obj => new AuthorAndBookDTO
            {
                FullName = $"{obj.FirstName} {obj.LastName}",
                Title = obj.Books.First().Title,
                Price = obj.Books.First().Price,
                CategoryName = obj.Books.First().BookCategories.First().Category.Name,
                          

            }).ToList();

            return booksAndAuthors;
        }
    }
}
