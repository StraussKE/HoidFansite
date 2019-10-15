using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoidFansite.Models;

namespace HoidFansite.Controllers
{
    public class SourcesController : Controller
    {
        public ViewResult BookList()
        {
            return View(BookRepository.Books);
        }

        public ViewResult LinkList()
        {
            return View(LinkRepository.Links);
        }
    }
}