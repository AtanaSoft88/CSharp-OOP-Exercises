using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //When you create the whole Data Base and fill with information through json files provided , comment these 2 rows below.
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Task 9 Import Suppliers

            var jsonSuppliers = File.ReadAllText(@"..//..//..//Datasets//suppliers.json");
            Console.WriteLine(ImportSuppliers(context, jsonSuppliers));

            //Task 10 Import Parts

            var jsonParts = File.ReadAllText(@"..//..//..//Datasets//parts.json");
            Console.WriteLine(ImportParts(context, jsonParts));

            //Task 11. Import Cars - PAY ATTENTION - The tricky moment Json file contains array of id's but that id's are repretitive somewhere
            //we need to access that id's and get only unique ,because error will arise if we let repetition of id's!
            string jsonCars = File.ReadAllText(@"..//..//..//Datasets//cars.json");
            Console.WriteLine(ImportCars(context, jsonCars));

            //Task 12. Import Customers
            string jsonCustomers = File.ReadAllText(@"..//..//..//Datasets//customers.json");
            Console.WriteLine(ImportCustomers(context, jsonCustomers));

            //Task 13.Import Sales
            string jsonSales = File.ReadAllText(@"..//..//..//Datasets//sales.json");
            Console.WriteLine(ImportSales(context, jsonSales));

            //Task 14. Export Ordered Customers 
            //On Export data When we use Select , we use Select(x=> new {Name1 = x.prop1,Name2=prop2,Name3=prop3})
            //Console.WriteLine(GetOrderedCustomers(context));

            //Task 15 Export Cars from Make Toyota 
            //On Export data When we use Select , we use Select(x=> new {Name1 = x.prop1,Name2=prop2,Name3=prop3})
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            //Task 16 Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(context));

            //Task 17 Export Cars with Their List of Parts            
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Task 18 Export Total Sales by Customer
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //Task 19 Export Sales with Applied Discount

            //Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        //Register AutoMapper - import in each method!
        public static void MapperRegister()
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
            mapper = mapConfig.CreateMapper();
        }

        //Task 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {   //Register automapper by adding profile
            MapperRegister();
            var suppliersDto = JsonConvert.DeserializeObject<List<SupplierDTO>>(inputJson);

            var suppliersToMap = mapper.Map<List<Supplier>>(suppliersDto); //map deserialized objects to our intended Class "Supplier" as Collections

            context.Suppliers.AddRange(suppliersToMap);
            context.SaveChanges();

            //Without Automapper !!!
            // creating list of objects from json file by deserialization
            //var suppliersToAdd = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            //DbSet<Supplier> -> add range of objects to database through the context
            //context.Suppliers.AddRange(suppliersToAdd);

            //save the changes
            //context.SaveChanges();

            return $"Successfully imported {suppliersToMap.Count()}."; //Suppliers.Count
        }

        //Task 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            MapperRegister();
            // If the supplierId doesn't exist, skip the record.
            //So we collect all avaliable ID of Suppliers and check if contained in Parts id
            var suppliedId = context.Suppliers.Select(i => i.Id).ToList();

            var partsDto = JsonConvert.DeserializeObject<List<PartDTO>>(inputJson).Where(x => suppliedId.Contains(x.SupplierId));

            var partsToMap = mapper.Map<List<Part>>(partsDto);

            context.Parts.AddRange(partsToMap);
            context.SaveChanges();

            return $"Successfully imported {partsToMap.Count()}."; //Parts.Count
        }

        //Task 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            var carsDto = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            List<Car> carsFiltered = new List<Car>();

            foreach (var car in carsDto)
            {
                Car currentCar = new Car();
                currentCar.Make = car.Make;
                currentCar.Model = car.Model;
                currentCar.TraveledDistance = car.TravelledDistance;
                foreach (var id in car.PartsId.Distinct()) // With Distinct() we skip the Id's repetition ( cuz ID's cant be repeated)
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = id,
                    });
                }

                carsFiltered.Add(currentCar);

            }

            context.Cars.AddRange(carsFiltered);
            context.SaveChanges();

            return $"Successfully imported {carsFiltered.Count()}.";//Cars.Count
        }

        //Task 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            //MapperRegister();
            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(inputJson);
            // var customersMapped = mapper.Map<List<Customer>>(customersDto);           
            //context.Customers.AddRange(customersMapped);  
            //context.SaveChanges();

            //Without AutoMapper!
            var customersResult = new List<Customer>();

            foreach (var custumer in customersDto)
            {
                var customer = new Customer()
                {
                    Name = custumer.Name,
                    BirthDate = custumer.BirthDate,
                    IsYoungDriver = custumer.IsYoungDriver
                };
                customersResult.Add(customer);
            }

            context.Customers.AddRange(customersResult);
            context.SaveChanges();

            return $"Successfully imported {customersResult.Count()}."; //Customers.Count
        }

        //Task 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            //Using AutoMapper

            //MapperRegister();
            //var salesDto = JsonConvert.DeserializeObject<List<SaleDTO>>(inputJson);
            //var sales = mapper.Map<List<Sale>>(salesDto);
            //context.AddRange(sales);
            //context.SaveChanges();
            //return $"Successfully imported {sales.Count()}."; //Sales.Count


            //Without AutoMapper - [2] Variants
            // 1)Variant with Foreach
            var salesDto = JsonConvert.DeserializeObject<List<SaleDTO>>(inputJson);

            List<Sale> sales = new List<Sale>();
            foreach (var sale in salesDto)
            {
                var currentSale = new Sale() // We set only properties needed refered to json file data
                {
                    CarId = sale.CarId,
                    CustomerId = sale.CustomerId,
                    Discount = sale.Discount
                };
                sales.Add(currentSale);
            }
            context.AddRange(sales);
            context.SaveChanges();

            // 2)Variant with Selected sales from salesDto -> into List<Sale> 
            var salesSelected = salesDto.Select(x => new Sale
            {
                CarId = x.CarId,
                CustomerId = x.CustomerId,
                Discount = x.Discount
            }).ToList();

            //context.AddRange(salesSelected);
            //context.SaveChanges();

            return $"Successfully imported {salesSelected.Count()}.";
        }

        //Task 14 - Export
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg =>
            { // This is configured in different class --> DtoMappingProfile : Profile

                cfg.AddProfile<CarDealerProfile>();

            });

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "dd/MM/yyyy"
            };

            var customers = context.Customers.OrderBy(d => d.BirthDate).ThenBy(x => x.IsYoungDriver == true).ProjectTo<CustomerDTO>(config).ToList();

            var jsonExportCustomers = JsonConvert.SerializeObject(customers, settings);
            File.WriteAllText(@"..\..\..\..\Exports\OrderedCustomers.json", jsonExportCustomers);

            return jsonExportCustomers;

            //Everything we can get with Select -> we can do with ProjectTo<>()

            //var customers = context.Customers.OrderBy(x => x.BirthDate).ThenBy(x=>x.IsYoungDriver==true).Select(x => new
            //{
            //    Name = x.Name,
            //    BirthDate = x.BirthDate,
            //    IsYoungDriver = x.IsYoungDriver
            //}).ToList();

            //var jsonFile = JsonConvert.SerializeObject(customers,settings);
            //return jsonFile;


        }

        //Task 15 
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            //AutoMapper using and .ProjectTo<CarDTO>(config) , as well as in  CarDTO use Attributes to ignore / allow props in json file
            var config = new MapperConfiguration(conf =>
            {
                conf.AddProfile<CarDealerProfile>();
            });

            var settingsJson = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,

            };

            var toyotaCars = context.Cars.Where(x => x.Make == "Toyota").ProjectTo<CarDTO>(config).OrderBy(x => x.Model).ThenByDescending(td => td.TravelledDistance).ToList();

            var jsonFile = JsonConvert.SerializeObject(toyotaCars, settingsJson);
            File.WriteAllText(@"..\..\..\..\Exports\CarsFromMakeToyota.json", jsonFile);
            return jsonFile;


            //No AutoMapper - use Select
            //----------------------------------------------------------------

            // Without AutoMapper -> Using Select and Anonymous object with props - the needed from json file
            //var settingsJson = new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,

            //};

            //var toyotaCars = context.Cars.Where(x=>x.Make=="Toyota").Select(x => new 
            //{ 
            //   Id= x.Id,
            //   Make= x.Make,
            //   Model= x.Model,
            //   TravelledDistance= x.TravelledDistance
            //}).OrderBy(m=>m.Model).ThenByDescending(td => td.TravelledDistance).ToArray();
            //var jsonExportCars = JsonConvert.SerializeObject(toyotaCars, settingsJson);
            //return jsonExportCars;

        }

        //Task 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(x => x.IsImporter == false).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                PartsCount = p.Parts.Count()
            });
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(suppliers, settings);
            File.WriteAllText(@"..\..\..\..\Exports\local-suppliers.json", json);

            return json;
        }

        //Task 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context) 
        {
            //With nested Objects
            
            var carsInfo = context.Cars.Select(c => new 
            {
                car = new 
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TraveledDistance,
                },
                
                //Here we nest collection of parts after car's data 
                parts = c.PartCars.Select(pc=> new 
                { 
                    Name = pc.Part.Name,
                    Price = $"{pc.Part.Price:F2}"
                    //Price = pc.Part.Price.ToString("F2")
                }).ToList()
            }).ToList();
           

            var json = JsonConvert.SerializeObject(carsInfo, Formatting.Indented);

            File.WriteAllText(@"..\..\..\..\Exports\cars-and-parts.json", json);
            return json;
        }

        //Task 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {            

            var customers = context.Customers.Where(x => x.Sales.Any()).Select(s => new
            {
                fullName = s.Name,
                boughtCars = s.Sales.Count(),
                spentMoney = s.Sales.Sum(x => x.Car.PartCars.Sum(cp => cp.Part.Price))

            }).OrderByDescending(m => m.spentMoney).ThenByDescending(bc=>bc.boughtCars).ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(@"..\..\..\..\Exports\TotalSalesByCustomer.json", json);
            return json;
        }

        //Task 19

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(x => new
            {
                car = new 
                { 
                    Make = x.Car.Make,
                    Model = x.Car.Model,
                    TravelledDistance = x.Car.TraveledDistance,

                },
                customerName = x.Customer.Name,
                Discount = $"{x.Discount:f2}",
                price = $"{x.Car.PartCars.Sum(x=>x.Part.Price):f2}",
                priceWithDiscount = $"{( 1- x.Discount/100.0M) * x.Car.PartCars.Sum(s=>s.Part.Price):f2}"

            }).Take(10).ToList();

            var json = JsonConvert.SerializeObject(sales,Formatting.Indented);
            return json;


            //var sales = context.Sales
            //    .Take(10)
            //    .Select(s => new
            //    {
            //        car = new
            //        {
            //            Make = s.Car.Make,
            //            Model = s.Car.Model,
            //            TravelledDistance = s.Car.TravelledDistance
            //        },
            //        customerName = s.Customer.Name,
            //        Discount = $"{s.Discount:F2}",
            //        price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):F2}",
            //        priceWithDiscount = $"{s.Car.PartCars.Sum(pc => pc.Part.Price) * (1 - (s.Discount / 100)):F2}",
            //    })
            //    .ToArray();

            //var jsonFile = JsonConvert.SerializeObject(sales, Formatting.Indented);

            //return jsonFile;

            
        } 

    }
}