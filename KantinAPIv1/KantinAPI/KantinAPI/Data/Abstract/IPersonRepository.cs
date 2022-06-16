using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Abstract
{
   public interface IPersonRepository:IRepository<Person>
    {
        bool ExistPerson(int personId);
        Task<bool> DeletePerson(int personId);
        Task<double> ToplamBorc(int personId);
    }
}
