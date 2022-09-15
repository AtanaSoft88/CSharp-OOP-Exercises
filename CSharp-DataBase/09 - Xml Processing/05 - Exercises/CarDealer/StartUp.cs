using CarDealer.Data;
using CarDealer.DTO.Export_DTO;
using CarDealer.DTO.Import_DTO;
using CarDealer.Models;
using CarDealer.XML_Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{

    public class StartUp
    {
        public static string rootName = "";

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            ResetDB(context);

            //Task 9 Import Suppliers
            var xmlInput9 = File.ReadAllText(@"..//..//..//Datasets//suppliers.xml");

            Console.WriteLine(ImportSuppliers(context, xmlInput9));

            //Task 10 Import Parts
            var xmlInput10 = File.ReadAllText(@"..//..//..//Datasets//parts.xml");

            Console.WriteLine(ImportParts(context, xmlInput10));

            //Task 11. Import Cars - PAY ATTENTION 

            string xmlInput11 = File.ReadAllText(@"..\..\..\Datasets\cars.xml");
            Console.WriteLine(ImportCars(context, xmlInput11));

            //Task 12. Import Customers
            string xmlInput12 = File.ReadAllText(@"..\..\..\Datasets\customers.xml");
           Console.WriteLine(ImportCustomers(context, xmlInput12));

            //Task 13.Import Sales
            string xmlInput13 = File.ReadAllText(@"..\..\..\Datasets\sales.xml");
            Console.WriteLine(ImportSales(context, xmlInput13));

            //Task 14. Export Ordered Customers 

            //Console.WriteLine(GetCarsWithDistance(context));

            //Task 15 Export Cars from Make Toyota 

            //Console.WriteLine(GetCarsFromMakeBmw(context));            

            //Task 16 Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(context));

            //Task 17 Export Cars with Their List of Parts            
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Task 18 Export Total Sales by Customer
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //Task 19 Export Sales with Applied Discount

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        public static void ResetDB(CarDealerContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            //System.Console.WriteLine("Database reset successfully!");
        }


        //Helper Method for Deserialization
        public static T Deserializer<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName); //write here always the Root name of current XML file
            XmlSerializer serializer = new XmlSerializer(typeof(T), xmlRoot);
            using StringReader strReader = new StringReader(inputXml);
            T dtos = (T)serializer.Deserialize(strReader);
            return dtos; // Returns List<dto>
        }

        //Task 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            // var xmlRoot = new XmlRootAttribute("Suppliers"); // Take the root from XML file as string

            // XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDTO[]), xmlRoot); //Describe type of DTO,giving the xmlRoot

            // using StringReader stringReader = new StringReader(inputXml);//Old library needs stringReader-to read from "inputXML byte by byte"
            // var dtoCollection1 = serializer.Deserialize(stringReader) as ImportSupplierDTO[];
            // //Finally->Need to deserialize by accepting "stringReader" into Object/ s ,which we have to Cast to List / Array of DTO

            //// 1) Using foreach loop
            // List< Supplier > suppliers1 = new List<Supplier>();

            // foreach (var dto in dtoCollection1)
            // {
            //     Supplier supplier = new Supplier()
            //     {
            //         Name = dto.Name,
            //         IsImporter = dto.IsImporter,

            //     };

            //     suppliers1.Add(supplier);
            // }

            // //2) Using Select()
            // var dtoCollection2 = serializer.Deserialize(stringReader) as ImportSupplierDTO[];
            // var suppliers2 = dtoCollection2.Select(s => new Supplier
            // {
            //     Name = s.Name,
            //     IsImporter = s.IsImporter,
            // }).ToList();

            //3) Using My Method with Generics + Manual Mapping with Select
            //This method needs <CollectionDto>(inputXML,filePath)


            rootName = "Suppliers";
            var suppliersDto = Deserializer<List<ImportSupplierDTO>>(inputXml, rootName);

            var suppliers = suppliersDto.Select(s => new Supplier
            {
                Name = s.Name,
                IsImporter = s.IsImporter,
            }).ToList();
            context.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}"; //Suppliers.Count
        }

        //Task 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {

            //XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts"); //write here always the Root name of current XML file
            //XmlSerializer serializer = new XmlSerializer(typeof(List<ImportPartsDTO>), xmlRoot);
            //using StringReader strReader = new StringReader(inputXml);
            //var partsDto = (List<ImportPartsDTO>)serializer.Deserialize(strReader);

            //Instead of using upper Code we can use the single Method for this below!                        

            rootName = "Parts";
            var partsDto = Deserializer<List<ImportPartsDTO>>(inputXml, rootName);

            List<Part> parts = new List<Part>();

            var suppliersId = context.Suppliers.Select(x => x.Id).ToList();
            foreach (var dto in partsDto)
            {
                if (!suppliersId.Contains(dto.SupplierId))
                {
                    continue;
                }

                Part part = new Part
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId,
                };
                parts.Add(part);
            }

            context.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count()}"; //Parts.Count
        }

        //Task 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            rootName = "Cars";
            var carsDto = XmlHelpConverter.Deserializer<ImportCarDTO>(inputXml, rootName);
            var allParts = context.Parts.Select(x => x.Id).ToList();
            List<Car> cars = new List<Car>();
            foreach (var currDto in carsDto)
            {
                var distinctParts = currDto.PartsIds.Select(x => x.Id).Distinct(); // get unique parts only
                var parts = distinctParts.Intersect(allParts);  //get only parts which exist in both collections
                Car car = new Car
                {
                    Make = currDto.Make,
                    Model = currDto.Model,
                    TravelledDistance = currDto.TraveledDistance,
                };

                foreach (var part in parts)
                {
                    car.PartCars.Add(new PartCar
                    {
                        PartId = part
                    });
                }

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}";//Cars.Count
        }

        //Task 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            rootName = "Customers";

            var customersDto = XmlHelpConverter.Deserializer<ImportCustomerDTO>(inputXml, rootName);

            var customers = new List<Customer>();
            foreach (var cust in customersDto)
            {
                Customer customer = new Customer()
                {
                    Name = cust.Name,
                    BirthDate = cust.BirthDate,
                    IsYoungDriver = cust.IsYoungDriver,
                };
                customers.Add(customer);
            }
            context.AddRange(customers);
            context.SaveChanges();



            return $"Successfully imported {customers.Count}"; //Customers.Count
        }

        //Task 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            rootName = "Sales";
            var salesDto = XmlHelpConverter.Deserializer<ImportSalesDTO>(inputXml, rootName);

            var carsId = context.Cars.Select(x => x.Id).ToList();
            List<Sale> sales = new List<Sale>();
            foreach (var saleDto in salesDto)
            {       //!carsId.Contains(sale.CarId)
                if (!carsId.Any(x => x == saleDto.CarId))
                {
                    continue;
                }
                var sale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };

                sales.Add(sale);

            }
            context.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}";
        }

        //Task 14 - Export
        public static string GetCarsWithDistance(CarDealerContext context)
        {            
            var carsDto = context.Cars.Where(d => d.TravelledDistance > 2000000).OrderBy(x => x.Make).ThenBy(x => x.Model).Take(10).Select(x => new ExportCarsWithDistanceDTO
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance = x.TravelledDistance,
            }).ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", ""); // we add empty strings instead of the namespaces generated / For judge!
            XmlRootAttribute rootXML = new XmlRootAttribute("cars"); // the Root name of the XML doc
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsWithDistanceDTO[]), rootXML);
            using StringWriter writer = new StringWriter(sb); //We open StringWriter ,which best writes the data into StringBuilder (sb), because it is faster than String concatenation and provides best performance with no issues!
            serializer.Serialize(writer, carsDto, namespaces);  // Make serialization of "carsDto" into this "writer"
            return sb.ToString().TrimEnd();
        }

        //Task 15 
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            //With Helper Class "XmlHelpConverter"
            var bmwCarsDto = context.Cars.Where(x => x.Make == "BMW").Select(x => new ExportBMWCarsDTO
            {
                Id = x.Id,
                Model = x.Model,
                TravelledDistance = x.TravelledDistance
            }).OrderBy(x => x.Model).ThenByDescending(t => t.TravelledDistance).ToList();
            rootName = "cars";
            var resultXML = XmlHelpConverter.Serialize(bmwCarsDto, rootName); //Serialize with XML Convertor
            return resultXML;

        }

        //Task 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliersExportDto = context.Suppliers.Where(x => x.IsImporter == false).Select(x => new ExportSuppliersDTO
            {
                Id = x.Id,
                Name = x.Name,
                PartsCount = x.Parts.Count()
            }).ToList();
            rootName = "suppliers";
            var suppliers = XmlHelpConverter.Serialize(suppliersExportDto, rootName);

            return suppliers;
        }

        //Task 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            rootName = "cars";

            var carsWithPartsDto = context.Cars.Select(x => new ExportCarsWithPartsDTO
            {
                Make = x.Make,
                Model = x.Model,
                TravelledDistance=x.TravelledDistance,
                Parts = x.PartCars.Select(cp => new ExportPartCarsDTO
                {
                    Name = cp.Part.Name,
                    Price = cp.Part.Price
                }).OrderByDescending(x=>x.Price).ToList()

            }).OrderByDescending(x=>x.TravelledDistance).ThenBy(x=>x.Model).Take(5).ToList();

            var carsWithListOfParts = XmlHelpConverter.Serialize(carsWithPartsDto,rootName);

            return carsWithListOfParts;
        }

        //Task 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            rootName = "customers";
            var customersDto = context.Customers.Where(x => x.Sales.Any()).ToList().Select(x=> new ExportTotalSalesByCustomerDTO 
            { 
                Name=x.Name,
                BoughtCars = x.Sales.Select(x=>x.Car.Id).Count(),
                SpentMoney = x.Sales.Sum(x=>x.Car.PartCars.Sum(p=>p.Part.Price))
                
            }).OrderByDescending(x=>x.SpentMoney).ToList();
            var customersSales = XmlHelpConverter.Serialize(customersDto,rootName);

            return customersSales;
        }

        //Task 19 -- here i use Calculated property in one of the Export Dto!

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            rootName = "sales";
            var salesDto = context.Sales.Select(x => new ExportSalesWithDiscount 
            { 
                CarInfo = new ExportCarInfoDTO 
                {
                    Make = x.Car.Make,
                    Model = x.Car.Model,
                    TravelledDistance = x.Car.TravelledDistance
                },
                Discount = x.Discount,
                CustomerName = x.Customer.Name,
                Price = x.Car.PartCars.Sum(p=>p.Part.Price), // It is said Car price if formed by its sum of parts prices 
                //PriceDiscounted it is Calculated property and it is added Setter which returns the result of calculation
            }).ToList();

            var sales = XmlHelpConverter.Serialize(salesDto,rootName);

            return sales;

        }
    }
}