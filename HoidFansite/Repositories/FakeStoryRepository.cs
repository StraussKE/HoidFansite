using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoidFansite.Models;

namespace HoidFansite.Repositories
{
    public class FakeStoryRepository : IStoryRepository
    {
        static private List<UserStory> stories = new List<UserStory>();

        public List<UserStory> Stories { get { return stories; } }

        public void AddStory(UserStory story)
        {
            stories.Add(story);
        }

        public FakeStoryRepository()
        {
            if (stories.Count() == 0)
                AddDemoStories();
        }

        public UserStory GetStoryByID(int storyID)
        {
            UserStory story = stories.Find(s => s.StoryID == storyID);
            return story;
        }

        private void AddDemoStories()
        {
            UserStory story = new UserStory()
            {
                StoryID = stories.Count,
                Author = "Kaladin",
                Title = "A Flute",
                Body = "Quite an unusual man, this 'Hoid' is.  He played a song while telling a story, " +
                "which I swear I could see in the campfire and then he gave me the flute he used in the " +
                "presentation.  It was most peculiar.  I tried to turn down the flute, for I do not know " +
                "how to play it, but he would not accept no as an answer. A most infuriatingly cryptic man!"
            };
            stories.Add(story);

            story = new UserStory()
            {
                StoryID = stories.Count,
                Author = "Dalinar Kohlin",
                Title = "Respect?",
                Body = "His tongue is most sharp, this 'Wit' of our king. He cares little for the dignity " +
                "of others and makes certain to puncture egos without regard to possible retaliation. Yet... " +
                "today he spoke to me in a complimentary manner. Spared from his renowned barbs, I was at " +
                "a loss for words. Is it possible that this ireverant man respects me?"
            };
            stories.Add(story);

            story = new UserStory()
            {
                StoryID = stories.Count,
                Author = "Eragon",
                Title = "Uneventful",
                Body = "I do not know this man you tell tales of. You act like he shows up in every story, " +
                "but he has never been in mine. He seems an enigmatic fellow, and I should very much like to " +
                "meet him, but your universe sounds so different from mine that I think it shall never happen. " +
                "In truth, he seems quite imagined!"
            };
            stories.Add(story);
        }
    }   
}
