using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaBackendApi.Data;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TiendaBackendApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string ImagenUrl { get; set; }
        [Required]
        public int CategoriasId { get; set; }

        [ForeignKey("CategoriasId")]
        public Categorias Categorias { get; set; }
    }
}
