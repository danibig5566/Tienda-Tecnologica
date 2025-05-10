using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaBackendApi.Data;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Compra
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario{ get; set; }

        public int ProductoId { get; set; }
        public Product Producto { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaCompra { get; set; }

        public ICollection<CompraProducto> CompraProductos { get; set; }

    }

