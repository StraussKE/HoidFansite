using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HoidFansite.Models
{
    public class UserStory
    {
        [Key]
        public int StoryID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input an author name")]
        [StringLength(20)]
        public string Author { get; set ; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter story title")]
        [StringLength(50, MinimumLength = 6)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The story cannot be blank")]
        [StringLength(3000, MinimumLength = 20)]
        public string Body { get; set; }

        public DateTime Created { get; set; }
    }
}
