using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Abstract
{
   public interface IProductRepositroy:IRepository<Product>
    {
        bool ExistProduct(int productId);
        Task<bool> DeleteProduct(int productId);
    }
}
