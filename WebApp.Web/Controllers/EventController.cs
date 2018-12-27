using AutoMapper;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
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
           // var result = Logic.GetAllFromCurrentMonth();

            //var viewModel = Mapper.Map<List<EventViewModel>>(result.Value.ToList());

            return View();
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

        public ActionResult DataSource(DataManager dataManager)
        {
            var eventResult = Logic.GetAllFromCurrentMonth();

            var operation = new DataOperations();

            var _events = operation.Execute(eventResult.Value, dataManager);

            var viewModels = Mapper.Map<List<EventViewModel>>(_events.ToList());

            return Json(new
            {
                result = viewModels,
                count = eventResult.Value.Count()
            }
                , JsonRequestBehavior.AllowGet
                );
        }
    }
}