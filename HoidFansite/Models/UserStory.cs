using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HoidFansite.Models
{
    public class UserStory
    {
        public static int nextStoryID = 0;

        private List<UserReview> reviews = new List<UserReview>();
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter story title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The story cannot be blank")]
        public string Body { get; set; }

        public int StoryID { get; set; } = nextStoryID++;

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
