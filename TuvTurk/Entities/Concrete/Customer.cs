using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Customers",Schema ="TURKAI")]
    public class Customer : EntityBaseModel, IEntity
    {
        [Key]
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string? CustomerEMail { get; set; }
        public string? ReservationNo { get; set; }


    }
}