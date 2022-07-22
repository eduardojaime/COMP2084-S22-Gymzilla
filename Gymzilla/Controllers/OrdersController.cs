﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gymzilla.Data;
using Gymzilla.Models;

namespace Gymzilla.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders (History)
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return View(await _context.Orders.OrderByDescending(o => o.OrderTime).ToListAsync());
            }
            else
            {
                return View(await _context.Orders
                    .Where(o => o.CustomerId == User.Identity.Name)
                    .OrderByDescending(o => o.OrderTime)
                    .ToListAsync());
            }
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                            .Include(o => o.OrderItems) // tells linq to also include related orderitem records > JOIN
                            .ThenInclude(oi => oi.Product) // tells linq to also include related product records > JOIN
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
