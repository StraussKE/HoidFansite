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
        public RedirectToActionResult StoryForm(UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                storyRepo.AddStory(userStory);
                return RedirectToAction("StoryList");
            }
            else
            {
                //there is a validation error
                return RedirectToAction("StoryList");
            }
        }

        public IActionResult ReviewForm(string id)
        {
            UserStory fanfic = storyRepo.GetStoryByID(id);
            return View(fanfic);
        }

        [HttpPost]
        public RedirectToActionResult ReviewForm(string id,
                                                 string title,
                                                 string review,
                                                 string author,
                                                 int rating)
        {
            UserStory fanfic = storyRepo.GetStoryByID(id);
            fanfic.Reviews.Add(new UserReview()
            {
                Author = author,
                Body = review,
                Title = title,
                Rating = rating
            });
            return RedirectToAction("StoryList");
        }

        public IActionResult ReviewList(string id)
        {
            return View("ReviewList", storyRepo.GetStoryByID(id));
        }
    }
}