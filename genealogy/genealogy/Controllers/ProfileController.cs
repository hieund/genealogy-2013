using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.Models;
namespace genealogy.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult LoginForm()
        {
            return PartialView();
        }


        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(UserModels mdUser)
        {

            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult ProfileInfo()
        {

            return View();
        }

        public ActionResult AccountInfo()
        {

            return View();
        }
    }
}
