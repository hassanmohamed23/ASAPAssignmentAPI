using DBContext;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class Repository<T> :IRepository<T> where T : class
    {
        MyDbContext context;
        DbSet<T> Table;
        public Repository(MyDbContext _context)
        {
            context = _context;
            Table = context.Set<T>();
        }
        //Get All
        public async Task<IEnumerable<T>> GetAsync()
        {
            return  Table;
        }
        //Get By ID
        public async Task<T> GetByIDAsync(int Id)
        {
            return await Table.FindAsync(Id);
        }
 
          //Get By Lamada Experssion
        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
             
            return  Table.Where(expression).AsNoTracking();
        }



        //Add
        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }
        //update
        public async Task<T> Update(T entity)
        {
            Table.Update(entity);
            return entity;
        }
        
        //Delete
        public async Task<T> Remove(T entity)
        {
            Table.Remove(entity);
            return entity;
        }


    }
}
