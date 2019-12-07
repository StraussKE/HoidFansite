using System.Collections.Generic;
using System.Linq;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class EFStoryRepository : IStoryRepository
    {
        private ApplicationDbContext context;

        public EFStoryRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<UserStory> Stories => context.Stories;

        public void AddStory(UserStory story)
        {
            context.Add(story);
            context.SaveChanges();
        }

        public void AddRating(UserStory story, int rating)
        {
            context.Stories.ToList().
                Find(
                delegate (UserStory test)
                {
                    return test == story;
                }
                ).Ratings.Add(rating);
            context.SaveChanges();
        }
    }
}
