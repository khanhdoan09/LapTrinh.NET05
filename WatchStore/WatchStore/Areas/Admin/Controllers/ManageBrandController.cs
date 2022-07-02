using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers
{
    public class ManageBrandController : Controller
    {
        // GET: Admin/ManageBrand
        public ActionResult Index()

        {
          return View();
        }
    }
}