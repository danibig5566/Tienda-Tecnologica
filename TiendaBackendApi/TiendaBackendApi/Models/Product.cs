using System.ComponentModel.DataAnnotations;

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
        public decimal Precio { get; set; }
            [Required]
        public int Cantidad { get; set; }
        [Required]
        public string ImagenUrl { get; set; }
        

        [Required]
        public int CategoriaId {  get; set; }
        [Required]
        public Categoria Categoria { get; set; }
    }
}
