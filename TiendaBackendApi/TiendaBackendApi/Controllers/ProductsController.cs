using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TiendaBackendApi.Data;
using TiendaBackendApi.Models;

namespace TiendaBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound();
            return producto;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProducto(Product producto)
        {
            
            var categoria = await _context.Categorias.FindAsync(producto.CategoriasId);

            if (categoria == null)
                return BadRequest(new { message = "La categoría especificada no existe" });

        

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Product producto)
        {
            if (id != producto.Id)
                return BadRequest();

            var categoria = await _context.Categorias.FindAsync(producto.CategoriasId);
            if (categoria == null)
                return BadRequest(new { message = "La categoría especificada no existe" });

            producto.Categorias = categoria;

            _context.Entry(producto).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Productos.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound();
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
