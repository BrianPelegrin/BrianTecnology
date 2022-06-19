using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrianTecnology.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace BrianTecnology.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly MarketContext _context;
        public CategoriaController (MarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? busqueda = null)
        {
            ViewData[nameof(busqueda)] = busqueda;
            if (string.IsNullOrEmpty(busqueda))
            {
                return View(await _context.Categoria.ToListAsync());
            }
            else
            {
                var lista = _context.Categoria.Where(m => m.Descripcion.Contains(busqueda));
                return View( await lista.ToListAsync());
            }

        }

        [HttpGet]
        public IActionResult CrearCategoria()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCategoria(Categorium categoria)
        {
            if (ModelState.IsValid)
            {
                await _context.Categoria.AddAsync(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditarCategoria(int? id)
        {
            if(id == null) 
            {
                return NotFound();
            }
            var modelo = _context.Categoria.Find(id);
            if(modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCategoria(Categorium categoria)
        {
            if (ModelState.IsValid)
            {
                 _context.Categoria.Update(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult EliminarCategoria(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var modelo = _context.Categoria.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarCategoria(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var modelo = await _context.Categoria.FindAsync(Convert.ToInt32(id));
            if (modelo == null)
            {
                return NotFound();
            }
            _context.Categoria.Remove(modelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
