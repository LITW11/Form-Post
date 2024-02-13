using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class NorthwindController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;";

        public ActionResult SearchProducts()
        {
            return View();
        }

        public ActionResult SearchResults(int minStock, int maxStock)
        {
            NorthwindDb db = new NorthwindDb(_connectionString);

            return View(new SearchProductsViewModel
            {
                Products = db.GetProducts(minStock, maxStock),
                MinStock = minStock,
                MaxStock = maxStock
            });
        }
    }
}