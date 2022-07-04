using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WatchStore.Models;

namespace WatchStore.Areas.Admin.Controllers
{
    public class ManageProductController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index() 
        {
            IEnumerable<Product> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetListProductAdmin");
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Product>>();
                    readRe.Wait();
                    products = readRe.Result;
                }

            }
            return View(products);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult ViewP(String id)
        {
            Product product = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("GetDetailProductAdmin?id=" + id);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<Product>();
                    readRe.Wait();
                    product = readRe.Result;
                }

            }
            return View(product);
        }

        public JsonResult DeleteProduct(String Id)
        {
            Product product = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var deleteTask = client.DeleteAsync("DeleteProductAdmin?id=" + Id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Json(new { text = "remove successfully" }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { text = "remove fail" }, JsonRequestBehavior.AllowGet);
        }


        /*
                public IEnumerable<Customer> listAccount()
                {
                    ViewBag.Title = "Product";
                    IEnumerable<Customer> customers = null;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44380/api/");
                        var rs = client.GetAsync("manageaccount");
                        rs.Wait();
                        var re = rs.Result;
                        if (re.IsSuccessStatusCode)
                        {
                            var readRe = re.Content.ReadAsAsync<IList<Customer>>();
                            readRe.Wait();
                            customers = readRe.Result;
                        }

                    }
                    return customers;
                }
                public IEnumerable<Brand> listBrand()
                {
                    ViewBag.Title = "Product";
                    IEnumerable<Brand> brands = null;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44380/api/");
                        var rs = client.GetAsync("managebrand");
                        rs.Wait();
                        var re = rs.Result;
                        if (re.IsSuccessStatusCode)
                        {
                            var readRe = re.Content.ReadAsAsync<IList<Brand>>();
                            readRe.Wait();
                            brands = readRe.Result;
                        }

                    }
                    return brands;
                }
                public IEnumerable<Product> listProduct()

                {
                    ViewBag.Title = "Product";
                    IEnumerable<Product> products = null;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44380/api/");
                        var rs = client.GetAsync("manageproduct");
                        rs.Wait();
                        var re = rs.Result;
                        if (re.IsSuccessStatusCode)
                        {
                            var readRe = re.Content.ReadAsAsync<IList<Product>>();
                            readRe.Wait();
                            products = readRe.Result;
                        }

                    }
                    return products;
                }

                public IEnumerable<Order> listOrder()

                {
                    ViewBag.Title = "Product";
                    IEnumerable<Order> orders = null;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44380/api/");
                        var rs = client.GetAsync("manageorder");
                        rs.Wait();
                        var re = rs.Result;
                        if (re.IsSuccessStatusCode)
                        {
                            var readRe = re.Content.ReadAsAsync<IList<Order>>();
                            readRe.Wait();
                            orders = readRe.Result;
                        }

                    }
                    return orders;
                }*/
    }
}