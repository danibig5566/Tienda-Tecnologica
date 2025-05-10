using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaBackendApi.Data;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TiendaBackendApi.Models;


public class CompraProducto
{
    public int CompraId { get; set; }
    public Compra Compra { get; set; }

    public int ProductoId { get; set; }
    public Product Producto { get; set; }

    public int Cantidad { get; set; }
}