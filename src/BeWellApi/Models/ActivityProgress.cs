using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeWellApi.Models
{
    public class ActivityProgress
    {
        [Key]
        public int ActivityProgressId { get; set; }

        [Required]
        [DataTypeAttribute(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCompleted { get; set; }

        [Required]
        public int PointValue { get; set; }

        public double? Minutes { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
