using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers.API.Product
{
    public class DeleteProductAdminController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();

        [HttpDelete]
        public IHttpActionResult DeleteProduct(String Id)
        {
            Models.Product productSelected = db.Products.SingleOrDefault(p => p.Id == Id);
            Image imageSelected = db.Images.FirstOrDefault(i => i.Product == Id);

            if (productSelected != null && imageSelected != null)
            {
                db.Products.Remove(productSelected);
                /* bug là do chưa set restrict trong csdl*/
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
