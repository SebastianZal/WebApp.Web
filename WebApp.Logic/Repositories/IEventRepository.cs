using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Logic.Repositories
{
    public interface IEventRepository : IRepository<Event> 
    {
        IQueryable<Event> GetAllFromCurrentMonth();

        IQueryable<Event> GetAllFromGivenMonth(DateTime viewMonth);
    }

}
