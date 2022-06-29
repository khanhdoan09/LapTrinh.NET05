using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {          
            return View();
        }
        public ActionResult Login(string email,string password)
        {
            return View();
        }
        public ActionResult Register()
        {    
            return View();
        }
    }
}