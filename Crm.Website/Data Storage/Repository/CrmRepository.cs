using Crm.Website.Models;
using DAL.Data_Storage.Classes;
using DAL.Data_Storage.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace DAL.Data_Storage.Repository
{
    public class CrmRepository<TSource> : ICrmRepository<TSource> where TSource : class
    {
        protected readonly CrmDbContext dbContext;
        protected readonly DbSet<TSource> dbSet;

        public CrmRepository(CrmDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TSource>();
        }



        public async ValueTask<TSource> AddAsync(TSource entity)
        {
            var entr = await dbContext.AddAsync(entity);


            await dbContext.SaveChangesAsync();

            return entr.Entity;
        }

        public async void Delete(TSource entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> expression = null, string[] includes = null, bool isTracking = true)
        {
            IQueryable<TSource> query = expression is null ? dbSet : dbSet.Where(expression);

            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();
            return query;
        }

        public async ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression, string[] Includes, bool isTracking)
        => await dbSet.FirstOrDefaultAsync(expression);

        //     => await GetAll(expression, Includes);

        public async Task<TSource> Update(TSource entity)
        {
            var result = dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async ValueTask SaveChangesAsync()
            => await dbContext.SaveChangesAsync();


        public async Task<IEnumerable<Student>> GetAllStudents()
       => await dbContext.Students.ToListAsync();


        public async ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression)
        => await dbSet.FirstOrDefaultAsync(expression);
    }
}

