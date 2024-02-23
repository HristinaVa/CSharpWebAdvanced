using System.ComponentModel.DataAnnotations;
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
        public ICollection<KindergartenGroup> KindergartenGroups { get; set; } = new List<KindergartenGroup>();
    }
}
