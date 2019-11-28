using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoidFansite.Models;
using HoidFansite.Repositories;

namespace HoidFansite.Controllers
{
    public class SourcesController : Controller
    {
        public IActionResult BookList()
        {
            List<Book> books = BookRepository.Books;
            books.Sort((b1, b2) => DateTime.Compare(b1.PublicationDate, b2.PublicationDate));
            return View(books);
        }

        public IActionResult LinkList()
        {
            List<Link> links = LinkRepository.Links;
            links.Sort((l1, l2) => string.Compare(l1.Title, l2.Title, StringComparison.Ordinal));
            return View(links);
        }
    }
}