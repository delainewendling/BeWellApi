using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeWellApi.Models.ActivityViewModels
{
    public class NewActivityViewModel
    {
        public int ActivityId { get; set; }

        [Required]
        [StringLengthAttribute(50)]
        public string Name { get; set; }

        [Required]
        [StringLengthAttribute(1000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 20)]
        public int PointValue { get; set; }

        [Required]
        public List<int> Emotions { get; set; }

    }
}
