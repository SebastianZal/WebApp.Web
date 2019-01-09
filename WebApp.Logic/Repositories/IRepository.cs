using System.Linq;
using WebApp.Models;

namespace WebApp.Logic.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        void Add(T model);

        void Delete(T model);

        T GetById(int id);

        IQueryable<T> GetAllActive();

        void Update(T model);

        void SaveChanges();
    }
}
