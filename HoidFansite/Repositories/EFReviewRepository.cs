using System.Collections.Generic;
using System.Linq;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public EFReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<UserReview> Reviews => context.Reviews;

        public void AddReview(UserReview Review)
        {
            context.Add(Review);
            context.SaveChanges();
        }

    }
}