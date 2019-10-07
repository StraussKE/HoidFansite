using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_HoidFansite.Controllers
{
    public class SourcesController : Controller
    {
        public ViewResult Sources()
        {
            return View();
        }

        public ViewResult Books()
        {
            return View();
        }

        public ViewResult Links()
        {
            return View();
        }
    }
}