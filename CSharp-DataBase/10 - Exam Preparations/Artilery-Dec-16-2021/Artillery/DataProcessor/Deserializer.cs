namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private static string rootName = "";
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            rootName = "Countries";
            var counteriesImportDto = DeserializerCustom<ImportCountriesDTO[]>(xmlString,rootName);
            var countries = new List<Country>();
            foreach (var dto in counteriesImportDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country 
                { 
                    CountryName = dto.CountryName,
                    ArmySize = dto.ArmySize
                };
                countries.Add(country);
                sb.AppendLine(String.Format(SuccessfulImportCountry,country.CountryName,country.ArmySize));
            }
            context.Countries.AddRange(countries);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            rootName = "Manufacturers";

            var manufacturersDto = DeserializerCustom<ImportManufacturersDTO[]>(xmlString,rootName);
            var manufacturers = new List<Manufacturer>();
            foreach (var dto in manufacturersDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer 
                {
                    ManufacturerName = dto.ManufacturerName,
                    Founded = dto.Founded
                };
                
                //Successfully import manufacturer {manufacturerName} founded in {townName, countryName}.
                string[] townAndCountryNames = manufacturer.Founded.Split(", ");
                var townCountry = "";
                foreach (var element in townAndCountryNames)
                {
                    if (element == townAndCountryNames[townAndCountryNames.Length - 2])
                    {
                        townCountry += element+", ";
                    }
                    if (element == townAndCountryNames[townAndCountryNames.Length - 1])
                    {
                        townCountry += element;
                    }
                }
                if (manufacturers.Select(x=>x.ManufacturerName).Contains(dto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                manufacturers.Add(manufacturer);
                sb.AppendLine(String.Format(SuccessfulImportManufacturer,manufacturer.ManufacturerName,townCountry));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            rootName = "Shells";
            var shellsDto = DeserializerCustom<ImportShellDTO[]>(xmlString,rootName);

            foreach (var dto in shellsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell 
                { 
                    ShellWeight = dto.ShellWeight,
                    Caliber = dto.Caliber,
                };

                context.Shells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell,shell.Caliber,shell.ShellWeight));
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var gunsDto = JsonConvert.DeserializeObject<ImportGunsDTO[]>(jsonString);

            foreach (var dto in gunsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                var isParsableString = Enum.TryParse<GunType>(dto.GunType, ignoreCase: true, out var resultEnum);
                if (!isParsableString)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var gun = new Gun
                {
                    GunWeight = dto.GunWeight,
                    ManufacturerId = dto.ManufacturerId,
                    BarrelLength = dto.BarrelLength,
                    NumberBuild = dto.NumberBuild,
                    Range = dto.Range,
                    GunType = resultEnum,
                    ShellId = dto.ShellId,
                    
                };

                foreach (var country in dto.Countries)
                {
                    if (!IsValid(country))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    gun.CountriesGuns.Add(new CountryGun 
                    {
                        CountryId = country.Id,
                    });
                }
                context.Guns.Add(gun);
                sb.AppendLine(String.Format(SuccessfulImportGun,gun.GunType.ToString(),gun.GunWeight,gun.BarrelLength));
            }
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
