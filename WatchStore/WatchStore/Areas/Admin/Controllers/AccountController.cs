using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WatchStore.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}