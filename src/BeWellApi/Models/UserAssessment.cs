using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeWellApi.Models
{
    public class UserAssessment
    {
        [Key]
        public int UserAssessmentId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int AssessmentValue { get; set; }

        [Required]
        public bool IsPhysical { get; set; }

    }
}
