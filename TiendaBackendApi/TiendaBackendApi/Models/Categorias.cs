

using System.ComponentModel.DataAnnotations;
using TiendaBackendApi.Models;

public class Categorias
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }

    public List<Product> Productos { get; set; } 
}
