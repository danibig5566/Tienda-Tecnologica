
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaBackendApi.Models
{
    public class Categoria
    {
        [key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación inversa
        public List<Product> Productos { get; set; }
    }
}