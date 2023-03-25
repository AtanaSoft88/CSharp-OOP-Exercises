using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Contracts;
using WebShop.Core.Models;
using WebShop.Data;

namespace WebShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        public ProductService(IConfiguration _config, ApplicationDbContext context)
        {
            this.config = _config;
        }
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            //Following problem may araise : config.GetValue() - is not active here after inject IConfiguration in service constructor?        
            //The reason is that GetValue <T> is an extension method and does not exist directly in the IConfiguration interface.
            // If we cant get the Extension method of IConfiguration -> .GetValue() we have 2 options to find the path needed :

            //1) - using Section and Path - this gets the exact file path from Json file appsettings.json 
            string dataPath = config.GetSection("DataFiles:Products").Value;

            //2) Just install Microsoft.Extensions.Configuration.Binder and the method will be available. Thos here is recommended!
            // We got this "DataFiles:Products" from appsettings.json file
            var dataPathBind = config.GetValue<string>("DataFiles:Products");

            //using direct path with File - this is a slow operation , not recommended.
            //Try using this with await/async pattern,so the method GetAllProducts() has to return Task,make sure the Interface declares it!
            string data = await File.ReadAllTextAsync(dataPathBind);

            IEnumerable<ProductModel> listProducts = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(data);

            return listProducts;

            //Now we go to Inversion of Control Container in WebShop/Program.cs and Add this new Service there
            //After that we go to Controller and inject this Service there also
        }
    }
}
