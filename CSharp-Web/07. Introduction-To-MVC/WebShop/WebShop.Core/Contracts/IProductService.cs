using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Models;

namespace WebShop.Core.Contracts
{
    /// <summary>
    /// Manipulates product's data
    /// </summary>
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts(); 
        
    }
}
