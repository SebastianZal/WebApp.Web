using System.Linq;
using WebApp.Logic.Repositories;
using WebApp.Models;
using System.Data.Entity;
using System;

namespace WebApp.DataAccess
{
    public class EventRepository : Repository<Event>,IEventRepository
    {
        public EventRepository(DataContext db):base(db)
        {

        }

        public IQueryable<Event> GetAllFromCurrentMonth()
        {
            return Db.Events.Include(a => a.Package).Where(m => m.Start.Month.Equals(Db.Now.Month));
        }

        public IQueryable<Event> GetAllFromGivenMonth(DateTime viewMonth)
        {
            return Db.Events.Include(a => a.Package).Where(m => m.Start.Month.Equals(viewMonth.Month));
        }
    }
}
