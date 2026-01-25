using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Utilities.Wrappers
{
    public abstract class EFRepository<TEntity> : IEFRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        //predicate: Koşul belirlemek için kullanılan bir fonksiyon. Örneğin, belirli bir özelliğe sahip varlıkları filtrelemek için kullanılabilir. SQL tarafında WHERE koşuluna benzer.
        // Func<TEntity, bool>: TEntity tipinde bir girdi alır ve bool tipinde bir çıktı döndürür. Yani, bir varlığın belirli bir koşulu sağlayıp sağlamadığını kontrol etmek için kullanılır.
        // Şablonu: x => x.Property == value && x.OtherProperty > otherValue || ... gibi.
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return predicate == null
                ? await _dbSet.AnyAsync()
                : await _dbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return predicate == null
                ? await _dbSet.CountAsync()
                : await _dbSet.CountAsync(predicate);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task CreateManyAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            // Asenkron olmayan metotlar için Task sınıfından Run metodu kullanılabilir. Bu sayede metot asenkron hale getirilir.
            await Task.Run(() => _dbSet.Remove(entity));
        }

        public async Task DeleteManyAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _dbSet.RemoveRange(entities));
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includes)
        {
            IQueryable<TEntity> query = predicate == null ? _dbSet : _dbSet.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IQueryable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includes)
        {
            IQueryable<TEntity> query = predicate == null ? _dbSet : _dbSet.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await Task.Run(() => query);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _dbSet.UpdateRange(entities));
        }
    }
}