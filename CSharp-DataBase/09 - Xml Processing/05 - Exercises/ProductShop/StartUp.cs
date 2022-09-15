using ProductShop.Data;
using ProductShop.DTO.EXPORT_DTO;
using ProductShop.DTO.IMPORT_DTO;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static string rootName = "";
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            DataBaseRebuilder(context);

            //Task 1 Import Users
            var inputXml1 = File.ReadAllText(@"..\..\..\Datasets\users.xml");
            Console.WriteLine(ImportUsers(context, inputXml1));

            //Task 2 Import Products
            var inputXml2 = File.ReadAllText(@"..\..\..\Datasets\products.xml");
            Console.WriteLine(ImportProducts(context, inputXml2));

            //Task 3 Import Categories
            var inputXml3 = File.ReadAllText(@"..\..\..\Datasets\categories.xml");
            Console.WriteLine(ImportCategories(context, inputXml3));

            //Task 4 Import Categories and Products
            var inputXml4 = File.ReadAllText(@"..\..\..\Datasets\categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(context, inputXml4));

            //Task 5 Export Products In Range
            // Console.WriteLine(GetProductsInRange(context));

            //Task 6
            //Console.WriteLine(GetSoldProducts(context));

            //Task 7
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //Task 8
            //Console.WriteLine(GetUsersWithProducts(context));
        }
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult);
            return isValid;
        } // Validator

        private static T Deserializer<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
                .Deserialize(reader);

            return dtos;
        } // Usefull Method fm XML file to ClassDto[]
        private static string Serializer<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }       // Usefull Method fm ClassDto[] to XML file

        public static void DataBaseRebuilder(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        //Task 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            rootName = "Users";
            var usersDto = Deserializer<ImportUserDTO[]>(inputXml, rootName);
            List<User> users = new List<User>();
            foreach (var uDTO in usersDto)
            {
                var user = new User
                {
                    FirstName = uDTO.FirstName,
                    LastName = uDTO.LastName,
                    Age = uDTO.Age,
                };
                users.Add(user);
            }

            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}"; ;
        }

        //Task 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            rootName = "Products";
            var productsDto = Deserializer<ImportProductDTO[]>(inputXml, rootName);
            List<Product> products = new List<Product>();
            foreach (var item in productsDto)
            {
                var product = new Product
                {
                    Name = item.Name,
                    Price = item.Price,
                    SellerId = item.SellerId,
                    BuyerId = item.BuyerId,
                };
                products.Add(product);
            }
            context.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Count}";
        }

        //Task 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            rootName = "Categories";
            var categoriesDto = Deserializer<ImportCategoriesDTO[]>(inputXml, rootName);
            var categories = new List<Category>();
            foreach (var cat in categoriesDto)
            {
                if (cat.Name is null)
                {
                    continue;
                }
                var category = new Category
                {
                    Name = cat.Name,
                };
                categories.Add(category);
            }
            context.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        //Task 4

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            rootName = "CategoryProducts";
            var categoryProductsDto = Deserializer<ImportCategoryProductDTO[]>(inputXml, rootName);
            var categoryProducts = new List<CategoryProduct>();
            foreach (var catProd in categoryProductsDto)
            {
                //Special Validator checking all the properties of the class for valid info
                if (!IsValid(catProd))
                {
                    continue;
                }
                //Workaraound with convertion to String and check for Empty String!
                /*
                if (catProd.CategoryId.ToString() == "" || catProd.ProductId.ToString() == "")
                {
                    continue;
                }
                */
                var categoryProduct = new CategoryProduct
                {
                    CategoryId = catProd.CategoryId,
                    ProductId = catProd.ProductId,
                };

                categoryProducts.Add(categoryProduct);
            }
            context.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }

        //Task 5 - Export

        public static string GetProductsInRange(ProductShopContext context)
        {
            rootName = "Products";

            var productsInRangeDto = context.Products.Where(p => p.Price >= 500 && p.Price < 1000).Select(x => new ExportProductsInRangeDTO
            {
                Name = x.Name,
                Price = x.Price,
                // Doesnt work with ->>BuyerFullName = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                BuyerFullName = x.Buyer.FirstName + " " + x.Buyer.LastName,
            }).OrderBy(x => x.Price).Take(10).ToList();


            var productsInRange = Serializer<List<ExportProductsInRangeDTO>>(productsInRangeDto, rootName);
            return productsInRange;


        }

        //Task 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            rootName = "Users";
            //1) Using Select

            var usersSoldProductsDto = context.Users.Where(sp => sp.ProductsSold.Any()).Select(x => new UsersWithSoldProductsDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                SoldProducts = x.ProductsSold.Select(ps => new UserProductDTO
                {
                    Name = ps.Name,
                    Price = ps.Price
                }).ToList()

            }).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).Take(5).ToList();

            //2) Using foreach
            //var usersSoldProducts = context.Users.Where(sp => sp.ProductsSold.Any()).ToList();
            //var usrWithSoldProdsDto = new List<UsersWithSoldProductsDTO>();
            //foreach (var user in usersSoldProducts)
            //{
            //    var userSoldProductsDto = new UsersWithSoldProductsDTO
            //    {
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,                   
            //        SoldProducts = user.ProductsSold.Select(x=> new UserProductDTO 
            //        { 
            //            Name = x.Name,
            //            Price = x.Price
            //        }).ToList()
            //    };             

            //    usrWithSoldProdsDto.Add(userSoldProductsDto);

            //}
            //usrWithSoldProdsDto = usrWithSoldProdsDto.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).Take(5).ToList();


            var resultXml = Serializer<List<UsersWithSoldProductsDTO>>(usersSoldProductsDto, rootName);

            return resultXml;
        }

        //Task 7
        public static string GetCategoriesByProductsCount(ProductShopContext context) 
        {
            rootName = "Categories";
            var catergoriesByProdCount = context.Categories.Select(x => new CategoryByProductCountDTO 
            {
                Name= x.Name,
                Count = x.CategoryProducts.Count(),
                AvgPrice = x.CategoryProducts.Average(x=>x.Product.Price),
                TotalRevenue = x.CategoryProducts.Sum(x=>x.Product.Price),
            }).OrderByDescending(x=>x.Count).ThenBy(x=>x.TotalRevenue).ToList();

            var result = Serializer(catergoriesByProdCount,rootName);
            return result;
        }

        //Task 8

        public static string GetUsersWithProducts(ProductShopContext context) 
        {
            rootName = "Users";
            var usersCount = context.Users.Where(x => x.ProductsSold.Any()).ToList();
            var usersAtLeastASoldProduct = context.Users.ToList().Where(u => u.ProductsSold.Any()).Select(x => new ExportUsersDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                SoldProduct = new ExportProductCountDTO
                {
                    Count = x.ProductsSold.Count(),
                    Products = x.ProductsSold.Select(x=>new ExportProductDto 
                    { 
                        Name = x.Name,
                        Price=x.Price
                    }).OrderByDescending(x=>x.Price).ToList()


                }


            }).OrderByDescending(x=>x.SoldProduct.Count).Take(10).ToList();

            var resultDto = new ExportUsersCountDTO
            {
                Count = usersCount.Count,
                Users = usersAtLeastASoldProduct,
            };

            var result = Serializer(resultDto, rootName);
            //File.WriteAllText(@"..\..\..\GetUsersWithProducts.xml", result);
            return result;
        }
    }
}