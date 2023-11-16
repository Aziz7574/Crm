using System.Linq.Expressions;

namespace DAL.Data_Storage.Interfaces
{
    public interface ICrmRepository<TSource> where TSource : class
    {
        public ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression, string[] Includes, bool isTracking);


        public ValueTask<TSource> GetAsync(Expression<Func<TSource,bool>> expression);

        public ValueTask<TSource> AddAsync(TSource entity);

        public Task<TSource> Update(TSource entity);

        public void Delete(TSource entity);

    }
}
