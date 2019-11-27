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

        // This is an example of using RedirectToRouteResult and returning a RedirectToRoute
        public RedirectToRouteResult DemoRedirect() =>
            RedirectToRoute(new
            {
                controller = "Example",
                action = "Index",
                ID = "MyID"
            });

        // This is an example of using ObjectResult and returning Ok
        public ObjectResult DemoObjectResult() => Ok(new string[] { "Kaladin", "Dalinar", "Wit" });

        // this is an example of hard coding a StatusCodeResult and returning NotFound
        public StatusCodeResult DemoNotFound() => NotFound();

        // this is an example of an ActionResult that has different possible results based on what happens in the controller
        public ActionResult DemoValidateAddition(Book book)
        {
            if (book.Author != "Brandon Sanderson")
            {
                ModelState.AddModelError(
                    "NonCanon",
                    "Only books written by Brandon Sanderson are considered canon in the Cosmere.");
            }
            if (ModelState.IsValid)
            {
                BookRepository.AddBook(book);
                return RedirectToAction("Index");
            }
            return View("History");
        }
    }
}
