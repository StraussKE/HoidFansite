using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public interface IStoryRepository
    {
        IQueryable<UserStory> Stories { get; }

        void AddStory(UserStory story);

        void AddRating(UserStory story, int rating);
    }
}
