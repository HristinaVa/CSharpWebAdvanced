using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KindergartenSystem.Common.EntityValidationConstants.ClassGroup;

namespace KindergartenSystem.Data.Models
{
    public class ClassGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int AgeGroupId { get; set; }
        [ForeignKey(nameof(AgeGroupId))]
        public AgeGroup AgeGroup { get; set; } = null!;
        public ICollection<Child> Children { get; set; } = new List<Child>();
       // public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
