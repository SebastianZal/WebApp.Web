using System;

namespace WebApp.Models
{
    public class Event : BaseModel
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool RoomSize { get; set; }

        public int PhoneNumber { get; set; }

        public int KidsQuantity { get; set; }

        public string Comment { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
