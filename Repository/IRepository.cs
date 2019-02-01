using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository
{
    public interface IRepository<TObject> where TObject : class
    {
        ICollection<TObject> GetAll();
        Task<ICollection<TObject>> GetAllAsync();
        TObject Get(int? id);
        Task<TObject> GetAsync(int id);
        TObject Find(Expression<Func<TObject, bool>> match);
        Task<TObject> FindAsync(Expression<Func<TObject, bool>> match);
        ICollection<TObject> FindAll(Expression<Func<TObject, bool>> match);
        Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match);
        TObject Add(TObject t);
        List<TObject> AddRang(List<TObject> t);
        Task<TObject> AddAsync(TObject t);
        TObject Update(TObject updated, int? key);
        Task<TObject> UpdateAsync(TObject updated, int key);
        void Delete(TObject t);
        void DeleteList(Expression<Func<TObject, bool>> match);
        void DeleteById(int? t);
        Task<int> DeleteAsync(TObject t);
    }
}
