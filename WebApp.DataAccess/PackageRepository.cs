using System.Linq;
using WebApp.Logic.Repositories;
using WebApp.Models;

namespace WebApp.DataAccess
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(DataContext db):base(db)
        {
            
        }
    }
}
