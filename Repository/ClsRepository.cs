using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class ClsRepository<TObject> : IRepository<TObject>, IDisposable where TObject : class
    {
        protected EntityFrameWorkEntities Db = new EntityFrameWorkEntities();

        public void Dispose()
        {
            if (Db != null)
            {
                Db.Dispose();
                Db = null;
            }
        }
        public ICollection<TObject> GetAll()
        {
            return Db.Set<TObject>().ToList();
        }

        public async Task<ICollection<TObject>> GetAllAsync()
        {
            return await Db.Set<TObject>().ToListAsync();
        }

        public TObject Get(int? id)
        {
            return Db.Set<TObject>().Find(id);
        }

        public async Task<TObject> GetAsync(int id)
        {
            return await Db.Set<TObject>().FindAsync(id);
        }

        public TObject Find(Expression<Func<TObject, bool>> match)
        {
            return Db.Set<TObject>().SingleOrDefault(match);
        }

        public async Task<TObject> FindAsync(Expression<Func<TObject, bool>> match)
        {
            return await Db.Set<TObject>().SingleOrDefaultAsync(match);
        }

        public ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match)
        {
            return Db.Set<TObject>().Where(match).ToList();
        }

        public async Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match)
        {
            return await Db.Set<TObject>().Where(match).ToListAsync();

        }

        public TObject Add(TObject t)
        {
            Db.Set<TObject>().Add(t);
            Db.SaveChanges();
            return t;
        }

        public List<TObject> AddRang(List<TObject> t)
        {
            Db.Set<TObject>().AddRange(t);
            Db.SaveChanges();
            return t;
        }

        public async Task<TObject> AddAsync(TObject t)
        {
            Db.Set<TObject>().Add(t);
            await Db.SaveChangesAsync();
            return t;
        }

        public TObject Update(TObject updated, int? key)
        {
            if (updated == null)
                return null;

            var existing = Db.Set<TObject>().Find(key);
            if (existing != null)
            {
                Db.Entry(existing).CurrentValues.SetValues(updated);
                Db.SaveChanges();
            }
            return existing;
        }

        public async Task<TObject> UpdateAsync(TObject updated, int key)
        {
            if (updated == null)
                return null;

            var existing = await Db.Set<TObject>().FindAsync(key);

            if (existing != null)
            {
                Db.Entry(existing).CurrentValues.SetValues(updated);
                await Db.SaveChangesAsync();
            }
            return existing;
        }

        public void DeleteList(Expression<Func<TObject, bool>> match)
        {
            var lst = Db.Set<TObject>().Where(match).ToList();
            Db.Set<TObject>().RemoveRange(lst);
            Db.SaveChanges();
        }

        public void DeleteById(int? t)
        {
            var existing = Db.Set<TObject>().Find(t);
            Db.Set<TObject>().Remove(existing);
            Db.SaveChanges();
        }

        public void Delete(TObject t)
        {
            Db.Set<TObject>().Remove(t);
            Db.SaveChanges();
        }

        public async Task<int> DeleteAsync(TObject t)
        {
            Db.Set<TObject>().Remove(t);
            return await Db.SaveChangesAsync();
        }
    }
}
