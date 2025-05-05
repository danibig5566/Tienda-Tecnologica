using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TiendaBackendApi.Data;
using TiendaBackendApi.Models;
using AutoMapper;


namespace TiendaBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
      

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductos()
        {
            var productos = await _context.Productos.Include(p => p.Categorias).ToListAsync();
            var productosDTO = _mapper.Map<IEnumerable<ProductDTO>>(productos);
            return Ok(productosDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProducto(int id)
        {
            var producto = await _context.Productos.Include(p => p.Categorias).FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null)
                return NotFound();

            var productoDTO = _mapper.Map<ProductDTO>(producto);
            return Ok(productoDTO);
        }

        [HttpPost]

        public async Task<ActionResult<ProductDTO>> PostProducto(Product producto)
        {
            var categoria = await _context.Categorias.FindAsync(producto.CategoriasId);
            if (categoria == null)
                return BadRequest(new { message = "La categoría especificada no existe" });

            producto.CategoriaNombre = categoria.Nombre;

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            var productDTO = _mapper.Map<ProductDTO>(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, productDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Product producto)
        {
            if (id != producto.Id)
                return BadRequest();

            var categoria = await _context.Categorias.FindAsync(producto.CategoriasId);
            if (categoria == null)
                return BadRequest(new { message = "La categoría especificada no existe" });

            producto.CategoriaNombre = categoria.Nombre;
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
