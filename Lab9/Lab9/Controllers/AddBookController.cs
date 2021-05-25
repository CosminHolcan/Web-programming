using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab9.Models;
using Lab9.DataAbstractionLayer;

namespace Lab9.Controllers
{
    public class AddBookController : Controller
    {
        // GET: AddBook
        public ActionResult Index()
        {
            return View("AddBook");
        }

        public string AddNewBook()
        {
            string author = Request.Params["author"];
            string title = Request.Params["title"];
            string genre = Request.Params["genre"];
            int pages = Int32.Parse(Request.Params["pages"]);
            Book book = new Book();
            book.author = author;
            book.title = title;
            book.genre = genre;
            book.pages = pages;
            book.lended = "NO";
            DAL dal = new DAL();
            bool result = dal.addBook(book);
            if (result)
                return "Book was successfully added";
            else
                return "Book coudln't be added";
        }
    }
}