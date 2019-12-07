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
    }
}
