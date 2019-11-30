using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult ReviewForm(string id)
        {
            ViewBag.Fanfic = new UserStory();
            ViewBag.Fanfic = storyRepo.GetStoryByID(id);
            return View();
        }

        [HttpPost]
        public RedirectToActionResult ReviewForm(UserReview newReview)
        {
            if (ModelState.IsValid)
            {
                newReview.ReviewCreated = DateTime.Now;
                ReviewRepository.AddReview(newReview);
            }
            return RedirectToAction("StoryList");
        }

        public IActionResult ReviewList(string id)
        {
            return View("ReviewList", storyRepo.GetStoryByID(id));
        }
    }
}