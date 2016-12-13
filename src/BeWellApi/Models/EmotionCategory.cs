using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeWellApi.Models
{
    public class EmotionCategory
    {
        [Key]
        public int EmotionCategoryId { get; set; }

        [Required]
        [StringLengthAttribute(50)]
        public string Name { get; set; }

        public ICollection<Emotion> Emotion;
    }
}
