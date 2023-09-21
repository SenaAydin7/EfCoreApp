using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace efcoreApp.Controllers
{
    public class CarController: Controller
    {
        private readonly DataContext _context;

        public CarController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Car.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Cars = new SelectList(await _context.Car.ToListAsync(),"CarId","FullName");
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Create(Cars model)
        {
            _context.Car.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return View("NotFound");
            }
            var car = await _context
                            .Car
                            .Include(c => c.ShopReg)
                            .ThenInclude(c => c.Shop)
                            .FirstOrDefaultAsync(c => c.CarId == id);
            if(car==null)
            {
                return View("NotFound");
            }
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(int id,Cars model)
        {
            if(id!= model.CarId)
            {
                return View("NotFound");
            }
            var car = await _context.Car.FindAsync(id);
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Entry(car).CurrentValues.SetValues(model);
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_context.Car.Any(c=>c.CarId==model.CarId))
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
            var car = await _context.Car.FindAsync(id);
            if(car==null)
            {
                return View("NotFound");
            }
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var car = await _context.Car.FindAsync(id);
            if(car == null)
            {
                return View("NotFound");
            }
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}