using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Senasoft.Data;
using Senasoft.Models;

namespace Senasoft.Controllers
{
    public class TiposFacturasModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiposFacturasModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TiposFacturasModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposFacturas.ToListAsync());
        }

        // GET: TiposFacturasModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposFacturasModel = await _context.TiposFacturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposFacturasModel == null)
            {
                return NotFound();
            }

            return View(tiposFacturasModel);
        }

        // GET: TiposFacturasModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposFacturasModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TiposFacturasModel tiposFacturasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposFacturasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposFacturasModel);
        }

        // GET: TiposFacturasModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposFacturasModel = await _context.TiposFacturas.FindAsync(id);
            if (tiposFacturasModel == null)
            {
                return NotFound();
            }
            return View(tiposFacturasModel);
        }

        // POST: TiposFacturasModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TiposFacturasModel tiposFacturasModel)
        {
            if (id != tiposFacturasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposFacturasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposFacturasModelExists(tiposFacturasModel.Id))
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
            return View(tiposFacturasModel);
        }

        // GET: TiposFacturasModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposFacturasModel = await _context.TiposFacturas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposFacturasModel == null)
            {
                return NotFound();
            }

            return View(tiposFacturasModel);
        }

        // POST: TiposFacturasModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposFacturasModel = await _context.TiposFacturas.FindAsync(id);
            _context.TiposFacturas.Remove(tiposFacturasModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposFacturasModelExists(int id)
        {
            return _context.TiposFacturas.Any(e => e.Id == id);
        }
    }
}
