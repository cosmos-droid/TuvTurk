using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuvTurk.Entities.Core;

namespace TuvTurk.Entities.Concrete
{
    [Table("EnumsGroupsTypes")]
    public class EnumGroupType : EntityBaseModel, IEntity
    {
        [Key]
        public long EnumGroupTypeId { get; set; }
        public long EnumGroupId { get; set; }
        public string? EnumGroupTypeName { get; set; }

        [ForeignKey("EnumGroupId")]
        public EnumGroup EnumGroup { get; set; }

    }
}