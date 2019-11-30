using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class ReviewRepository
    {
        static private List<UserReview> reviews = new List<UserReview>();

        static public void AddReview(UserReview Review)
        {
            reviews.Add(Review);
        }

        public List<UserReview> GetReviewsByStory(int ID)
        {
            List< UserReview> storyMatches = new List<UserReview>();
            foreach (UserReview r in reviews)
            {
                if(r.StoryID == ID)
                {
                    storyMatches.Add(r);
                }
            }
            return storyMatches;
        }
    }
}
