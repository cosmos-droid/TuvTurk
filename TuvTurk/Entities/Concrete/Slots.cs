using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Slots",Schema ="TURKAI")]
    public class Slots : EntityBaseModel, IEntity
    {
        [Key]
        public long SlotId { get; set; }
        public long? AppointmentId { get; set; }
        public long StationId {get; set;}
        public DateOnly AvailableDate { get; set; }
        public long AppointmentSlot { get; set; }

        [ForeignKey("AppointmentId")]
        public Appointments? Appointment { get; set; }

        [ForeignKey("StationId")]
        public Station? Station { get; set; }



    }
}

