using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BeWellApi.Models
{
    public class EmotionActivity
    {
        [Key]
        public int EmotionActivityId { get; set; }

        [Required]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [Required]
        public int EmotionId { get; set; }
        public Emotion Emotion { get; set; }

    }
}
