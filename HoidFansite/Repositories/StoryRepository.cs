using System.Collections.Generic;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        static private List<UserStory> stories = new List<UserStory>();

        public List<UserStory> Stories { get { return stories; } }
        
        public void AddStory(UserStory story)
        {
            stories.Add(story);
        }

        public StoryRepository()
        {
            if (stories.Count == 0)
            {
                stories = new FakeStoryRepository().Stories;
            }
        }

        public UserStory GetStoryByID(int storyID)
        {
            UserStory story = stories.Find(s => s.StoryID == storyID);
            return story;
        }
    }
}
