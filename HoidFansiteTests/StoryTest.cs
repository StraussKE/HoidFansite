using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HoidFansite.Controllers;
using HoidFansite.Models;
using HoidFansite.Repositories;
using Xunit;

namespace HoidFansite.Tests
{
    public class StoryTest
    {
        [Fact]
        public void StoryFormTest()
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
        public void StoryListSortTest()
        {
            // Arrange
            var repo = new FakeStoryRepository();
            repo.Stories[0].Title = "Number 1";
            repo.Stories[1].Title = "Number 2";
            repo.Stories[2].Title = "Number 0";
            var FanfictionController = new FanfictionController(repo);

            // Assert precondition
            Assert.Equal("Number 1", repo.Stories[0].Title);

            // Act
            FanfictionController.StoryList();
            
            // Assert postcondition
            Assert.NotEqual("Number 1", repo.Stories[0].Title);
            Assert.Equal("Number 1", repo.Stories[1].Title);
        }



    }
}
