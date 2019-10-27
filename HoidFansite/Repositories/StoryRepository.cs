using System.Collections.Generic;

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

        public static UserStory GetStoryByID(string storyID)
        {
            UserStory story = stories.Find(s => s.StoryID.ToString() == storyID);
            return story;
        }
    }
}
