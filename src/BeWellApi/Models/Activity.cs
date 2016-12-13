using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeWellApi.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        [StringLengthAttribute(50)]
        public string Name { get; set; }

        [Required]
        [StringLengthAttribute(1000)]
        public string Description { get; set; }

        [Required]
        public bool IsMeditation { get; set; }
        [Required]
        public int PhysicalMax { get; set; }
        [Required]
        public int PhysicalMin { get; set; }
        [Required]
        public int PointValue { get; set; }

        public double? Minutes { get; set; }

        public string AWSUrl { get; set; }

        public bool UserAdded { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<SavedActivity> SavedActivity;

        public ICollection<ActivityProgress> ActivityProgess;
    }
}
