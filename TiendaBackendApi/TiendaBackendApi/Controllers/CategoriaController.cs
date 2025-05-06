using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaBackendApi.Data;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBackendApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CategoriaController : ControllerBase
        {
            private readonly AppDbContext _context;

            public CategoriaController(AppDbContext context)
            {
                _context = context;
            }

          
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Categorias>>> GetCategorias()
            {
                return await _context.Categorias.ToListAsync();
            }

          
            [HttpPost]
            public async Task<ActionResult<Categorias>> CrearCategoria(Categorias categoria)
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCategorias), new { id = categoria.Id }, categoria);
            }
        }
    }



