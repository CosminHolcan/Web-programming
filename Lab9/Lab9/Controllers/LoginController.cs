using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab9.DataAbstractionLayer;

namespace Lab9.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            string user = Request.Params["username"];
            string pwd = Request.Params["password"];
            DAL dal = new DAL();
            bool result = dal.login(user, pwd);
            return Json(new { success = result });
        }

    }
}