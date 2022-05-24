using Gymzilla.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gymzilla.Controllers
{
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            // use the Brand model to mock up a list of Brand objects for display in the view
            var brands = new List<Brand>();

            for (var i = 1; i < 10; i++)
            {
                brands.Add(new Brand { Name = "Brand " + i.ToString() });
            }

            // load the view and pass it the list of brands
            return View(brands);
        }

        public IActionResult ShopByBrand(string brand)
        {
            if (brand == null)
            {
                return RedirectToAction("Index");
            }

            // take the brand name passed as an input param and set in the ViewData to display in the view
            ViewData["brand"] = brand;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
