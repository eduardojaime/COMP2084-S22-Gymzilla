using Gymzilla.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gymzilla.Controllers
{
    public class ShopController : Controller
    {
        // db connection
        private readonly ApplicationDbContext _context;

        // constructor
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // fetch list of Categories to display in view so user can choose 1
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();

            // load the view and pass it the list of category objects sorted a-z
            return View(categories);
        }
    }
}
