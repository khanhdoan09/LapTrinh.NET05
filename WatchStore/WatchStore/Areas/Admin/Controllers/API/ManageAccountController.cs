﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API
{
    public class ManageAccountController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();
        public IHttpActionResult GetAccount()
        {
            IList<Models.Customer> customers = db.Customers.OrderByDescending(c => c.Id).ToList();
            return Ok(customers);
        }
    }
}
