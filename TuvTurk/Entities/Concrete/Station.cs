using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Stations")]
    public class Station : EntityBaseModel, IEntity
    {
        [Key]
        public long StationId { get; set; }
        public long CityId { get; set; }
        public string? StationName { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

    }
}