using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API
{
    public class ManageOrderController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetOrders()
        {
            IList<Order> orders = db.Orders.OrderByDescending(p => p.OrderDate).ToList();
            return Ok(orders);
        }
    }
}
