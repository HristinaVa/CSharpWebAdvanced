using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KindergartenSystem.Common.EntityValidationConstants.ChildConst;

namespace KindergartenSystem.Data.Models
{
    
    public class Child
    {
        public Child()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(MiddleNameMaxLength)]
        public string MiddleName { get; set; } = string.Empty;
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
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
