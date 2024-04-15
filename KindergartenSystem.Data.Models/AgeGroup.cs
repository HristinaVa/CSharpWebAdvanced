using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KindergartenSystem.Common.EntityValidationConstants.AgeGroup;

namespace KindergartenSystem.Data.Models
{
    public class AgeGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(MinNumber, MaxNumber)]
        public int Number { get; set; }
        [Required]
        public int KindergartenId { get; set; }
        [Required]
        [ForeignKey(nameof(KindergartenId))]
        public Kindergarten Kindergarten { get; set; } = null!;
        public ICollection<ClassGroup> ClassGroups { get; set; } = new List<ClassGroup>();
    }
}
