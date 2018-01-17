using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsitesProject.Models;
using WebsitesProject.Models.OrderViewModels;

namespace WebsitesProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly WebsitesContext _context;
        private readonly IMapper _mapper;

        public OrdersController(WebsitesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                                 .Include(u => u.Website)
                                 .Select(m => _mapper.Map<OrderViewModel>(m))
                                 .ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return View("NotFound");
            }
            var order = await _context.Orders
                .Include(u => u.Website)
                .SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return View("NotFound");
            }

            var viewModel = _mapper.Map<DetailsOrderViewModel>(order);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateOrderViewModel
            {
                Websites = _context.Websites
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Websites = _context.Websites;
                return View(model);
            }

            var order = new Order
            {
                Price = model.Price,
                Description = model.Description,
                Status = model.Status,
                Website = await _context.Websites.SingleOrDefaultAsync(c => c.WebsiteId == model.WebsiteId)
            };

            _context.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var order = await _context.Orders.SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null || id == null)
            {
                return View("NotFound");
            }
            var viewModel = _mapper.Map<EditOrderViewModel>(order);
            viewModel.Websites = _context.Websites;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var order = await _context.Orders.SingleOrDefaultAsync(m => m.OrderId == model.OrderId);

                order.Price = model.Price;
                order.Description = model.Description;
                order.Status = model.Status;
                Console.WriteLine("Website ID {0}", model.WebsiteId);
                order.Website = await _context.Websites.SingleOrDefaultAsync(c => c.WebsiteId == model.WebsiteId);
                Console.WriteLine("Website: {0}", order.Website.Domain);
                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(model.OrderId))
                {
                    return View("NotFound");
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var order = await _context.Orders
                .SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return View("NotFound");
            }

            var viewModel = _mapper.Map<DeleteOrderViewModel>(order);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DeleteOrderViewModel model)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(m => m.OrderId == model.OrderId);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
