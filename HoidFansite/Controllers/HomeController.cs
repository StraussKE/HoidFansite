using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoidFansite.Models;

namespace HoidFansite.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult History()
        {
            return View();
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
        public ViewResult StoryList()
        {
            return View(StoryRepository.Stories);
        }
    }
}
