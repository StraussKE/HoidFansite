using System;
using System.Collections.Generic;
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
            List<UserStory> stories = storyRepo.Stories;
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
                userStory.StoryID = storyRepo.Stories.Count;
                storyRepo.AddStory(userStory);
                return RedirectToAction("StoryList");
            }
            else
            {
                //there is a validation error
                return View("StoryForm");
            }
        }

        public IActionResult ReviewForm(int id)
        {
            ViewBag.Fanfic = storyRepo.GetStoryByID(id);
            return View();
        }

        [HttpPost]
        public IActionResult ReviewForm(UserReview newReview)
        {
            ViewBag.Fanfic = storyRepo.GetStoryByID(newReview.StoryID);
            if (ModelState.IsValid)
            {
                // mark the review creation time
                newReview.ReviewCreated = DateTime.Now;

                // add the review to the repository may alter this later, creates duplicate data in database
                reviewRepo.AddReview(newReview);

                // send rating to story for easier display
                ViewBag.Fanfic.Ratings.Add(newReview.Rating);

                return RedirectToAction("ReviewList");
            }
            return View("ReviewForm");
        }

        public IActionResult ReviewList(int id)
        {

            ViewBag.Story = storyRepo.GetStoryByID(id);
            return View("ReviewList", reviewRepo.GetReviewsByStory(id));
        }
    }
}