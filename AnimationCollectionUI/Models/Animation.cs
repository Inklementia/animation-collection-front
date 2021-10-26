using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimationCollectionUI.Models
{
    public class Animation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        [Required]
        [DisplayName("Youtube link")]
        public string Link { get; set; }
    }
}