using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrianTecnology.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BrianTecnology.Controllers
{
    public class ProductoController : Controller
    {
        private readonly MarketContext _context;

        public ProductoController (MarketContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? busqueda = null)
        {
            ViewData[nameof(busqueda)] = busqueda;
            if(string.IsNullOrEmpty(busqueda))
            {
                var lista = await _context.Productos.Include(m => m.IdCategoriaNavigation).ToListAsync();
                return View(lista);
            }
            else
            {
                var lista = await _context.Productos.Include(m => m.IdCategoriaNavigation).Where(m=> m.Marca.Contains(busqueda)).ToArrayAsync();
                return View(lista);
                
            }
            

            
        }
        //---------------------------------------Crear Producto--------------------------------------

        [HttpGet]
        public IActionResult CrearProducto()
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProducto(Producto modelo)
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion", modelo.IdCategoria);
            if (ModelState.IsValid)
            {
                await _context.AddAsync(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                
                return View();
            }
            
        }
        //-----------------------------Eliminar Producto-------------------------------------
        [HttpGet]
        public IActionResult EliminarProducto(int? id)
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion");

            if (id == null)
            {
                return NotFound();
            }
            var modelo = _context.Productos.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarProducto(string? id) 
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion");
            if (string.IsNullOrEmpty(id)) 
            {
                return NotFound(); 
            }
            var modelo = await _context.Productos.FindAsync(Convert.ToInt32(id));
            if(modelo == null) 
            { 
                return NotFound(); 
            }
            _context.Productos.Remove(modelo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }
        //--------------------------Editar Produccto------------------------------------
        [HttpGet]
        public IActionResult EditarProducto(int? id)
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion");

            if (id == null)
            {
                return NotFound();
            }
            var modelo = _context.Productos.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProducto(Producto producto)
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion"); 
           
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);

        }
        //------------------------------Detalle Producto-------------------------------------
        [HttpGet]
        public IActionResult DetallesProducto(int? id)
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "Descripcion");

            if (id == null)
            {
                return NotFound();
            }
            var modelo = _context.Productos.Include(m=>m.IdCategoriaNavigation).Where(m=> m.IdProducto == id).FirstOrDefault();
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }



    }
}
