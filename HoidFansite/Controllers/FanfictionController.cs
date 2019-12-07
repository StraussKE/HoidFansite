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
            return View(stories);
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
            ViewBag.Fanfic = GetStoryByID(newReview.StoryID);
            if (ModelState.IsValid)
            {
                // mark the review creation time
                newReview.ReviewCreated = DateTime.Now;

                // add the review to the repository
                reviewRepo.AddReview(newReview);

                // send rating to story <- duplicates data, but will be useful later if quick rating option iss implemented
                storyRepo.AddRating(ViewBag.Fanfic, newReview.Rating);

                return RedirectToAction("ReviewList", ViewBag.Fanfic.StoryID);
            }
            return View("ReviewForm");
        }

        public IActionResult ReviewList(int id)
        {
            ViewBag.Fanfic = GetStoryByID(id);
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