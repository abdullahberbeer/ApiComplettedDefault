using KantinAPI.Data.Abstract;
using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Concrete.EfCore
{
    public class EfCategoryRepository:EfCoreGenericRepository<Category>,ICategoryRepository
    {
        public EfCategoryRepository(KantinContext context):base(context)
        {

        }

        private KantinContext KantinContext
        {
            get { return context as KantinContext; }
        }

        public async Task<Category> DeleteCategory(int categoryId)
        {
            var category = KantinContext.Categories.FirstOrDefault(x => x.Id == categoryId);
            if (category!=null)
            {
                category.IsActive = false;
               await KantinContext.SaveChangesAsync();
                return category;
            }
            return null;
        }

        public bool ExistCategory(int categoryId)
        {
            var category = KantinContext.Categories.Any(x => x.Id == categoryId);
            if (category)
            {
                return true;
            }

            return false;
        }
    }
}
