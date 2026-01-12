using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("Prices", Schema = "TURKAI")]
    public class Price : EntityBaseModel, IEntity
    {
        public long PriceId { get; set; }
        public long EnumGroupTypeId { get; set; }
        public float ServicePrice { get; set; }

        [ForeignKey("EnumGroupTypeId")]
        public EnumGroupType? EnumGroupType { get; set; }

    }

}