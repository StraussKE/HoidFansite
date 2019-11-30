using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HoidFansite.Models
{
    public class UserStory
    {
        private List<UserReview> reviews = new List<UserReview>();

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input an author name")]
        [StringLength(20)]
        public string Author { get; set ; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter story title")]
        [StringLength(50, MinimumLength = 6)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The story cannot be blank")]
        [StringLength(3000, MinimumLength = 20)]
        public string Body { get; set; }

        public int StoryID { get; set; }

        public DateTime Created { get; set; }

        public List<UserReview> Reviews { get { return reviews; } }

        public string GetAvgRating()
        {
            int numReviews = reviews.Count;

            if (numReviews == 0)
                return "Story not yet rated";

            int ratingSum = 0;
            foreach (UserReview r in reviews)
            {
                ratingSum += r.Rating;
            }
            return (ratingSum / reviews.Count).ToString();
        }
    }
}
