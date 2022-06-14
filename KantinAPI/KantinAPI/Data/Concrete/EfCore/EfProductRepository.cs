using KantinAPI.Data.Abstract;
using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Concrete.EfCore
{
    public class EfProductRepository : EfCoreGenericRepository<Product>, IProductRepositroy
    {
        public EfProductRepository(KantinContext context) : base(context)
        {

        }

        private KantinContext KantinContext
        {
            get { return context as KantinContext; }
        }
        public async Task<bool> DeleteProduct(int productId)
        {
            var product = KantinContext.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                product.IsActive = false;
                await KantinContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistProduct(int productId)
        {
            var product = KantinContext.Products.Any(x => x.Id == productId);
            if (product)
            {
                return true;
            }

            return false;
        }
    }
}
