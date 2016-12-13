using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeWellApi.Models
{
    public class UserEmotion
    {
        [Key]
        public int UserEmotionId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int EmotionId { get; set; }
        public Emotion Emotion { get; set; }

        [Required]
        [DataTypeAttribute(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateLogged { get; set; }
    }
}
