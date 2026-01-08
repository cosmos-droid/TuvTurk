using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TuvTurk.Entities.Core;


namespace TuvTurk.Entities.Concrete
{

    [Table("Vehicles", Schema = "TURKAI")]
    public class Vehicle : EntityBaseModel, IEntity
    {
        public long VehicleId {get; set;}
        public long VehicleTypeId { get; set; }
        public string PlateNo { get; set; }
        public string VehicleNumberSerialNo { get; set; }

        [ForeignKey("VehicleTypeId")]
        public EnumGroupType VehicleType {get;set;}




    }
    
}