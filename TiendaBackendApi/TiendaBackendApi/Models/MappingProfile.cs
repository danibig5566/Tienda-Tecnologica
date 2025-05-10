using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TiendaBackendApi.Data;
using TiendaBackendApi.Models;
using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductDTO>();

        }
    }


