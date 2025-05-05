using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TiendaBackendApi.Models

public class ProductDTO
{
    
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public string ImagenUrl { get; set; }
    public int CategoriasId { get; set; }
}
