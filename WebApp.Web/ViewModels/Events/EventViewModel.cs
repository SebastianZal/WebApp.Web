using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Web.ViewModels.Events
{
    public class EventViewModel
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "Imie jest wymagana")]
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool RoomSize { get; set; }

        public int PhoneNumber { get; set; }

        public int KidsQuantity { get; set; }

        public string Comment { get; set; }

        public int PackageId { get; set; }

        //public Package Package { get; set; }
    }
}