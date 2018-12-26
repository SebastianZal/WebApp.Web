using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using WebApp.Web.ViewModels.Events;

namespace WebApp.Web.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event,EventViewModel>()
                .ReverseMap();
        }
    }
}