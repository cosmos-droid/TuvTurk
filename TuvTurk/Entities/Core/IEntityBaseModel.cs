using System.ComponentModel.DataAnnotations.Schema;

namespace TuvTurk.Entities.Core
{
    public class EntityBaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedDate { get; set; }

    }
}