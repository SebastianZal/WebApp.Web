using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Logic.Interfaces
{
    public interface IPackageLogic : ILogic
    {
        Result<Package> GetById(int id);

        Result<Package> Add(Package package);

        Result<IQueryable<Package>> GetAllActive();
    }
}
