using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsitesProject.Models;
using WebsitesProject.Models.WebsiteViewModels;

namespace WebsitesProject.Controllers
{
    public class WebsitesController : Controller
    {
        private readonly WebsitesContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public WebsitesController(WebsitesContext context, UserManager<User> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        private async Task<User> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(User);
        }

        // GET: Websites
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var websites = await _context.Websites
                                         .OrderByDescending(m => m.CreatedAt)
                                         .Select(m => _mapper.Map<WebsiteViewModel>(m))
                                         .ToListAsync();
            return View(websites);
        }

        // GET: Websites
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UserWebsites()
        {
            var currentUser = await GetCurrentUser();
            var websites = await _context.Websites
                                         .Where(w => w.User == currentUser)
                                         .Select(m => _mapper.Map<WebsiteViewModel>(m))
                                         .ToListAsync();

            return View(websites);
        }

        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }


            var website = await _context.Websites
                                        .SingleOrDefaultAsync(m => m.WebsiteId == id);
            if (website == null)
            {
                return View("NotFound");
            }

            if (User.IsInRole("User") && !WebsiteOwner(website))
            {
                return View("AccessDenied");   
            }
            else
            {
                var viewModel = _mapper.Map<DetailsWebsiteViewModel>(website);
                return View(viewModel);
            }
        }

        // GET: Websites/Create
        [Authorize(Roles = "Admin, User")]
        public IActionResult Create()
        {
            var viewModel = new CreateWebsiteViewModel();
            return View(viewModel);
        }

        // POST: Websites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create(CreateWebsiteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var website = new Website
            {
                Domain = model.Domain,
                Description = model.Description,
                CreatedAt = model.CreatedAt,
                User = await GetCurrentUser()
            };

            _context.Add(website);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Websites/Edit/5
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var website = await _context.Websites.SingleOrDefaultAsync(m => m.WebsiteId == id);
            if (website == null)
            {
                return View("NotFound");
            }

            if (User.IsInRole("User") && !WebsiteOwner(website))
            {
                return View("AccessDenied");
            }
            else
            {
                var viewModel = _mapper.Map<EditWebsiteViewModel>(website);
                return View(viewModel);
            }
        }

        // POST: Websites/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditWebsiteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var website = await _context.Websites.SingleOrDefaultAsync(m => m.WebsiteId == model.WebsiteId);
                
                website.Domain = model.Domain;
                website.Description = model.Description;
                website.CreatedAt = model.CreatedAt;

                _context.Update(website);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteExists(model.WebsiteId))
                {
                    return View("NotFound");
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Websites/Delete/5
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var website = await _context.Websites
                .SingleOrDefaultAsync(m => m.WebsiteId == id);
            if (website == null)
            {
                return View("NotFound");
            }

            if (User.IsInRole("User") && !WebsiteOwner(website))
            {
                return View("AccessDenied");
            }
            else
            {
                var viewModel = _mapper.Map<DeleteWebsiteViewModel>(website);
                return View(viewModel);
            }
        }

        // POST: Websites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteConfirmed(DeleteWebsiteViewModel model)
        {
            var website = await _context.Websites.SingleOrDefaultAsync(m => m.WebsiteId == model.WebsiteId);
            _context.Websites.Remove(website);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebsiteExists(int id)
        {
            return _context.Websites.Any(e => e.WebsiteId == id);
        }

        public IActionResult VerifyDomain(string domain, DateTime createdAt)
        {
            var website = from w in _context.Websites
                          where w.Domain == domain && w.CreatedAt.Date.Equals(createdAt.Date)
                          select w;
            if (website != null)
                return Json(data: "There is website with this domain and created at date in database!");
            return Json(data: true);
        }

        [HttpGet]
        public bool WebsiteOwner(Website website)
        {
            var currentUser = GetCurrentUser();
            var websiteUser = website.User;
            return websiteUser.Id.Equals(currentUser.Id);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> Foo()
        {
            return Json(data: false);
        }
    }
}
