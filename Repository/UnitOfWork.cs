using DBContext;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
   public class UnitOfWork :IUnitOfWork
    {
        MyDbContext Context;
        IRepository<Person> PersonRepo;
        IRepository<Address> AddressRepo;

        public UnitOfWork(MyDbContext context, IRepository<Person> _PersonRepo, IRepository<Address> _AddressRepo)
        {
            Context = context;
            PersonRepo = _PersonRepo;
            AddressRepo = _AddressRepo;
        }
        public IRepository<Person> GetPersonRepo()
        {
            return PersonRepo;
        }
        public IRepository<Address> GetAddressRepo()
        {
            return AddressRepo;
        }
       
        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

    }
}
