using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaBackendApi.Data;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TiendaBackendApi.Models;


public class CompraDTO
{
    public int UsuarioId { get; set; }
    public List<ProductoCompraDTO> Productos { get; set; }
}