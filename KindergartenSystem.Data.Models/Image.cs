using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KindergartenSystem.Common.EntityValidationConstants.Image;

namespace KindergartenSystem.Data.Models
{
    
    public class Image
    {
        public Image()
        {
            Id = Guid.NewGuid();

        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string Url { get; set; } = string.Empty;

        [Required]
        public int KindergartenId { get; set; }
        [ForeignKey(nameof(KindergartenId))]
        public Kindergarten Kindergarten { get; set; } = null!;
    }
}
