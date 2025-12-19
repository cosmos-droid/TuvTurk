using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Slots")]
    public class Slots : EntityBaseModel, IEntity
    {
        [Key]
        public long SlotId { get; set; }
        public long AppointmentId { get; set; }
        public string City { get; set; }
        public int LineId { get; set; }
        public DateOnly AvaibleDate { get; set; }
        public int AppointmentSlot { get; set; }

        [ForeignKey("AppointmentId")]
        public Appointments? Appointment { get; set; }
    }
}

