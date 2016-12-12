using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeWellApi.Models
{
    public class SavedActivity
    {
        [Key]
        public int SavedActivityId { get; set; }

        [Required]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}
