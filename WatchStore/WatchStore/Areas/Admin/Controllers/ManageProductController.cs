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
            ViewBag.Title = "Product";
            IEnumerable<Product> listP = listProduct();
            IEnumerable<Brand> listB = listBrand();
            IEnumerable<Customer> listC = listAccount();
            IEnumerable<Order> listO = listOrder();

            SharedManage sm = new SharedManage(listP, listC, listB, listO);
            return View(sm);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult ViewP(string pid)
        {
            IEnumerable<Image> imgs = listI(pid);
            Product p = pDetail(pid);
            ShareViewProduct sv = new ShareViewProduct(p, imgs);

            return View(sv);
        }
        public Product pDetail(string pid)
        {
            Product pu = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("manageproduct?pid=" + pid);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<Product>();
                    readRe.Wait();
                    pu = readRe.Result;
                }

            }
            return pu;
        }
        public IEnumerable<Image> listI(string iid)
        {
            ViewBag.Title = "Product";
            IEnumerable<Image> imgs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var rs = client.GetAsync("manageproduct?iid=" + iid);
                rs.Wait();
                var re = rs.Result;
                if (re.IsSuccessStatusCode)
                {
                    var readRe = re.Content.ReadAsAsync<IList<Image>>();
                    readRe.Wait();
                    imgs = readRe.Result;
                }

            }
            return (imgs);
        }


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
        }
    }
}