using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HoidFansite.Models
{
    public class UserStory
    {

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

        private List<int> Ratings { get; }

        public string GetAvgRating()
        {
            int numRatings = Ratings.Count;

            if (numRatings == 0)
                return "Story not yet rated";

            int ratingSum = 0;
            foreach (int r in Ratings)
            {
                ratingSum += r;
            }
            return (ratingSum / Ratings.Count).ToString();
        }
    }
}
