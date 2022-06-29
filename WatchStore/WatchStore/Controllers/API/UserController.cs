using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WatchStore.Models;

namespace WatchStore.Controllers.API
{
    public class UserController : ApiController
    {
        DbWatchShopEntities db = new DbWatchShopEntities();

        //public IHttpActionResult GetUsers()
        //{
        //    IList<Customer> customers = db.Customers.ToList();
        //    return Ok(customers);
        //}
        //public IHttpActionResult PostNewCustomer(Customer c)
        //{

           
        //    c.Id = "user_" + db.Customers.ToArray().Count();
        //    c.isAdmin = 0;
        //    string enPass = toEncryptedPassword(c.Password);
        //    c.Password = enPass;
        //    db.Customers.Add(c);
        //    db.SaveChanges();
        //    return Ok();
        //}
        //public string toEncryptedPassword(string password)
        //{
        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //    byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
        //    StringBuilder sbHash = new StringBuilder();
        //    foreach (byte b in bHash)
        //    {
        //        sbHash.Append(String.Format("{0:x2}", b));
        //    }
        //    return sbHash.ToString();
        //}
    }
}
