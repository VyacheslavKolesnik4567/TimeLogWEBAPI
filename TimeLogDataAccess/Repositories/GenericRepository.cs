using System.Collections.Generic;
using System.Data.Entity;

namespace TimeLogDataAccess.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        DbContext _context;

        public GenericRepository(DbContext context)
        {
            this._context = context;
        }

        DbSet<TEntity> DbSet
        {
            get { return _context.Set<TEntity>(); }
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public bool Update(TEntity _entity)
        {
            dynamic entity = _entity;
            var olditem = DbSet.Find(entity.Id);
            if (olditem == null)
                throw new KeyNotFoundException("No entity with particular id found.");
            
            _context.Entry<TEntity>(olditem).CurrentValues.SetValues(entity);
            return true;
        }

        public bool Delete(int id)
        {
            var entity = DbSet.Find(id);
            if (entity == null)
                return false;

            _context.Set<TEntity>().Remove(entity);
            return true;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet;
        }
    }
}
