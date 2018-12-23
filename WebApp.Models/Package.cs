using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Package : BaseModel
    {
        public byte Type { get; set; }

        public string Topic { get; set; }

        public int InvitationQuantity { get; set; }

        public string Cake { get; set; }

        public bool CakeOrder { get; set; }

        public string Piniata{ get; set; }

        public int EventId { get; set; }
        [Required]
        public virtual Event Event { get; set; }

    }
}
