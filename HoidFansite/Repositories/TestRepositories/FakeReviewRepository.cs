using System.Collections.Generic;
using System.Linq;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class FakeReviewRepository : IReviewRepository
    {
        public IQueryable<UserReview> Reviews => new List<UserReview>
        {

        }.AsQueryable<UserReview>();

        public FakeReviewRepository() { }

        public void AddReview(UserReview review)
        {
            Reviews.ToList().Add(review);
        }
    }
}
