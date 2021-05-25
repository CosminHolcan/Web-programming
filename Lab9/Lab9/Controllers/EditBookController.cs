using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab9.Models;
using Lab9.DataAbstractionLayer;

namespace Lab9.Controllers
{
    public class EditBookController : Controller
    {
        // GET: EditBook
        public ActionResult Index(int id)
        {
            return View("EditBook");
        }

        public string DeleteBook()
        {
            int id =Int32.Parse(Request.Params["id"]);
            DAL dal = new DAL();
            bool result = dal.deleteBook(id);
            if (result)
                return "Book was successfully deleted";
            else
                return "Book coudln't be deleted";
        }

        public string UpdateBook()
        {
            int id = Int32.Parse(Request.Params["id"]);
            int pages = Int32.Parse(Request.Params["pages"]);
            string genre = Request.Params["genre"];
            string lended = Request.Params["lended"];
            DAL dal = new DAL();
            bool result = dal.updateBook(id, pages, genre, lended);
            if (result)
                return "Book was successfully updated";
            else
                return "Book coudln't be updated";
        }

        public ActionResult GetOneBook()
        {
            int id = Int32.Parse(Request.Params["id"]);
            DAL dal = new DAL();
            Book book = dal.getOneBook(id);
            return Json(new { book = book }, JsonRequestBehavior.AllowGet);
        }
    }
}