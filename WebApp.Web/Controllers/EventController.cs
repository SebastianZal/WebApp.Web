using AutoMapper;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.JavaScript.Models;
using System;
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

        public ActionResult remove (string key, DataManager dataManager)
        {
            var event_id = Convert.ToInt32(key);

            var events = Logic.Remove(event_id);

            if (events.Success == false)
                return RedirectToAction("Index");

            var operation = new DataOperations();

            var _events = operation.Execute(events.Value, dataManager);

            var viewModels = Mapper.Map<List<EventViewModel>>(_events.ToList());

            return Json(new
            {
                result = viewModels,
                count = events.Value.Count()
            }
            , JsonRequestBehavior.AllowGet
            );
        }

        public ActionResult update (Appointment value, DataManager dataManager)
        {
            var event_id = Convert.ToInt32(value.Id);

            var events = Logic.Update(event_id);

            var operation = new DataOperations();

            var _events = operation.Execute(events.Value, dataManager);

            var viewModels = Mapper.Map<List<EventViewModel>>(_events.ToList());

            return Json(new
            {
                result = viewModels,
                count = events.Value.Count()
            }
            , JsonRequestBehavior.AllowGet
            );
        }

        public ActionResult Crud(EditParams param, DataManager dataManager)
        {
            
            if (param.action == "insert" || (param.action == "batch" && param.added != null))  // this block of code will execute while inserting the appointments
            {
                var asd = "asd";
            }
            else if ((param.action == "batch" && param.changed != null) || param.action == "update")   // this block of code will execute while updating the appointment
            {
                var asd = "asd";
            }
            return View();
        }
        public class EditParams
        {
            public string key { get; set; }
            public string action { get; set; }
            public List<Appointment> added { get; set; }
            public List<Appointment> changed { get; set; }
            public Appointment value { get; set; }
        }
    }
}