using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KindergartenSystem.Common.EntityValidationConstants.Workshop;

namespace KindergartenSystem.Data.Models
{
    public class Workshop
    {
        public Workshop()
        {
            Id = Guid.NewGuid();

        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(UrlMaxLength)]
        public string Url { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedOn { get; set; }
        public string? Description { get; set; }

        [Required]
        public Guid ChildId { get; set; }
        [ForeignKey(nameof(ChildId))]
        public Child Child { get; set; } = null!;
       
    }

}
