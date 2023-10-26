using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess;

public class Repository<T> : IRepository<T> where  T: EntityBase
{
        protected readonly ProduManContext _context;
        private DbSet<T> _entities;

        public Repository(ProduManContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return _entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.AddAsync(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Update(entity);
            return _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await _entities.SingleOrDefaultAsync(s => s.Id == id);
            _entities.Remove(entity);
            _context.SaveChangesAsync();
        }
}