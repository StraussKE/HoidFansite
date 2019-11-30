using System;
using System.ComponentModel.DataAnnotations;

namespace HoidFansite.Models
{
    public class UserReview
    {
        public string Author { get; set; } = "Anonymous";

        [Required(ErrorMessage = "Please enter review title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The review cannot be blank")]
        public string Review { get; set; }

        public int Rating { get; set; }

        public int StoryID { get; set; }

        public DateTime ReviewCreated { get; set; }
    }
}
