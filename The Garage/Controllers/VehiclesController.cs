using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using The_Garage.Data;
using The_Garage.Models;

namespace The_Garage.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly The_GarageContext _context;

        public VehiclesController(The_GarageContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var the_GarageContext = _context.Vehicles.Include(v => v.Member).Include(v => v.Type);
            return View(await the_GarageContext.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .Include(v => v.Member)
                .Include(v => v.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Set<Members>(), "Id", "Id");
            ViewData["TypeId"] = new SelectList(_context.Set<Types>(), "Id", "Id");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegNr,TimeOfParking,NumnOfWheels,Color,Model,Brand,TypeId,MemberId")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Set<Members>(), "Id", "Id", vehicles.MemberId);
            ViewData["TypeId"] = new SelectList(_context.Set<Types>(), "Id", "Id", vehicles.TypeId);
            return View(vehicles);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Set<Members>(), "Id", "Id", vehicles.MemberId);
            ViewData["TypeId"] = new SelectList(_context.Set<Types>(), "Id", "Id", vehicles.TypeId);
            return View(vehicles);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNr,TimeOfParking,NumnOfWheels,Color,Model,Brand,TypeId,MemberId")] Vehicles vehicles)
        {
            if (id != vehicles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclesExists(vehicles.Id))
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
            ViewData["MemberId"] = new SelectList(_context.Set<Members>(), "Id", "Id", vehicles.MemberId);
            ViewData["TypeId"] = new SelectList(_context.Set<Types>(), "Id", "Id", vehicles.TypeId);
            return View(vehicles);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .Include(v => v.Member)
                .Include(v => v.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Vehicles/Search

        public async Task<IActionResult> Search(string regnr)
        {
            var model = string.IsNullOrWhiteSpace(regnr) ?
                await _context.Vehicles.ToListAsync() :
                await _context.Vehicles.Where(v => v.RegNr == regnr).ToListAsync();

            return View(nameof(Index), model);
        }

        // GET: Vehicles/Receipt
        public async Task<IActionResult> Receipt(int id)
        {
            var local_vehicle = await _context.Vehicles.FindAsync(id);

            var endTime = DateTime.UtcNow;
            var startTime = local_vehicle.TimeOfParking;
            var totalTime = (endTime - startTime);

            string formattedTime = $"{totalTime.Hours} hours and {totalTime.Minutes} minutes";

            var calculatedPrice = (int)((totalTime.TotalMinutes / 60) * 100);

            var price = $"{calculatedPrice} KR";

            var local_model = new ReceiptViewModel
            {
                RegNr = local_vehicle.RegNr,
                TimeOfParking = local_vehicle.TimeOfParking,
                TimeOfUnParking = endTime,
                TotalTime = formattedTime,
                Price = price
            };

            return View(local_model);

        }


        private bool VehiclesExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DetailsView()
        {
            var model = await _context.Vehicles
                .Include(t => t.Type)
                .Include(t=>t.Member)
                .Select(t => new DetailViewModel
                {
                    RegNr = t.RegNr,
                    TimeOfParking = t.TimeOfParking,
                    Member = t.Member.FirstName+" "+t.Member.LastName,
                    Type = t.Type.TypeOfVehicle,
                    NumnOfWheels = t.NumnOfWheels,
                    Color = t.Color,
                    Brand= t.Brand,
                    ModelOfVehicle = t.Model

                })
                .ToListAsync();

            return View(model);
        }
    }
}
