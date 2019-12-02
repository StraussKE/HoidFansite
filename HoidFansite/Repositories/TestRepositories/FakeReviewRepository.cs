using System.Collections.Generic;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class FakeReviewRepository : IReviewRepository
    {
        private List<UserReview> reviews = new List<UserReview>();

        public List<UserReview> Reviews { get { return reviews; } }

        public FakeReviewRepository() { }

        public void AddReview(UserReview Review)
        {
            reviews.Add(Review);
        }

        public List<UserReview> GetReviewsByStory(int ID)
        {
            List<UserReview> storyMatches = new List<UserReview>();
            foreach (UserReview r in reviews)
            {
                if (r.StoryID == ID)
                {
                    storyMatches.Add(r);
                }
            }
            return storyMatches;
        }
    }
}
