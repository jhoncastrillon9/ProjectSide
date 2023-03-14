using Microsoft.EntityFrameworkCore;
using ProjectSide.Infrastructure.Database.BoundedContexts;

namespace ProjectSide.Infrastructure.Database.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private readonly ProjectSideContext _context;
        private readonly DbSet<T> _dbSet;

        protected BaseRepository(ProjectSideContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        protected async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        protected async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        protected async Task InsertAsync(T entity)
        {
            _ = _dbSet.Add(entity);
            _ = await _context.SaveChangesAsync();
        }

        protected async Task UpdateAsync(T entity)
        {
            _ = _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _ = await _context.SaveChangesAsync();
        }

        protected async Task DeleteAsync(T entity)
        {
            _ = _dbSet.Remove(entity);
            _ = await _context.SaveChangesAsync();
        }
    }
}
