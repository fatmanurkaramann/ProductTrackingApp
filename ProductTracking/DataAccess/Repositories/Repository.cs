using DataAccess.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  class Repository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext
    {
        protected readonly TContext Context;
        public Repository(TContext dbContext)
        {
            Context = dbContext;
        }
        public DbSet<T> Table => Context.Set<T>();
        //"Table" özelliğini kullanmak, Set<T>() metodunu _dbContext üzerinden alarak daha bağımsız bir
        //GenericRepository yapısı oluşturmak ve birden fazla DbContext kullanımını desteklemek için faydalıdır.
        //Context nesnemizin Set metodu bizlere generic olarak belirtilen türe uygun tabloyu getirmektedir.
        public int Add(T entity)
        {
            Table.Add(entity);
            return Context.SaveChanges();
        }

        public int Delete(T entity)
        {
            Table.Remove(entity);
            return Context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public int Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }
    }
}
