using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API
{
    public class ManageBrandController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetBrands()
        {
            IList<Brand> brands = db.Brands.ToList();
            return Ok(brands);
        }
    }
}
