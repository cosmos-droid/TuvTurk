using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("EnumGroups",Schema ="TURKAI")]
    public class EnumGroup : EntityBaseModel, IEntity
    {
        [Key]
        public long EnumGroupId { get; set; }
        public string EnumGroupName { get; set; }

    }
}