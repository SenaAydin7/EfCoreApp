using System.Data;
using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class ShopController:Controller
    {
        private readonly DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var shops = await _context.Shops.ToListAsync();
            return View(shops);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Create(Shops model)
        {
            _context.Shops.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return View("NotFound");
            }
            var shop = await _context
                             .Shops
                             .Include(s => s.ShopReg)
                             .ThenInclude(s => s.Car)
                             .FirstOrDefaultAsync(s => s.ShopId == id);
            if(shop==null)
            {
                return View("NotFound");
            }
            return View(shop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(int id,Shops model)
        {
            if(id!= model.ShopId)
            {
                return View("NotFound");
            }
            var shop = await _context.Shops.FindAsync(id);
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException)
                {
                    if(!_context.Shops.Any(c=>c.ShopId==model.ShopId))
                    {
                        return View("NotFound");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return View("NotFound");
            }
            var shop = await _context.Shops.FindAsync(id);
            if(shop==null)
            {
                return View("NotFound");
            }
            return View(shop);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if(shop == null)
            {
                return View("NotFound");
            }
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}