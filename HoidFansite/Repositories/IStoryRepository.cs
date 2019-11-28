using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public interface IStoryRepository
    {
        List<UserStory> Stories { get; }

        void AddStory(UserStory story);

        UserStory GetStoryByID(string ID);
    }
}
