using efcoreApp.Data;
using efcoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OwnerController: Controller
    {
        private readonly DataContext _context;

        public OwnerController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var owner = await _context.Owners.Include(o => o.Car).ToListAsync();
            return View(owner);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Car = new SelectList(await _context.Car.ToListAsync(),"CarId","FullName");
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Create(Owner model)
        {
            _context.Owners.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return View("NotFound");
            }
            var entity = await _context
                            .Owners
                            .FirstOrDefaultAsync(c => c.OwnerId == id);
            if(entity==null)
            {
                return View("NotFound");
            }
            ViewBag.Car = new SelectList(await _context.Car.ToListAsync(),"CarId","FullName");
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(int id,OwnerViewModel model)
        {
            if(id!= model.OwnerId)
            {
                return View("NotFound");
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Owner(){
                        OwnerId = model.OwnerId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Phone = model.Phone,
                        StartDate = model.StartDate,
                        CarId = model.CarId,
                    });
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!_context.Owners.Any(c=>c.OwnerId==model.OwnerId))
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
            var entity = await _context.Owners.FindAsync(id);
            if(entity==null)
            {
                return View("NotFound");
            }
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var entity = await _context.Owners.FindAsync(id);
            if(entity == null)
            {
                return View("NotFound");
            }
            _context.Owners.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

/*_context.Update(new Owner(){
                        OwnerId = model.OwnerId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Phone = model.Phone,
                        StartDate = model.StartDate,
                        CarId = model.CarId,
                    });*/