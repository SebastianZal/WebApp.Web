using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Logic.Interfaces
{
    public interface IEventLogic : ILogic
    {
        Result<Event> GetById(int id);

        Result<Event> Add(Event _event);

        Result<IQueryable<Event>> GetAllActive();

        Result<IQueryable<Event>> GetAllFromCurrentMonth();

        Result<IQueryable<Event>> GetAllFromGivenMonth(DateTime viewMonth);

        Result<IQueryable<Event>> Remove(int event_id);

        Result<IQueryable<Event>> Update(int event_id);
    }
}
