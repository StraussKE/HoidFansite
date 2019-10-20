using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoidFansite.Models
{
    public class StoryRepository
    {
        private static List<UserStory> stories = new List<UserStory>();

        public static List<UserStory> Stories
        {
            get
            {
                return stories;
            }
        }
        
        public static void AddStory(UserStory story)
        {
            stories.Add(story);
        }
    }
}
