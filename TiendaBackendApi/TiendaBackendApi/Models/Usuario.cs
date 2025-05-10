using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaBackendApi.Data;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Usuario
    {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Correo { get; set; }

    [Required]
    public string Telefono { get; set; }

    [Required]
    public string Direccion { get; set; }

    public ICollection<Compra> Compras { get; set; }
    }
