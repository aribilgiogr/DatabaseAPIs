using System.Linq.Expressions;

namespace Utilities.Wrappers
{
    public interface IEFRepository<TEntity> where TEntity : class
    {
        // Task ve async: İşlemlerin asenkron (eşzamanlı/paralel) olarak gerçekleştirilmesini sağlayan yapıdır. Dikkat edilmesi gereken en önemli durum bu yapıyla başlayan süreci yine bu yapıyla devam ettirmektir.
        // Task<T>: Return type olarak kullanılır, belirli bir işlemin sonucunu temsil eden bir yapıdır. Asenkron işlemler için kullanılır.
        // async: Task<T> return type metotlarda, metodun asenkron olarak çalışacağını belirtir. Bu, metodun çağrıldığı yerde beklenmeden diğer işlemlerin devam etmesini sağlar.
        // await: async olarak işaretlenmiş bir metodun içinde, başka bir asenkron işlemi beklemek için kullanılır. Bu, işlemin tamamlanmasını beklerken diğer işlemlerin devam etmesini sağlar.
        // Kozmetik olarak bu tip metotların sonuna "Async" eklenebilir. Örneğin: CreateAsync, FindByIdAsync gibi.

        // Task -> void gibi düşünülebilir. Yani geriye bir değer döndürmez.
        Task CreateAsync(TEntity entity);
        Task CreateManyAsync(IEnumerable<TEntity> entities);

        // Task<T> -> T gibi düşünülebilir. Yani geriye T tipinde bir değer döndürür.
        Task<TEntity?> FindByIdAsync(int id);
        Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includes);
        Task<IQueryable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includes);

        Task UpdateAsync(TEntity entity);
        Task UpdateManyAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);
        Task DeleteManyAsync(IEnumerable<TEntity> entities);

        Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null);
    }
}