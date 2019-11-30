using System;
using System.ComponentModel.DataAnnotations;

namespace HoidFansite.Models
{
    public class UserReview
    {
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter review title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The review cannot be blank")]
        public string Review { get; set; }

        public int Rating { get; set; }
        public int[] Ratings = new[] { 1, 2, 3, 4, 5 };
        public string[] RatingTitle = new[] { "1 star", "2 star", "3 star", "4 star", "5 star" };

        public int StoryID { get; set; }

        public DateTime ReviewCreated { get; set; }
    }
}
