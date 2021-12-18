using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public interface IUnitOfWork
    {
        IRepository<Person> GetPersonRepo();
        IRepository<Address> GetAddressRepo();
        Task Save();
    }
}
