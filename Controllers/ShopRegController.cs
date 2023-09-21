using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class ShopRegController:Controller
    {
        private readonly DataContext _context;
        public ShopRegController(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var shopRegisters = await _context
                                .ShopReg
                                .Include(x => x.Car)
                                .Include(x => x.Shop)
                                .ToListAsync();
            return View(shopRegisters);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Cars = new SelectList(await _context.Car.ToListAsync(),"CarId","FullName");
            ViewBag.Shops = new SelectList(await _context.Shops.ToListAsync(),"ShopId","Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShopReg model)
        {
            model.RegDate = DateTime.Now;
            _context.ShopReg.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}