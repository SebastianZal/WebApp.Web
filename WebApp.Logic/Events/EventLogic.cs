using System;
using System.Linq;
using WebApp.Logic.Interfaces;
using WebApp.Logic.Repositories;
using WebApp.Models;

namespace WebApp.Logic.Packages
{
    public class EventLogic : IEventLogic
    {
        protected IEventRepository Repository { get; set; }

        public EventLogic(IEventRepository repository)
        {
            Repository = repository;
        }

        public Result<Event> GetById(int id)
        {
            var _event = Repository.GetById(id);

            if(_event == null)
            {
                return Result.Error<Event>("Brak zdarzenia o podanym Id");
            }

            return Result.Ok(_event);
        }

        public Result<Event> Add(Event _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException("event");
            }

            Repository.Add(_event);
            Repository.SaveChanges();

            return Result.Ok(_event);
        }

        public Result<IQueryable<Event>> GetAllActive()
        {
            return Result.Ok(Repository.GetAllActive());
        }

        public Result<IQueryable<Event>> GetAllFromCurrentMonth()
        {
            return Result.Ok(Repository.GetAllFromCurrentMonth());
        }

        public Result<IQueryable<Event>> GetAllFromGivenMonth(DateTime viewMonth)
        {
            if (viewMonth == null)
            {
                throw new ArgumentNullException("GetAllFromGivenMonth");
            }

            return Result.Ok(Repository.GetAllFromGivenMonth(viewMonth));
        }
    }
}
