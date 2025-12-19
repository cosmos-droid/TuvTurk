using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Appointments")]
    public class Appointments : EntityBaseModel, IEntity
    {
        [Key]
        public long AppointmentID { get; set; }

        public string? CustomerName { get; set; }
        public string PlateNo { get; set; }
        public string VehicleNumberSerialNo { get; set; }

        public string ReservationNo { get; set; }
        public string City { get; set; }
        public string VehicleType { get; set; }
        public string InspectionType { get; set; }

    }
}

