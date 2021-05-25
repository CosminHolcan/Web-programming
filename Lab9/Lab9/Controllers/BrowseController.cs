using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab9.Models;
using Lab9.DataAbstractionLayer;

namespace Lab9.Controllers
{
    public class BrowseController : Controller
    {
        // GET: Browse
        public ActionResult Index()
        {
            return View("BrowseBooks");
        }

        public string Test()
        {
            return "It's working";
        }

        public ActionResult GetBooks()
        {

            string author = Request.Params["author"];
            string genre = Request.Params["genre"];
            Console.WriteLine("-------------------" + author + genre);
            DAL dal = new DAL();
            List<Book> books = dal.getBooks(author, genre);
            return Json(new { books = books }, JsonRequestBehavior.AllowGet);
        }
    }
}