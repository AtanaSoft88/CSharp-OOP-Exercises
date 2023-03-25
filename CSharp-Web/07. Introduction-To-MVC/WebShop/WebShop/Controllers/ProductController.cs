using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using WebShop.Core.Contracts;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        public class SomeClass 
        {
            [Required]
            [Range(1,2000)]
            public int Year { get; set; }
            [Required]
            [Range(1, 12)]
            public int Month { get; set; }
            [Required]
            [Range(1, 30)]
            public int Day { get; set; }
        }

        private readonly IProductService productService;

        //Injecting ProductService here with IoC ( Inversion of Control )

        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }
        public async Task<IActionResult> Index()
        {            
            var products = await productService.GetAllProducts();
            ViewData["Title"] = "Products";
            // Now is the moment where we create our View
            return View(products);
        }

        //This below is only for test the Routing pattern from Program.cs , using parameters
        //You have access to this method when you address : https://localhost:7145/Product/Get
        public IActionResult Get(int year, int month, int day)
        {            
            SomeClass clas = new SomeClass() 
            {
                Year = year, Month = month, Day = day   
            };
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Get));
            }
            ViewData["Title"] = "GetTestBlog";
            
            return View(clas);
        }
    }
}
