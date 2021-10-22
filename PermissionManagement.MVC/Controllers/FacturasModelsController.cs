using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Scripting.Hosting;
using Senasoft.Data;
using Senasoft.Models;

namespace Senasoft.Controllers
{
    [Authorize]
    public class FacturasModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturasModelsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="Admin, Basic, SuperAdmin")]
        // GET: FacturasModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.facturas.Include(f => f.TiposFacturaModel);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "Admin, Basic, SuperAdmin")]
        // GET: FacturasModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturasModel = await _context.facturas
                .Include(f => f.TiposFacturaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturasModel == null)
            {
                return NotFound();
            }

            return View(facturasModel);
        }
        
        public IActionResult Inteligencia()
        {

            ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();
            ScriptRuntime runtime = engine.Runtime;
            ScriptScope scope = runtime.CreateScope();
            ScriptSource script = engine.CreateScriptSourceFromFile(@"Uploads///Factura///Diego.py");
            var compiled = script.Compile();
            compiled.Execute(scope);
            runtime.Shutdown();
            //var ipy = Python.CreateRuntime();
            //var path = @"Uploads///Factura///Diego.py";
            //dynamic op = ipy.UseFile(path);

            var ipy = Python.CreateRuntime();
            var path = @"Uploads///Factura///Diego.py";
            dynamic op = ipy.UseFile(path);


            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin, SuperAdmin, Crear")]
        // GET: FacturasModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacturasModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,SuperAdmin, Crear")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacturasModel user, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return View(user);
            }
            else if (user.IdFactura == 1)
            {
                var ext = Path.GetExtension(file.FileName);
                var resumeName = "FACTURA" + DateTime.Now.ToString("YYmmdd") + ext;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/FacturaElectronica/", resumeName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fStream);
                }

                user.Resume = "Uploads/FacturaElectronica/" + resumeName;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else if (user.IdFactura == 2)
            {
                var ext = Path.GetExtension(file.FileName);
                var resumeName = "NC" + DateTime.Now.ToString("YYmmdd") + ext;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Nota_credito/", resumeName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fStream);
                }

                user.Resume = "Uploads/Nota_credito/" + resumeName;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else if (user.IdFactura == 3)
            {
                var ext = Path.GetExtension(file.FileName);
                var resumeName = "ND" + DateTime.Now.ToString("YYmmdd") + ext;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Nota_debito/", resumeName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fStream);
                }

                user.Resume = "Uploads/Nota_debito/" + resumeName;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else if (user.IdFactura == 4)
            {
                var ext = Path.GetExtension(file.FileName);
                var resumeName = "ND" + DateTime.Now.ToString("YYmmdd") + ext;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/CuentasCobro/", resumeName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fStream);
                }

                user.Resume = "Uploads/CuentasCobro/" + resumeName;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else if (user.IdFactura == 4)
            {
                var ext = Path.GetExtension(file.FileName);
                var resumeName = "ND" + DateTime.Now.ToString("YYmmdd") + ext;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads/Documentos/", resumeName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fStream);
                }

                user.Resume = "Uploads/Documentos/" + resumeName;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(user);
            }
        }
        [Authorize(Roles = "Admin,SuperAdmin, Editar")]
        // GET: FacturasModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturasModel = await _context.facturas.FindAsync(id);
            if (facturasModel == null)
            {
                return NotFound();
            }
            ViewData["IdFactura"] = new SelectList(_context.TiposFacturas, "Id", "Id", facturasModel.IdFactura);
            return View(facturasModel);
        }

        // POST: FacturasModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin, Editar")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,Resume,IdFactura")] FacturasModel facturasModel)
        {
            if (id != facturasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturasModelExists(facturasModel.Id))
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
            ViewData["IdFactura"] = new SelectList(_context.TiposFacturas, "Id", "Id", facturasModel.IdFactura);
            return View(facturasModel);
        }

        // GET: FacturasModels/Delete/5
        [Authorize(Roles = "Admin, SuperAdmin, Eliminar")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturasModel = await _context.facturas
                .Include(f => f.TiposFacturaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturasModel == null)
            {
                return NotFound();
            }

            return View(facturasModel);
        }
        [Authorize(Roles = "Admin, SuperAdmin, Eliminar")]
        // POST: FacturasModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturasModel = await _context.facturas.FindAsync(id);
            _context.facturas.Remove(facturasModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturasModelExists(int id)
        {
            return _context.facturas.Any(e => e.Id == id);
        }
    }
}
