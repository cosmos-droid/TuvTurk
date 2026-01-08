using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Appointments",Schema ="TURKAI")]
    public class Appointments : EntityBaseModel, IEntity
    {
        [Key]
        public long AppointmentID { get; set; }
        public long? CustomerId { get; set; }
        public long CityId { get; set; }
        public long StationId { get; set; }
        public long VehicleTypeId { get; set; }
        public long InspectionTypeId { get; set; }

        public string PlateNo { get; set; }
        public string VehicleNumberSerialNo { get; set; }

        public string ReservationNo { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [ForeignKey("CityId")]
        public City? City { get; set; }

        [ForeignKey("StationId")]
        public Station? Station { get; set; }

        [ForeignKey("VehicleTypeId")]
        public EnumGroupType? VehicleType { get; set; }

        [ForeignKey("InspectionTypeId")]
        public EnumGroupType? InspectionType { get; set; }

    }
}

