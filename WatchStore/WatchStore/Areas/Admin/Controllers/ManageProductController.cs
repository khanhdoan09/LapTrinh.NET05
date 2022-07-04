﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        public ActionResult Edit(string Id)
        {
            Product product = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("EditProductAdmin?id=" + Id);
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

        [HttpPost]
        public JsonResult SaveEditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                saveImage(product.Id.ToLower());



                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44380/api/");
                    var rs = client.PutAsJsonAsync<Product>("EditProductAdmin", product);
                    rs.Wait();
                    var re = rs.Result;
                    if (re.IsSuccessStatusCode)
                    {
                        return Json(new { text = "edit successfully"}, JsonRequestBehavior.AllowGet);
                    }

                }
            }

            return Json(new { text = "edit error" }, JsonRequestBehavior.AllowGet);
        }

        private void saveImage(String Id)
        {
            var i1 = Request.Files["image_1"];
            var i2 = Request.Files["image_2"];
            var i3 = Request.Files["image_3"];
            var i4 = Request.Files["image_4"];
            var i5 = Request.Files["image_5"];
            if (i1 != null)
            {
                var path1 = Server.MapPath("~/Content/img/product/" + Id + "_1.jpg");
                i1.SaveAs(path1);
            }
            if (i2 != null)
            {
                var path2 = Server.MapPath("~/Content/img/product/" + Id + "_2.jpg");
                i2.SaveAs(path2);
            }
            if (i3 != null)
            {
                var path3 = Server.MapPath("~/Content/img/product/" + Id + "_3.jpg");
                i3.SaveAs(path3);
            }
            if (i4 != null)
            {
                var path4 = Server.MapPath("~/Content/img/product/" + Id + "_4.jpg");
                i4.SaveAs(path4);
            }
            if (i5 != null)
            {
                var path5 = Server.MapPath("~/Content/img/product/" + Id + "_5.jpg");
                i5.SaveAs(path5);
            }
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