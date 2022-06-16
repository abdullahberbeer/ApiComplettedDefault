using KantinAPI.Data.Abstract;
using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Concrete.EfCore
{
    public class EfPersonRepository:EfCoreGenericRepository<Person>,IPersonRepository
    {
        public EfPersonRepository(KantinContext context) : base(context)
        {

        }

        private KantinContext KantinContext
        {
            get { return context as KantinContext; }
        }

        public async Task<bool> DeletePerson(int personId)
        {
            var person = KantinContext.Persons.FirstOrDefault(x => x.Id == personId);
            if (person != null)
            {
                person.IsActive = false;
                await KantinContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExistPerson(int personId)
        {
            var person = KantinContext.Persons.Any(x => x.Id == personId);
            if (person)
            {
                return true;
            }

            return false;
        }
    }
}
