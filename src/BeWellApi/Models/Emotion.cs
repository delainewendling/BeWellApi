using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeWellApi.Models
{
    public class Emotion
    {
        [Key]
        public int EmotionId { get; set; }

        [Required]
        [StringLengthAttribute(50)]
        public string Name { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public int EmotionCategoryId { get; set; }
        public EmotionCategory EmotionCategory { get; set; }

        public ICollection<UserEmotion> UserEmotion;
    }
}
