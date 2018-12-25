using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp.DataAccess;
using WebApp.Logic.Interfaces;
using WebApp.Models;
using WebApp.Web.Infrastructure;
using WebApp.Web.ViewModels.Events;

namespace WebApp.Web.Controllers
{
    public class EventController : Controller
    {
        protected IEventLogic Logic { get; set; }

        protected IMapper Mapper { get; set; }

        protected IPackageLogic PackageLogic { get; set; }

        public EventController(IEventLogic logic ,IMapper mapper, IPackageLogic packageLogic)
        {
            Logic = logic;
            PackageLogic = packageLogic;
            Mapper = mapper;
        }
        // GET: Event
        public ActionResult Index()
        {
            var result = Logic.GetAllActive();

            var viewModel = Mapper.Map<List<EventViewModel>>(result.Value.ToList());

            return View(viewModel);
        }

        public ActionResult Create()
        {
            using (var db = new DataContext())
            {
                var viewModel = new EventViewModel();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Create(EventViewModel viewModel)
        {
            if(ModelState.IsValid == false)
            {
                return View(viewModel);
            }

            var _event = Mapper.Map<Event>(viewModel);

            var result = Logic.Add(_event);

            if (result.Success == false)
            {
                result.AddErrorToModelState(ModelState);

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}