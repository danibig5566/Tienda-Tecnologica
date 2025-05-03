
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaBackendApi.Models
{
   
    public class Categorias
    {
      
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public List<Product>? Productos { get; set; } = new();

    }
}