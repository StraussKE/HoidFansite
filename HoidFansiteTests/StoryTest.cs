
using HoidFansite.Controllers;
using HoidFansite.Models;
using HoidFansite.Repositories;
using Xunit;

namespace HoidFansite.Tests
{
    public class StoryTest
    {
        [Fact]
        public void AddStoryTest()
        {
            // Arrange
            var repo = new FakeStoryRepository();
            var FanfictionController = new FanfictionController(repo);

            var testStory = new UserStory()
            {
                Author = "Katie",
                Title = "Testing",
                Body = "This is a test story"
            };

            // Act
            FanfictionController.StoryForm(testStory);
            // Assert
            Assert.Equal("Katie",
                repo.Stories[repo.Stories.Count - 1].Author);
            Assert.Equal("Testing",
                repo.Stories[repo.Stories.Count - 1].Title);
            Assert.Equal("This is a test story",
                repo.Stories[repo.Stories.Count - 1].Body);
        }

        [Fact]
        public void 
    }
}
