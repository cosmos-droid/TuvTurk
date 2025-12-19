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
        public string City { get; set; }
        public int LineId { get; set; }
        public DateOnly Date { get; set; }
        public int AppointmentSlot { get; set; }

        [ForeignKey("Appointments")]
        public Appointments? AppointmentId { get; set; }
    }
}

