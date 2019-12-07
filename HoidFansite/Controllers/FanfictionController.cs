using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HoidFansite.Models;
using System.Web;
using HoidFansite.Repositories;

namespace HoidFansite.Controllers
{
    public class FanfictionController : Controller
    {
        static IStoryRepository storyRepo;
        static IReviewRepository reviewRepo;

        public FanfictionController(IStoryRepository story, IReviewRepository review)
        {
            storyRepo = story;
            reviewRepo = review;
        }

        public IActionResult StoryList()
        {
            List<UserStory> stories = storyRepo.Stories.ToList();
            stories.Sort((s1, s2) => string.Compare(s1.Title, s2.Title, StringComparison.Ordinal));
            ViewBag.AvgRatings = AvgRating();
            return View(stories);
        }

        private Dictionary<int, int> AvgRating()
        {
            Dictionary<int, int> sIdCommaAvgRate = new Dictionary<int, int>();

            foreach (UserStory s in storyRepo.Stories)
            {
                int ratingSum = 0;
                List<UserReview> revList = GetReviewsByStoryID(s.StoryID);
                if (revList.Count == 0)
                {
                    sIdCommaAvgRate.Add(s.StoryID, 0);
                }
                else {
                    foreach (UserReview r in revList)
                    {
                        ratingSum += r.Rating;
                    }
                    sIdCommaAvgRate.Add(s.StoryID, ratingSum / revList.Count);
                }
            }
            return sIdCommaAvgRate;
        }

        [HttpGet]
        public IActionResult StoryForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StoryForm(UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                userStory.StoryID = storyRepo.Stories.ToList().Count;
                storyRepo.AddStory(userStory);
                return RedirectToAction("StoryList");
            }
            else
            {
                //there is a validation error
                return View("StoryForm");
            }
        }

        [HttpGet]
        public IActionResult ReviewForm(int id)
        {
            ViewBag.Fanfic = GetStoryByID(id);
            return View();
        }

        [HttpPost]
        public IActionResult ReviewForm(UserReview newReview)
        {
            int id = newReview.StoryID;
            ViewBag.Fanfic = GetStoryByID(id);
            if (ModelState.IsValid)
            {
                // mark the review creation time
                newReview.ReviewCreated = DateTime.Now;

                // add the review to the repository
                reviewRepo.AddReview(newReview);

                return RedirectToAction("ReviewList", id);
            }
            return View("ReviewForm");
        }

        public IActionResult ReviewList(int id)
        {
            ViewBag.Story = GetStoryByID(id);
            return View("ReviewList", GetReviewsByStoryID(id));
        }

        // pulls data for a specified story from the database
        public UserStory GetStoryByID(int storyID)
        {
            UserStory story = storyRepo.Stories.ToList().
                Find(
                delegate (UserStory test)
                {
                    return test.StoryID == storyID;
                }
                );
            return story;
        }

        // Gets review list for all reviews of the selected story
        public List<UserReview> GetReviewsByStoryID(int storyID)
        {
            List<UserReview> reviews = reviewRepo.Reviews.Where(r => r.StoryID == storyID).ToList();
            return reviews;
        }
    }
}