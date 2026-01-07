using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Cities",Schema = "TURKAI")]
    public class City : EntityBaseModel, IEntity
    {
        [Key]
        public long CityId { get; set; }
        public string CityName { get; set; }
    }
}