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
    public class MembersController : Controller
    {
        private readonly The_GarageContext _context;

        public MembersController(The_GarageContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _context.Members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (members == null)
            {
                return NotFound();
            }

            var model = new MemberDetailsViewModel();
            model.Id = members.Id;
            model.FirstName = members.FirstName;
            model.LastName = members.LastName;
            model.NumberOfVehicles = _context.Vehicles.Count(v => v.MemberId == members.Id);
            //            model.Count = member.Vehicle.Count;
            model.TheVehicles = _context.Vehicles.Where(v => v.MemberId == members.Id);

            //return View(members);
            return View(model);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] Members members)
        {
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(members);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }
            return View(members);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Members members)
        {
            if (id != members.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.Id))
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
            return View(members);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.Members.FindAsync(id);
            _context.Members.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }

        

        public async Task<IActionResult> Search(string firstname, string lastname)
        {
            if(firstname == null || lastname == null)
            {
                //return NotFound();
                //return View(nameof(NotComplete));
                return RedirectToAction(nameof(NotComplete));

            }

            var member = await _context.Members
 //               .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.FirstName == firstname && m.LastName == lastname);

            if(member == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(MemberNotFound));
            }

            var model = new MemberDetailsViewModel();
            model.Id = member.Id;
            model.FirstName = member.FirstName;
            model.LastName = member.LastName;
            model.NumberOfVehicles = _context.Vehicles.Count(v => v.MemberId == member.Id);
            //            model.Count = member.Vehicle.Count;
            model.TheVehicles = _context.Vehicles.Where(v => v.MemberId == member.Id);


            return View(nameof(Search), model);
        }

        public ViewResult NotComplete()
        {
            return View(nameof(NotComplete));
        }

        public ViewResult MemberNotFound()
        {
            return View(nameof(MemberNotFound));
        }
    }
}
