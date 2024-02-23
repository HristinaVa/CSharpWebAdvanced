using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KindergartenSystem.Common.EntityValidationConstants.KindergartenGroup;

namespace KindergartenSystem.Data.Models
{
    public class KindergartenGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int AgeGroupId { get; set; }
        [ForeignKey(nameof(AgeGroupId))]
        public AgeGroup AgeGroup { get; set; } = null!;
        public ICollection<Child> Children { get; set; } = new List<Child>();
    }
}
