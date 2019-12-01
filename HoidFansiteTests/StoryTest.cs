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

        [Fact]
        public void AverageRatingTest()
        {
            // Arrange
            var storyRepo = new FakeStoryRepository();

            // Act
            storyRepo.Stories[0].Ratings.Add(3);
            storyRepo.Stories[0].Ratings.Add(4);
            storyRepo.Stories[0].Ratings.Add(5);

            // Assert
            Assert.Equal("4", storyRepo.Stories[0].GetAvgRating());
            Assert.Equal("Story not yet rated", storyRepo.Stories[1].GetAvgRating());
        }

        [Fact]
        public void ReviewFormTest()
        {
            // Arrange
            var storyRepo = new FakeStoryRepository();
            var reviewRepo = new FakeReviewRepository();
            var FanfictionController = new FanfictionController(storyRepo, reviewRepo);
            
            var testReview = new UserReview()
            {
                Author = "Katie",
                Title = "Testing",
                Review = "This is a test review",
                StoryID = 1,
                Rating = 3
            };

            // Act
            FanfictionController.ReviewForm(testReview);
            
            // Assert
            Assert.Equal("Katie",
                reviewRepo.Reviews[reviewRepo.Reviews.Count - 1].Author);
            Assert.Equal("Testing",
                reviewRepo.Reviews[reviewRepo.Reviews.Count - 1].Title);
            Assert.Equal("This is a test review",
                reviewRepo.Reviews[reviewRepo.Reviews.Count - 1].Review);
        }

        [Fact]
        public void StoryReviewLinkTest()
        {

            // Arrange
            var storyRepo = new FakeStoryRepository();
            var reviewRepo = new FakeReviewRepository();
            var FanfictionController = new FanfictionController(storyRepo, reviewRepo);

            var testReview = new UserReview()
            {
                Author = "Katie", Title = "Testing", Review = "This is a test review", //required data
                StoryID = 0
            };

            FanfictionController.ReviewForm(testReview);

            testReview = new UserReview()
            {
                Author = "John", Title = "Testing", Review = "This is a test review", //required data
                StoryID = 0
            };

            FanfictionController.ReviewForm(testReview);

            testReview = new UserReview()
            {
                Author = "Steve", Title = "Testing", Review = "This is a test review", //required data
                StoryID = 0
            };

            FanfictionController.ReviewForm(testReview);

            testReview = new UserReview()
            {
                Author = "Kairi", Title = "Testing", Review = "This is a test review", //required data
                StoryID = 2
            };

            FanfictionController.ReviewForm(testReview);

            string result = "";

            // Act
            foreach (UserStory s in storyRepo.Stories)
            {
                int count = 0;
                foreach (UserReview r in reviewRepo.Reviews)
                {
                    if (s.StoryID == r.StoryID)
                    {
                        count += 1;
                    }
                }
                result += "Story " + s.StoryID.ToString() + " has " + count.ToString() + " reviews. ";
            }

            // Assert postcondition
            Assert.Equal("Story 0 has 3 reviews. Story 1 has 0 reviews. Story 2 has 1 reviews. ", result);
        }
    }
}
