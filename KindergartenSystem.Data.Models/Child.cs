using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KindergartenSystem.Common.EntityValidationConstants.Child;

namespace KindergartenSystem.Data.Models
{
    public class Child
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(NameMaxLength)]
        public string MiddleName { get; set; } = string.Empty;
        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        public int ClassGroupId { get; set; }
        [ForeignKey(nameof(ClassGroupId))]
        public ClassGroup ClassGroup { get; set; } = null!;
        [Required]
        public Guid ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Parent Parent { get; set; } = null!;
        //public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    }
}
