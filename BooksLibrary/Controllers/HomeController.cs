using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksLibrary.Enums;
using BooksLibrary.Managers;

namespace BooksLibrary.Controllers
{
    public class HomeController : Controller
    {
        private static BookManager _bookManager = new BookManager();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_bookManager);
        }

        [HttpPost]
        public ActionResult AddBook(string bookName, string bookType, string bookState)
        {
            _bookManager.AddBook(bookName, bookType, bookState);
            return View("Index", _bookManager);
        }

        [HttpPost]
        public ActionResult RemoveBook(string id)
        {
            _bookManager.RemoveBook(id);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Home");
            return Json(new { Url = redirectUrl });
        }

        [HttpPost]
        public ActionResult ChangeType(string type)
        {
            _bookManager.ChangeType(type);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Home");
            return Json(new { Url = redirectUrl });
        }

        [HttpPost]
        public ActionResult ChangeState(string id, string state)
        {
            _bookManager.ChangeState(id, state);

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Home");
            return Json(new { Url = redirectUrl });
        }
    }
}