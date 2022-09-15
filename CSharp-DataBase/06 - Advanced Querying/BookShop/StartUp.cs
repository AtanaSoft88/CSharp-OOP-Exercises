using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var dbcontext = new BookShopContext();
            DbInitializer.ResetDatabase(dbcontext);

            //2. Age Restriction - Enumeration - different ways to solve the problem!

            string result = GetBooksByAgeRestriction(dbcontext, "miNor"); //teEN , miNor
            Console.WriteLine(result);

            // 3. Golden Books

            //Console.WriteLine(GetGoldenBooks(dbcontext));

            //4. Books by Price

            //Console.WriteLine(GetBooksByPrice(dbcontext));

            //5. Not Released In
            //Console.WriteLine(GetBooksNotReleasedIn(dbcontext,2000));

            //6. Book Titles by Category
            //Console.WriteLine(GetBooksByCategory(dbcontext, "horror mystery drama"));

            //7. Released Before Date

            //Console.WriteLine(GetBooksReleasedBefore(dbcontext, "12-04-1992"));

            //8. Author Search

            //Console.WriteLine(GetAuthorNamesEndingIn(dbcontext, "e"));

            //9. Book Search

            //Console.WriteLine(GetBookTitlesContaining(dbcontext, "sK"));


            //10.Book Search by Author

            //Console.WriteLine(GetBooksByAuthor(dbcontext,"R"));

            //11. Count Books

            //Console.WriteLine(CountBooks(dbcontext,40));

            // 12. Total Book Copies

            /*
              //Using Navigational property of type Collection of Book - Books ,which has method Sum(c=>c.Copies)
             */
            //Console.WriteLine(CountCopiesByAuthor(dbcontext));

            //13. Profit by Category

            //Console.WriteLine(GetTotalProfitByCategory(dbcontext));

            //14. Most Recent Books

            //Console.WriteLine(GetMostRecentBooks(dbcontext));

            //15. Increase Prices

            //IncreasePrices(dbcontext);

            //16. Remove Books

            //Console.WriteLine(RemoveBooks(dbcontext));
        }

        // Remove Range of Books
        //public static int RemoveBooks(BookShopContext dbContext)
        //{
        //    Book[] books = dbContext
        //        .Books
        //        .Where(b => b.Copies < 4200)
        //        .ToArray();

        //    dbContext.Books.RemoveRange(books);
        //    dbContext.SaveChanges();

        //    return books.Length;
        //}

        //Increase Book Prices
        //public static void IncreasePrices(BookShopContext dbContext)
        //{
        //    Book[] books = dbContext
        //        .Books
        //        .Where(b => b.ReleaseDate.Value.Year < 2010)
        //        .ToArray();

        //    foreach (Book book in books)
        //    {
        //        book.Price += 5;
        //    }

        //    dbContext.SaveChanges();
        //}

        //Task 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)//AgeRestriction – enum (Minor,Teen,Adult)
        {
            //Variant 1 - Enum.Parse ->> returned Object
            //In Enum.Parse : we have 1)Exact typeof(nameEnum), 2) string we are parsing to, and 3) as last parameter "ignore case" which will ignore Upper/Lower letters when set to "true". It finally returns Object ,so to use it we have to cast as exact name of enum

            Object ageRestriction1 = Enum.Parse(typeof(AgeRestriction), command, true); // below we must Cast as "name of the enum" data type
            var booksByAgeRestriction1 = context.Books.Where(b => b.AgeRestriction == (AgeRestriction)ageRestriction1).Select(t => t.Title).OrderBy(x => x).ToList();


            //Variant 2 - using Generics "Enum.Parse<nameEnum>" - directly returns Enum data type!            
            var ageRestriction2 = Enum.Parse<AgeRestriction>(command, true);
            var booksByAgeRestriction2 = context.Books
                .Where(b => b.AgeRestriction == ageRestriction2)
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToArray();

            //Variant 3 - This is my way to solve the problem with ToLower()
            var booksByAgeRestriction3 = context.Books
                .ToList()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToList();


            string result = string.Join(Environment.NewLine, booksByAgeRestriction2);
            return result;


        }


        //Task 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            //Variant 1 - ToString() -> gets and compares the string representation of enumeration to the "Gold" - which is the target
            var goldenBooks1 = context.Books
                .ToList()
                .Where(b => b.EditionType
                .ToString() == "Gold" && b.Copies < 5000)
                .OrderBy(x => x.BookId).Select(t => t.Title)
                .ToList();

            //Variant 2 - Using Generic -> parse the Enumeration
            string goldenType = "Gold";
            var goldenBookEnum = Enum.Parse<EditionType>(goldenType, true);
            var goldenBooks2 = context.Books
                .ToList()
                .Where(b => b.EditionType == goldenBookEnum && b.Copies < 5000)
                .OrderBy(x => x.BookId).Select(t => t.Title)
                .ToList();

            return String.Join(Environment.NewLine, goldenBooks2);
        }

        //Task 4

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var titlesAndPrices = context.Books
                .Where(p => p.Price > 40)
                .Select(b => new { b.Price, b.Title })
                .OrderByDescending(x => x.Price)
                .ToArray();

            foreach (var book in titlesAndPrices)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //Task 5

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleasedIn = context.Books.Where(b => b.ReleaseDate.Value.Year != year).OrderBy(x => x.BookId).Select(t => t.Title).ToList();

            return String.Join(Environment.NewLine, booksNotReleasedIn);
        }

        //Task 6

        public static string GetBooksByCategory(BookShopContext context, string input) //horror mystery drama
        {
            string[] givenCategories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var booksTitlesByCategories = context.Books
                .Where(book => book.BookCategories.Any(bc => givenCategories.Contains(bc.Category.Name.ToLower())))
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToList();

            return String.Join(Environment.NewLine, booksTitlesByCategories);

        }

        //Task 7

        public static string GetBooksReleasedBefore(BookShopContext context, string date) //20/01/1998 
        {
            StringBuilder sb = new StringBuilder();
            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture); //Use "ParseExact" for a specific Date Format           
            var booksReleasedBeforeDate = context.Books
                .Where(b => b.ReleaseDate.Value < dt)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(info => new { info.Title, info.EditionType, info.Price })
                .ToList();

            return string.Join(Environment.NewLine, booksReleasedBeforeDate.Select(book => $"{book.Title} - {book.EditionType} - ${book.Price:f2}"));
        }

        //Task 8

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNamesEndingIn = context.Authors
                .ToList()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(n => $"{n.FirstName} {n.LastName}")
                .OrderBy(n => n)
                .ToList();

            return String.Join(Environment.NewLine, authorNamesEndingIn);
        }

        //Task 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookSearchedTitle = context.Books.Where(b => b.Title.ToLower().Contains(input.ToLower())).Select(t => t.Title).OrderBy(x => x).ToArray();

            return String.Join(Environment.NewLine, bookSearchedTitle);
        }

        //Task 10

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksTitlesByAuthor = context.Books.Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower())).OrderBy(x => x.BookId).Select(book => new
            {
                AuthorFullName = $"{book.Author.FirstName} {book.Author.LastName}",
                TitleOfBook = book.Title
            });

            return String.Join(Environment.NewLine, booksTitlesByAuthor.Select(at => $"{at.TitleOfBook} ({at.AuthorFullName})"));
        }

        //Task 11

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(t => t.Title.Length > lengthCheck).Count();
        }

        //Task 12

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            /*
            var totalCopiesByAuthor = context.Books
                .Include(x => x.Author)
                .ToList()
                .GroupBy(a => a.Author)
                .Select(auth => new
                {
                    FullNames = $"{auth.Key.FirstName} {auth.Key.LastName}",
                    TotalBookCopies = auth.Sum(x => x.Copies)
                }).OrderByDescending(x => x.TotalBookCopies).ToList();            

            return String.Join(Environment.NewLine, totalCopiesByAuthor.Select(x => $"{x.FullNames} - {x.TotalBookCopies}"));
            

            var authors = context.BooksCategories.Include(x=>x.Book).ThenInclude(a=>a.Author)

                .Select(a => new
                {
                   FullName = $"{a.Book.Author.FirstName} {a.Book.Author.LastName}",
                    Copies = a.Book.BookCategories.ToList().Sum(x=>x.Book.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            string result = string.Join(Environment.NewLine, authors.Select(a => $"{a.FullName} - {a.Copies}"));
            return result;
            */

            var totalCopiesByAuthor = context.Authors.Select(a => new
            {
                TotalCopies = a.Books.Sum(c => c.Copies),
                AuthorFullNames = $"{a.FirstName} {a.LastName}"
            }).OrderByDescending(tc => tc.TotalCopies).ToArray();

            return String.Join(Environment.NewLine, totalCopiesByAuthor.Select(x => $"{x.AuthorFullNames} - {x.TotalCopies}"));
        }

        //Task 13

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalProfitByCategoryBooks = context.Categories.Select(b => new
            {
                TotalProfit = b.CategoryBooks.Sum(p => p.Book.Price * p.Book.Copies),
                CategoryName = b.Name
            }).OrderByDescending(x => x.TotalProfit).ThenBy(x => x.CategoryName).ToList();

            return String.Join(Environment.NewLine, totalProfitByCategoryBooks.Select(outp => $"{outp.CategoryName} ${outp.TotalProfit:f2}"));
        }

        //Task 14

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var bookMostRecentByCategory = context.Categories.Select(cat => new
            {
                CategoryName = cat.Name,
                CollectionBooks = cat.CategoryBooks.Select(b => b.Book)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    ReleaseYear = b.ReleaseDate.Value.Year
                })
                .Take(3)
                .ToList()
            })
            .OrderBy(x => x.CategoryName)
            .ToList();

            foreach (var book in bookMostRecentByCategory)
            {
                sb.AppendLine($"--{book.CategoryName}");
                foreach (var item in book.CollectionBooks)
                {
                    sb.AppendLine($"{item.BookTitle} ({item.ReleaseYear})");
                }

            }
            return sb.ToString().TrimEnd();
        }

        //Task 15

        public static void IncreasePrices(BookShopContext context)
        {
            Book[] booksToIncrease = context.Books.Where(y => y.ReleaseDate.Value.Year < 2010).ToArray();

            foreach (var book in booksToIncrease)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        //Task 16

        public static int RemoveBooks(BookShopContext context)
        {
            Book[] booksToRemove = context.Books.Where(c => c.Copies < 4200).ToArray();
            context.RemoveRange(booksToRemove);
            context.SaveChanges();
            return booksToRemove.Length;           
        }
    }
}
