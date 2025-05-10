using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaBackendApi.Data;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductoCompraDTO
{
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
}
