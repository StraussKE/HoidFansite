using System;
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
    }
}
