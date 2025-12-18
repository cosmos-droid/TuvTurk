using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Slots")]
    public class Slots : EntityBaseModel, IEntity
    {
        public long SlotId { get; set; }
        public string StationId { get; set; }
        public int LineId { get; set; }
        public int AppointmentSlot { get; set; }
    }
}

