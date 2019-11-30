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

        public FanfictionController(IStoryRepository r)
        {
            storyRepo = r;
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
                ViewBag.Fanfic.Rating
                newReview.ReviewCreated = DateTime.Now;
                ReviewRepository.AddReview(newReview);
                return RedirectToAction("StoryList");
            }
            return View("ReviewForm");
        }

        public IActionResult ReviewList(int id)
        {
            return View("ReviewList", storyRepo.GetStoryByID(id));
        }
    }
}