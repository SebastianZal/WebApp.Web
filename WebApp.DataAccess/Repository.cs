using System.Linq;
using WebApp.Logic.Repositories;
using WebApp.Models;

namespace WebApp.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected DataContext Db { get; set; }

        public Repository(DataContext db)
        {
            Db = db;
        }
        public void Add(T model)
        {
            Db.Set<T>().Add(model);
        }

        public void Delete(T model)
        {
            Db.Set<T>().Remove(model);
        }

        public virtual IQueryable<T> GetAllActive()
        {
            return Db.Set<T>().Where(m => m.IsActive);
        }

        public T GetById(int id)
        {
            return Db.Set<T>().FirstOrDefault(m => m.Id == id);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }
    }
}
