using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HoidFansite.Models;
using System.Web;

namespace HoidFansite.Controllers
{
    public class FanfictionController : Controller
    {
        public IActionResult StoryList()
        {
            List<UserStory> stories = StoryRepository.Stories;
            stories.Sort((s1, s2) => string.Compare(s1.Title, s2.Title, StringComparison.Ordinal));
            return View(stories);
        }

        [HttpGet]
        public ViewResult StoryForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult StoryForm(UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                StoryRepository.AddStory(userStory);
                return View("StorySubmitted", userStory);
            }
            else
            {
                //there is a validation error
                return View();
            }
        }

        public IActionResult ReviewForm(string id)
        {
            return View("ReviewForm", HttpUtility.HtmlDecode(id));
        }

        [HttpPost]
        public RedirectToActionResult ReviewForm(string id,
                                                 string title,
                                                 string review,
                                                 string author,
                                                 int rating)
        {
            UserStory fanfic = StoryRepository.GetStoryByID(id);
            fanfic.Reviews.Add(new UserReview()
            {
                Author = author,
                Body = review,
                Title = title,
                Rating = rating
            });
            return RedirectToAction("StoryList");
        }

        /*public ViewResult ReviewList(UserStory story)
        {
            return View(ReviewList.UserReview.Where(review => review.StoryID == story.StoryID));
        }

        /*public ViewResult ReviewList(User user)
        {
            return View(ReviewList.UserReview.Where(review => review.UserID == story.UserID));
        }*/
    }
}