using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsitesProject.Models;

namespace WebsitesProject.Controllers
{
    public class WebsitesController : Controller
    {
        private readonly WebsitesContext _context;
        private readonly UserManager<User> _userManager;


        public WebsitesController(WebsitesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            User usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        // GET: Websites
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Website.ToListAsync());
        }

        // GET: Websites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var website = await _context.Website
                .SingleOrDefaultAsync(m => m.ID == id);
            if (website == null)
            {
                return NotFound();
            }

            return View(website);
        }

        // GET: Websites
        public async Task<IActionResult> UserWebsites()
        {
            var currentUserId = await GetCurrentUserId();
            return View(await _context.Website.Where(w => w.UserId == currentUserId).ToListAsync());
        }

        // GET: Websites/Create
        public IActionResult Create()
        {
            ViewBag.OrderID = new SelectList(_context.Order, "ID", "Description");
            return View();
        }

        // POST: Websites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Domain,Description,CreatedAt,UserId")] Website website)
        {
            var currentUserId = await GetCurrentUserId();
            if (ModelState.IsValid && currentUserId != null)
            {
                website.UserId = currentUserId;
                _context.Add(website);
                await _context.SaveChangesAsync();
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(UserWebsites));
                }
            }

            return View(website);
        }

        // GET: Websites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var website = await _context.Website.SingleOrDefaultAsync(m => m.ID == id);
            if (website == null)
            {
                return NotFound();
            }
            return View(website);
        }

        // POST: Websites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Domain,Description,CreatedAt")] Website website)
        {
            if (id != website.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(website);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebsiteExists(website.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(website);
        }

        // GET: Websites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var website = await _context.Website
                .SingleOrDefaultAsync(m => m.ID == id);
            if (website == null)
            {
                return NotFound();
            }

            return View(website);
        }

        // POST: Websites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var website = await _context.Website.SingleOrDefaultAsync(m => m.ID == id);
            _context.Website.Remove(website);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebsiteExists(int id)
        {
            return _context.Website.Any(e => e.ID == id);
        }
    }
}
