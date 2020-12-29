using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Бипит_лаба9.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        Bipit_3Entities BD = new Bipit_3Entities();

        public ActionResult book()
        {
            IEnumerable<Books> book = BD.Books;
            ViewBag.Book = book;
            return View("book");
        }

        public ActionResult fio()
        {
            IEnumerable<FIOs> fio = BD.FIOs;
            ViewBag.Fio = fio;
            return View("fio");
        }

        public ActionResult book_arenda()
        {
            IEnumerable<Arenda_book> book_arenda = BD.Arenda_book;
            ViewBag.book_arenda = book_arenda;
            return View("book_arenda");
        }
    }
}