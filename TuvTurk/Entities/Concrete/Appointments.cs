using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Appointments")]
    public class Appointments : EntityBaseModel, IEntity
    {
        public long AppointsmentsID { get; set; }
        public string? CustomerName { get; set; }
        public string PlateNo { get; set; }
        public string VehicleNumberSerialNo { get; set; }
        public string City { get; set; }
        public string VehicleType { get; set; }
        public string InspectionType { get; set; }

        [ForeignKey("Slots")]
        public Slots? Slot { get; set; }



    }
}

