using Microsoft.AspNetCore.Mvc;
using HoidFansite.Models;

namespace HoidFansite.Controllers
{
    public class FanfictionController : Controller
    {
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
        public ViewResult StoryList()
        {
            return View(StoryRepository.Stories);
        }
    }
}