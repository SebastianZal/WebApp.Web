﻿using FluentValidation;
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

        protected IValidator<Event> Validator { get; set; }

        public EventLogic(IEventRepository repository, IValidator<Event> validator)
        {
            Repository = repository;
            Validator = validator;
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

            var validationResult = Validator.Validate(_event);

            if (validationResult.IsValid == false)
            {
                return Result.Error<Event>(validationResult.Errors);
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
                throw new ArgumentNullException("event_GetAllFromGivenMonth");
            }

            return Result.Ok(Repository.GetAllFromGivenMonth(viewMonth));
        }

        public Result<IQueryable<Event>> Remove(int event_id)
        {
            var _event = Repository.GetById(event_id);

            if (_event == null)
            {
                return Result.Error<IQueryable<Event>>("Brak zdarzenia o podanym Id");
            }

            var mydate = _event.Start;

            Repository.Delete(_event);
            Repository.SaveChanges();

            return Result.Ok(Repository.GetAllFromGivenMonth(mydate));
        }

        public Result<IQueryable<Event>> Update(int event_id)
        {
            var _event = Repository.GetById(event_id);

            if (_event == null)
            {
                return Result.Error<IQueryable<Event>>("Brak zdarzenia o podanym Id");
            }
            var mydate = _event.Start;

            Repository.Update(_event);
            Repository.SaveChanges();

            return Result.Ok(Repository.GetAllFromGivenMonth(mydate));
        }

    }
}
